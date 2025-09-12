import express from "express";
import cors from "cors";
import dotenv from "dotenv";
import { connectDB } from "./config/database";
import taskRoutes from "./routes/taskRoutes";
import swaggerJsdoc from "swagger-jsdoc";
import swaggerUi from "swagger-ui-express";

dotenv.config();

const app = express();
const PORT = process.env.PORT || 3000;

// -------------------- Swagger Configuration --------------------
const swaggerOptions = {
  definition: {
    openapi: "3.0.0",
    info: {
      title: "Tasks CRUD API",
      version: "1.0.0",
      description: "A simple Tasks CRUD API with Express, TypeScript, and MongoDB",
    },
    servers: [
      {
        url: `http://localhost:${PORT}`,
        description: "Development server",
      },
    ],
  },
  apis: ["./src/routes/*.ts"], // Path to your route files with JSDoc comments
};

const swaggerUiOptions = {
  customSiteTitle: "Tasks API Docs",
};

const swaggerSpec = swaggerJsdoc(swaggerOptions);

// -------------------- Middlewares --------------------
app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// API Routes
app.use("/api/tasks", taskRoutes);

// Swagger Routes
app.use("/api-docs", swaggerUi.serve, swaggerUi.setup(swaggerSpec, swaggerUiOptions));
app.get("/api-docs.json", (req, res) => {
  res.setHeader("Content-Type", "application/json");
  res.send(swaggerSpec);
});

// -------------------- Error Handling --------------------
app.use(
  (
    err: any,
    req: express.Request,
    res: express.Response,
    next: express.NextFunction
  ) => {
    console.error(err.stack);
    res.status(500).json({
      success: false,
      message: "Something went wrong!",
      error:
        process.env.NODE_ENV === "development"
          ? err.message
          : "Internal server error",
    });
  }
);

// 404 handler
app.use((req, res) => {
  res.status(404).json({
    success: false,
    message: "Route not found",
  });
});

// Health check
app.get("/health", (req, res) => {
  res.json({ status: "OK", timestamp: new Date().toISOString() });
});

// -------------------- Start Server --------------------
const startServer = async () => {
  try {
    await connectDB();
    app.listen(PORT, () => {
      console.log(`Server is running at http://localhost:${PORT}`);
      console.log(`Swagger docs available at http://localhost:${PORT}/api-docs`);
      console.log(`Health check at http://localhost:${PORT}/health`);
    });
  } catch (error) {
    console.error("Failed to start server:", error);
    process.exit(1);
  }
};

// Avoid double server start during tests
if (process.env.NODE_ENV !== "test") {
  startServer();
}

export default app;

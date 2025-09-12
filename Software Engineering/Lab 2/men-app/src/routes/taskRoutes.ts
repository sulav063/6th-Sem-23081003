/**
 * @swagger
 * components:
 *   schemas:
 *     Task:
 *       type: object
 *       required:
 *         - title
 *       properties:
 *         _id:
 *           type: string
 *           description: The auto-generated id of the task
 *         title:
 *           type: string
 *           description: The task title
 *         description:
 *           type: string
 *           description: The task description
 *         completed:
 *           type: boolean
 *           description: Task completion status
 *         priority:
 *           type: string
 *           enum: [low, medium, high]
 *           description: Task priority
 *         dueDate:
 *           type: string
 *           format: date-time
 *           description: Task due date
 *         createdAt:
 *           type: string
 *           format: date-time
 *         updatedAt:
 *           type: string
 *           format: date-time
 */

import { Router } from "express";
import { getTasks, createTask } from "../controllers/taskController";
import { validateBody } from "../middleware/validation";
import { createTaskSchema } from "../schemas/taskSchemas";

const router = Router();

/**
 * @swagger
 * /api/tasks:
 *   get:
 *     summary: Get all tasks
 *     tags: [Tasks]
 *     responses:
 *       200:
 *         description: List of tasks
 */

router.get("/", getTasks);
router.post("/", createTask);

/**
 * @swagger
 * /api/tasks:
 *   post:
 *     summary: Create a new task
 *     tags: [Tasks]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Task'
 *     responses:
 *       201:
 *         description: Task created successfully
 */

router.post("/", validateBody(createTaskSchema), createTask);

export default router;
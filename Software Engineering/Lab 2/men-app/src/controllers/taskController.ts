import { Request, Response, RequestHandler } from "express";
import { Task } from "../models/Task";
import { CreateTaskInput } from "../schemas/taskSchemas";

export const getTasks: RequestHandler = async (
    req: Request,
    res: Response
): Promise<void> => {
    try {
        const tasks = await Task.find().sort({ createdAt: -1 });
        res.json({
            success: true,
            data: { tasks },
        });
    } catch (error) {
        res.status(500).json({
            success: false,
            message: "Error fetching tasks",
            error: error instanceof Error ? error.message : "Unknown error",
        });
    }
};

export const createTask: RequestHandler = async (
    req: Request,
    res: Response
): Promise<void> => {
    try {
        // Type req.body as CreateTaskInput
        const taskData: CreateTaskInput = req.body;

        const task = new Task({
            ...taskData,
            dueDate: taskData.dueDate ? new Date(taskData.dueDate) : undefined,
            // createdBy: (req as any).user._id, // uncomment if you have authentication
        });

        await task.save();

        res.status(201).json({
            success: true,
            message: "Task created successfully",
            data: task,
        });
    } catch (error) {
        res.status(500).json({
            success: false,
            message: "Error creating task",
            error: error instanceof Error ? error.message : "Unknown error",
        });
    }
};

import mongoose, { Document, Schema, Types } from "mongoose";

export interface ITask extends Document {
    _id: Types.ObjectId;
    title: string;
    description?: string;
    completed: boolean;
    priority: "low" | "medium" | "high";
    createdBy: mongoose.Types.ObjectId;
    createdAt: Date;
    updatedAt: Date;
}

const TaskSchema = new Schema<ITask>(
    {
        title: {
            type: String,
            required: true,
            trim: true,
            maxlength: 100,
        },
        description: {
            type: String,
            trim: true,
        },
        completed: {
            type: Boolean,
            default: false,
        },
        priority: {
            type: String,
            enum: ["low", "medium", "high"],
            default: "medium",
        }
    },
    {
        timestamps: true,
    }
);

export const Task = mongoose.model<ITask>("Task", TaskSchema);

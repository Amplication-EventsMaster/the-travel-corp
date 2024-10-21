import { NotificationAttempt } from "../notificationAttempt/NotificationAttempt";
import { ProcessorLog } from "../processorLog/ProcessorLog";

export type MessageQueue = {
  createdAt: Date;
  id: string;
  notificationAttempts?: Array<NotificationAttempt>;
  priority: number | null;
  processorLogs?: Array<ProcessorLog>;
  queueName: string | null;
  status?: "Option1" | null;
  updatedAt: Date;
};

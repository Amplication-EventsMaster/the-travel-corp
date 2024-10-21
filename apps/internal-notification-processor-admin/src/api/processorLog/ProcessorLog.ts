import { MessageQueue } from "../messageQueue/MessageQueue";

export type ProcessorLog = {
  createdAt: Date;
  id: string;
  logType?: "Option1" | null;
  messageQueue?: MessageQueue | null;
  timestamp: Date | null;
  updatedAt: Date;
};

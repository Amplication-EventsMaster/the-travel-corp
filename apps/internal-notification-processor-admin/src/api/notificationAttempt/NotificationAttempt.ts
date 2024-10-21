import { MessageQueue } from "../messageQueue/MessageQueue";

export type NotificationAttempt = {
  attemptCount: number | null;
  createdAt: Date;
  id: string;
  messageQueue?: MessageQueue | null;
  result: string | null;
  successful: boolean | null;
  updatedAt: Date;
};

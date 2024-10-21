import { MessageQueue as TMessageQueue } from "../api/messageQueue/MessageQueue";

export const MESSAGEQUEUE_TITLE_FIELD = "queueName";

export const MessageQueueTitle = (record: TMessageQueue): string => {
  return record.queueName?.toString() || String(record.id);
};

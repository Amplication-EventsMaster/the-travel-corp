import { MessageQueueWhereUniqueInput } from "../messageQueue/MessageQueueWhereUniqueInput";

export type NotificationAttemptUpdateInput = {
  attemptCount?: number | null;
  messageQueue?: MessageQueueWhereUniqueInput | null;
  result?: string | null;
  successful?: boolean | null;
};

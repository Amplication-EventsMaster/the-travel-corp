import { MessageQueueWhereUniqueInput } from "../messageQueue/MessageQueueWhereUniqueInput";

export type NotificationAttemptCreateInput = {
  attemptCount?: number | null;
  messageQueue?: MessageQueueWhereUniqueInput | null;
  result?: string | null;
  successful?: boolean | null;
};

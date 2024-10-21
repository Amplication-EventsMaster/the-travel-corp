import { MessageQueueWhereInput } from "./MessageQueueWhereInput";
import { MessageQueueOrderByInput } from "./MessageQueueOrderByInput";

export type MessageQueueFindManyArgs = {
  where?: MessageQueueWhereInput;
  orderBy?: Array<MessageQueueOrderByInput>;
  skip?: number;
  take?: number;
};

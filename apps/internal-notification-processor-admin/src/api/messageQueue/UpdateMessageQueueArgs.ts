import { MessageQueueWhereUniqueInput } from "./MessageQueueWhereUniqueInput";
import { MessageQueueUpdateInput } from "./MessageQueueUpdateInput";

export type UpdateMessageQueueArgs = {
  where: MessageQueueWhereUniqueInput;
  data: MessageQueueUpdateInput;
};

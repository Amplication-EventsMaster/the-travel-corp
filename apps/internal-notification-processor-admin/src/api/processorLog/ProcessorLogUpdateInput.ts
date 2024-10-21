import { MessageQueueWhereUniqueInput } from "../messageQueue/MessageQueueWhereUniqueInput";

export type ProcessorLogUpdateInput = {
  logType?: "Option1" | null;
  messageQueue?: MessageQueueWhereUniqueInput | null;
  timestamp?: Date | null;
};

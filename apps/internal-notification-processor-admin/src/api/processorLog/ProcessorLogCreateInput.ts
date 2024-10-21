import { MessageQueueWhereUniqueInput } from "../messageQueue/MessageQueueWhereUniqueInput";

export type ProcessorLogCreateInput = {
  logType?: "Option1" | null;
  messageQueue?: MessageQueueWhereUniqueInput | null;
  timestamp?: Date | null;
};

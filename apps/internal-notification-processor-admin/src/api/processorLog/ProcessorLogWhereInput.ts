import { StringFilter } from "../../util/StringFilter";
import { MessageQueueWhereUniqueInput } from "../messageQueue/MessageQueueWhereUniqueInput";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";

export type ProcessorLogWhereInput = {
  id?: StringFilter;
  logType?: "Option1";
  messageQueue?: MessageQueueWhereUniqueInput;
  timestamp?: DateTimeNullableFilter;
};

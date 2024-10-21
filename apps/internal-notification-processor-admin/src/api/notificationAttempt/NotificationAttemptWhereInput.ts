import { IntNullableFilter } from "../../util/IntNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { MessageQueueWhereUniqueInput } from "../messageQueue/MessageQueueWhereUniqueInput";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { BooleanNullableFilter } from "../../util/BooleanNullableFilter";

export type NotificationAttemptWhereInput = {
  attemptCount?: IntNullableFilter;
  id?: StringFilter;
  messageQueue?: MessageQueueWhereUniqueInput;
  result?: StringNullableFilter;
  successful?: BooleanNullableFilter;
};

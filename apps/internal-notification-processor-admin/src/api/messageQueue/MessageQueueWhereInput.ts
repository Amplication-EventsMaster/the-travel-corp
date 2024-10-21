import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { NotificationAttemptListRelationFilter } from "../notificationAttempt/NotificationAttemptListRelationFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { ProcessorLogListRelationFilter } from "../processorLog/ProcessorLogListRelationFilter";

export type MessageQueueWhereInput = {
  comment?: StringNullableFilter;
  id?: StringFilter;
  notificationAttempts?: NotificationAttemptListRelationFilter;
  priority?: IntNullableFilter;
  processorLogs?: ProcessorLogListRelationFilter;
  queueName?: StringNullableFilter;
  status?: "Option1";
};

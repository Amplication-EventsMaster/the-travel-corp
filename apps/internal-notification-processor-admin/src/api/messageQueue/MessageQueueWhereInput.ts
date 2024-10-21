import { StringFilter } from "../../util/StringFilter";
import { NotificationAttemptListRelationFilter } from "../notificationAttempt/NotificationAttemptListRelationFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { ProcessorLogListRelationFilter } from "../processorLog/ProcessorLogListRelationFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type MessageQueueWhereInput = {
  id?: StringFilter;
  notificationAttempts?: NotificationAttemptListRelationFilter;
  priority?: IntNullableFilter;
  processorLogs?: ProcessorLogListRelationFilter;
  queueName?: StringNullableFilter;
  status?: "Option1";
};

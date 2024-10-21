import { NotificationAttemptUpdateManyWithoutMessageQueuesInput } from "./NotificationAttemptUpdateManyWithoutMessageQueuesInput";
import { ProcessorLogUpdateManyWithoutMessageQueuesInput } from "./ProcessorLogUpdateManyWithoutMessageQueuesInput";

export type MessageQueueUpdateInput = {
  comment?: string | null;
  notificationAttempts?: NotificationAttemptUpdateManyWithoutMessageQueuesInput;
  priority?: number | null;
  processorLogs?: ProcessorLogUpdateManyWithoutMessageQueuesInput;
  queueName?: string | null;
  status?: "Option1" | null;
};

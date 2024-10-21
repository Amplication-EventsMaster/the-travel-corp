import { NotificationAttemptCreateNestedManyWithoutMessageQueuesInput } from "./NotificationAttemptCreateNestedManyWithoutMessageQueuesInput";
import { ProcessorLogCreateNestedManyWithoutMessageQueuesInput } from "./ProcessorLogCreateNestedManyWithoutMessageQueuesInput";

export type MessageQueueCreateInput = {
  notificationAttempts?: NotificationAttemptCreateNestedManyWithoutMessageQueuesInput;
  priority?: number | null;
  processorLogs?: ProcessorLogCreateNestedManyWithoutMessageQueuesInput;
  queueName?: string | null;
  status?: "Option1" | null;
};

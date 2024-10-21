import { SortOrder } from "../../util/SortOrder";

export type NotificationAttemptOrderByInput = {
  attemptCount?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  messageQueueId?: SortOrder;
  result?: SortOrder;
  successful?: SortOrder;
  updatedAt?: SortOrder;
};

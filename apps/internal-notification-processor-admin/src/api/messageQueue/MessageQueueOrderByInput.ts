import { SortOrder } from "../../util/SortOrder";

export type MessageQueueOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  priority?: SortOrder;
  queueName?: SortOrder;
  status?: SortOrder;
  updatedAt?: SortOrder;
};

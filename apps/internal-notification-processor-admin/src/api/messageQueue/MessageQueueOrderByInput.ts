import { SortOrder } from "../../util/SortOrder";

export type MessageQueueOrderByInput = {
  comment?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  priority?: SortOrder;
  queueName?: SortOrder;
  status?: SortOrder;
  updatedAt?: SortOrder;
};

import { SortOrder } from "../../util/SortOrder";

export type ProcessorLogOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  logType?: SortOrder;
  messageQueueId?: SortOrder;
  timestamp?: SortOrder;
  updatedAt?: SortOrder;
};

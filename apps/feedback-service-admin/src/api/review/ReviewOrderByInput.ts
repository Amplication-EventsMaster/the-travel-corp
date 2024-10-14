import { SortOrder } from "../../util/SortOrder";

export type ReviewOrderByInput = {
  content?: SortOrder;
  createdAt?: SortOrder;
  feedbackId?: SortOrder;
  id?: SortOrder;
  title?: SortOrder;
  typeFieldId?: SortOrder;
  updatedAt?: SortOrder;
};

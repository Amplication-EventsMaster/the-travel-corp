import { SortOrder } from "../../util/SortOrder";

export type FeedbackOrderByInput = {
  booking?: SortOrder;
  comments?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  rating?: SortOrder;
  remarks?: SortOrder;
  updatedAt?: SortOrder;
};

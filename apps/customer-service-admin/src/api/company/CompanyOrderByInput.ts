import { SortOrder } from "../../util/SortOrder";

export type CompanyOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  industry?: SortOrder;
  name?: SortOrder;
  updatedAt?: SortOrder;
  website?: SortOrder;
};

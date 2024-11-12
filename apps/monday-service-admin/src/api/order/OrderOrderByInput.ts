import { SortOrder } from "../../util/SortOrder";

export type OrderOrderByInput = {
  createdAt?: SortOrder;
  customerId?: SortOrder;
  id?: SortOrder;
  orderDate?: SortOrder;
  orderNumber?: SortOrder;
  totalAmount?: SortOrder;
  updatedAt?: SortOrder;
};

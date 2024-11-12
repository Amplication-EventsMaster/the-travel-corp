import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";

export type OrderCreateInput = {
  customer?: CustomerWhereUniqueInput | null;
  orderDate?: Date | null;
  orderNumber?: string | null;
  totalAmount?: number | null;
};

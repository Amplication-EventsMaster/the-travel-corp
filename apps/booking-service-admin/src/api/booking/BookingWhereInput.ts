import { StringNullableFilter } from "../../util/StringNullableFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { PaymentListRelationFilter } from "../payment/PaymentListRelationFilter";

export type BookingWhereInput = {
  customer?: StringNullableFilter;
  date?: DateTimeNullableFilter;
  flight?: StringNullableFilter;
  id?: StringFilter;
  payments?: PaymentListRelationFilter;
  status?: StringNullableFilter;
};

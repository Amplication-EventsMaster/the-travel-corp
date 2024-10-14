import { BookingWhereUniqueInput } from "../booking/BookingWhereUniqueInput";

export type PaymentUpdateInput = {
  amount?: number | null;
  booking?: BookingWhereUniqueInput | null;
  date?: Date | null;
  method?: string | null;
};

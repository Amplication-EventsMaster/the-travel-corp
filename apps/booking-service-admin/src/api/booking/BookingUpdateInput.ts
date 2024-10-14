import { PaymentUpdateManyWithoutBookingsInput } from "./PaymentUpdateManyWithoutBookingsInput";

export type BookingUpdateInput = {
  customer?: string | null;
  date?: Date | null;
  flight?: string | null;
  payments?: PaymentUpdateManyWithoutBookingsInput;
  status?: string | null;
};

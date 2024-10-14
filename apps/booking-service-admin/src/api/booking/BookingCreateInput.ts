import { PaymentCreateNestedManyWithoutBookingsInput } from "./PaymentCreateNestedManyWithoutBookingsInput";

export type BookingCreateInput = {
  customer?: string | null;
  date?: Date | null;
  flight?: string | null;
  payments?: PaymentCreateNestedManyWithoutBookingsInput;
  status?: string | null;
};

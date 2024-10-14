import { Payment } from "../payment/Payment";

export type Booking = {
  createdAt: Date;
  customer: string | null;
  date: Date | null;
  flight: string | null;
  id: string;
  payments?: Array<Payment>;
  status: string | null;
  updatedAt: Date;
};

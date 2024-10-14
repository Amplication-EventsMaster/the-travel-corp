import { Booking as TBooking } from "../api/booking/Booking";

export const BOOKING_TITLE_FIELD = "customer";

export const BookingTitle = (record: TBooking): string => {
  return record.customer?.toString() || String(record.id);
};

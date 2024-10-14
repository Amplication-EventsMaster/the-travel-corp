import { Payment as TPayment } from "../api/payment/Payment";

export const PAYMENT_TITLE_FIELD = "method";

export const PaymentTitle = (record: TPayment): string => {
  return record.method?.toString() || String(record.id);
};

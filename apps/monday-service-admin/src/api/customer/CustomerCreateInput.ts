import { OrderCreateNestedManyWithoutCustomersInput } from "./OrderCreateNestedManyWithoutCustomersInput";

export type CustomerCreateInput = {
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  orders?: OrderCreateNestedManyWithoutCustomersInput;
  phoneNumber?: string | null;
};

import { Customer } from "../customer/Customer";

export type Company = {
  createdAt: Date;
  customers?: Array<Customer>;
  id: string;
  industry: string | null;
  name: string | null;
  updatedAt: Date;
  website: string | null;
};

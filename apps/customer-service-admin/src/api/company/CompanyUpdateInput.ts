import { CustomerUpdateManyWithoutCompaniesInput } from "./CustomerUpdateManyWithoutCompaniesInput";

export type CompanyUpdateInput = {
  customers?: CustomerUpdateManyWithoutCompaniesInput;
  industry?: string | null;
  name?: string | null;
  website?: string | null;
};

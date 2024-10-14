import { CustomerCreateNestedManyWithoutCompaniesInput } from "./CustomerCreateNestedManyWithoutCompaniesInput";

export type CompanyCreateInput = {
  customers?: CustomerCreateNestedManyWithoutCompaniesInput;
  industry?: string | null;
  name?: string | null;
  website?: string | null;
};

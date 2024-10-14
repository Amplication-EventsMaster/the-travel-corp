import { CompanyWhereUniqueInput } from "../company/CompanyWhereUniqueInput";

export type CustomerCreateInput = {
  company?: CompanyWhereUniqueInput | null;
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  phoneNumber?: string | null;
};

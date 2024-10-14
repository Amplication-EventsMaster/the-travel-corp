import { CustomerListRelationFilter } from "../customer/CustomerListRelationFilter";
import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type CompanyWhereInput = {
  customers?: CustomerListRelationFilter;
  id?: StringFilter;
  industry?: StringNullableFilter;
  name?: StringNullableFilter;
  website?: StringNullableFilter;
};

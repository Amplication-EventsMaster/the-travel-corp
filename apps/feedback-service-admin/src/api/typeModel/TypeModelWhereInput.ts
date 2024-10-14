import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { ReviewListRelationFilter } from "../review/ReviewListRelationFilter";

export type TypeModelWhereInput = {
  id?: StringFilter;
  name?: StringNullableFilter;
  reviews?: ReviewListRelationFilter;
};

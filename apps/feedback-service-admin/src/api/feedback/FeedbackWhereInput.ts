import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { ReviewListRelationFilter } from "../review/ReviewListRelationFilter";

export type FeedbackWhereInput = {
  booking?: StringNullableFilter;
  comments?: StringNullableFilter;
  id?: StringFilter;
  rating?: IntNullableFilter;
  reviews?: ReviewListRelationFilter;
};

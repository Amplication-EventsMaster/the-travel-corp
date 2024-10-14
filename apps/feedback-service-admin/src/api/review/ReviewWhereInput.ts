import { StringNullableFilter } from "../../util/StringNullableFilter";
import { FeedbackWhereUniqueInput } from "../feedback/FeedbackWhereUniqueInput";
import { StringFilter } from "../../util/StringFilter";
import { TypeModelWhereUniqueInput } from "../typeModel/TypeModelWhereUniqueInput";

export type ReviewWhereInput = {
  content?: StringNullableFilter;
  feedback?: FeedbackWhereUniqueInput;
  id?: StringFilter;
  title?: StringNullableFilter;
  typeField?: TypeModelWhereUniqueInput;
};

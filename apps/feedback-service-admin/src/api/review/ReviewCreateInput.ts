import { FeedbackWhereUniqueInput } from "../feedback/FeedbackWhereUniqueInput";
import { TypeModelWhereUniqueInput } from "../typeModel/TypeModelWhereUniqueInput";

export type ReviewCreateInput = {
  content?: string | null;
  feedback?: FeedbackWhereUniqueInput | null;
  title?: string | null;
  typeField?: TypeModelWhereUniqueInput | null;
};

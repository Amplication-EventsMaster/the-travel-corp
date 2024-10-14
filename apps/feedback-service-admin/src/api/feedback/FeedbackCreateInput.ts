import { ReviewCreateNestedManyWithoutFeedbacksInput } from "./ReviewCreateNestedManyWithoutFeedbacksInput";

export type FeedbackCreateInput = {
  booking?: string | null;
  comments?: string | null;
  rating?: number | null;
  reviews?: ReviewCreateNestedManyWithoutFeedbacksInput;
};

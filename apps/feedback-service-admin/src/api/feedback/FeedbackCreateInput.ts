import { ReviewCreateNestedManyWithoutFeedbacksInput } from "./ReviewCreateNestedManyWithoutFeedbacksInput";

export type FeedbackCreateInput = {
  booking?: string | null;
  comments?: string | null;
  rating?: number | null;
  remarks?: string | null;
  reviews?: ReviewCreateNestedManyWithoutFeedbacksInput;
};

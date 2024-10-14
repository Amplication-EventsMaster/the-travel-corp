import { ReviewUpdateManyWithoutFeedbacksInput } from "./ReviewUpdateManyWithoutFeedbacksInput";

export type FeedbackUpdateInput = {
  booking?: string | null;
  comments?: string | null;
  rating?: number | null;
  reviews?: ReviewUpdateManyWithoutFeedbacksInput;
};

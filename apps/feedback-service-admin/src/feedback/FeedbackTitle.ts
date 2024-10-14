import { Feedback as TFeedback } from "../api/feedback/Feedback";

export const FEEDBACK_TITLE_FIELD = "booking";

export const FeedbackTitle = (record: TFeedback): string => {
  return record.booking?.toString() || String(record.id);
};

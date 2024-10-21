import { NotificationAttempt as TNotificationAttempt } from "../api/notificationAttempt/NotificationAttempt";

export const NOTIFICATIONATTEMPT_TITLE_FIELD = "id";

export const NotificationAttemptTitle = (
  record: TNotificationAttempt
): string => {
  return record.id?.toString() || String(record.id);
};

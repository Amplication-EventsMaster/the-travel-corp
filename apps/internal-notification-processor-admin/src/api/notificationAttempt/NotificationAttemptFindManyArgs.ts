import { NotificationAttemptWhereInput } from "./NotificationAttemptWhereInput";
import { NotificationAttemptOrderByInput } from "./NotificationAttemptOrderByInput";

export type NotificationAttemptFindManyArgs = {
  where?: NotificationAttemptWhereInput;
  orderBy?: Array<NotificationAttemptOrderByInput>;
  skip?: number;
  take?: number;
};

import * as graphql from "@nestjs/graphql";
import { NotificationAttemptResolverBase } from "./base/notificationAttempt.resolver.base";
import { NotificationAttempt } from "./base/NotificationAttempt";
import { NotificationAttemptService } from "./notificationAttempt.service";

@graphql.Resolver(() => NotificationAttempt)
export class NotificationAttemptResolver extends NotificationAttemptResolverBase {
  constructor(protected readonly service: NotificationAttemptService) {
    super(service);
  }
}

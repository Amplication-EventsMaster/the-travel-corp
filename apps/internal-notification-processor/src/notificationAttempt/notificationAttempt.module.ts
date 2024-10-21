import { Module } from "@nestjs/common";
import { NotificationAttemptModuleBase } from "./base/notificationAttempt.module.base";
import { NotificationAttemptService } from "./notificationAttempt.service";
import { NotificationAttemptResolver } from "./notificationAttempt.resolver";

@Module({
  imports: [NotificationAttemptModuleBase],
  providers: [NotificationAttemptService, NotificationAttemptResolver],
  exports: [NotificationAttemptService],
})
export class NotificationAttemptModule {}

import { Module } from "@nestjs/common";
import { ReminderMailModuleBase } from "./base/reminderMail.module.base";
import { ReminderMailService } from "./reminderMail.service";
import { ReminderMailResolver } from "./reminderMail.resolver";

@Module({
  imports: [ReminderMailModuleBase],
  providers: [ReminderMailService, ReminderMailResolver],
  exports: [ReminderMailService],
})
export class ReminderMailModule {}

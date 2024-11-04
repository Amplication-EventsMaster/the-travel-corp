import { Module } from "@nestjs/common";
import { WorkflowReminderModuleBase } from "./base/workflowReminder.module.base";
import { WorkflowReminderService } from "./workflowReminder.service";
import { WorkflowReminderResolver } from "./workflowReminder.resolver";

@Module({
  imports: [WorkflowReminderModuleBase],
  providers: [WorkflowReminderService, WorkflowReminderResolver],
  exports: [WorkflowReminderService],
})
export class WorkflowReminderModule {}

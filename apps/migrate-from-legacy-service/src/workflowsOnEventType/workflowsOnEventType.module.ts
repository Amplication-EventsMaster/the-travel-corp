import { Module } from "@nestjs/common";
import { WorkflowsOnEventTypeModuleBase } from "./base/workflowsOnEventType.module.base";
import { WorkflowsOnEventTypeService } from "./workflowsOnEventType.service";
import { WorkflowsOnEventTypeResolver } from "./workflowsOnEventType.resolver";

@Module({
  imports: [WorkflowsOnEventTypeModuleBase],
  providers: [WorkflowsOnEventTypeService, WorkflowsOnEventTypeResolver],
  exports: [WorkflowsOnEventTypeService],
})
export class WorkflowsOnEventTypeModule {}

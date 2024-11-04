import { Module } from "@nestjs/common";
import { WorkflowModuleBase } from "./base/workflow.module.base";
import { WorkflowService } from "./workflow.service";
import { WorkflowResolver } from "./workflow.resolver";

@Module({
  imports: [WorkflowModuleBase],
  providers: [WorkflowService, WorkflowResolver],
  exports: [WorkflowService],
})
export class WorkflowModule {}

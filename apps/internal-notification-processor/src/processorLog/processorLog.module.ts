import { Module } from "@nestjs/common";
import { ProcessorLogModuleBase } from "./base/processorLog.module.base";
import { ProcessorLogService } from "./processorLog.service";
import { ProcessorLogResolver } from "./processorLog.resolver";

@Module({
  imports: [ProcessorLogModuleBase],
  providers: [ProcessorLogService, ProcessorLogResolver],
  exports: [ProcessorLogService],
})
export class ProcessorLogModule {}

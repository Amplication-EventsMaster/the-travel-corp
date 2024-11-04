import { Module } from "@nestjs/common";
import { ScheduleModuleBase } from "./base/schedule.module.base";
import { ScheduleService } from "./schedule.service";
import { ScheduleResolver } from "./schedule.resolver";

@Module({
  imports: [ScheduleModuleBase],
  providers: [ScheduleService, ScheduleResolver],
  exports: [ScheduleService],
})
export class ScheduleModule {}

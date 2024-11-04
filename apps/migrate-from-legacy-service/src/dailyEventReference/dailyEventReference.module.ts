import { Module } from "@nestjs/common";
import { DailyEventReferenceModuleBase } from "./base/dailyEventReference.module.base";
import { DailyEventReferenceService } from "./dailyEventReference.service";
import { DailyEventReferenceResolver } from "./dailyEventReference.resolver";

@Module({
  imports: [DailyEventReferenceModuleBase],
  providers: [DailyEventReferenceService, DailyEventReferenceResolver],
  exports: [DailyEventReferenceService],
})
export class DailyEventReferenceModule {}

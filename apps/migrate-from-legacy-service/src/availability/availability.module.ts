import { Module } from "@nestjs/common";
import { AvailabilityModuleBase } from "./base/availability.module.base";
import { AvailabilityService } from "./availability.service";
import { AvailabilityResolver } from "./availability.resolver";

@Module({
  imports: [AvailabilityModuleBase],
  providers: [AvailabilityService, AvailabilityResolver],
  exports: [AvailabilityService],
})
export class AvailabilityModule {}

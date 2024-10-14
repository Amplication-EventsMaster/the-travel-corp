import { Module } from "@nestjs/common";
import { AirportModuleBase } from "./base/airport.module.base";
import { AirportService } from "./airport.service";
import { AirportResolver } from "./airport.resolver";

@Module({
  imports: [AirportModuleBase],
  providers: [AirportService, AirportResolver],
  exports: [AirportService],
})
export class AirportModule {}

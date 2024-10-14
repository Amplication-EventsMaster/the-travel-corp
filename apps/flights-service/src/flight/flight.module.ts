import { Module } from "@nestjs/common";
import { FlightModuleBase } from "./base/flight.module.base";
import { FlightService } from "./flight.service";
import { FlightResolver } from "./flight.resolver";

@Module({
  imports: [FlightModuleBase],
  providers: [FlightService, FlightResolver],
  exports: [FlightService],
})
export class FlightModule {}

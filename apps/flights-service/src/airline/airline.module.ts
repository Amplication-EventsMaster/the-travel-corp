import { Module } from "@nestjs/common";
import { AirlineModuleBase } from "./base/airline.module.base";
import { AirlineService } from "./airline.service";
import { AirlineResolver } from "./airline.resolver";

@Module({
  imports: [AirlineModuleBase],
  providers: [AirlineService, AirlineResolver],
  exports: [AirlineService],
})
export class AirlineModule {}

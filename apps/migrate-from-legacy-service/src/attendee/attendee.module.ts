import { Module } from "@nestjs/common";
import { AttendeeModuleBase } from "./base/attendee.module.base";
import { AttendeeService } from "./attendee.service";
import { AttendeeResolver } from "./attendee.resolver";

@Module({
  imports: [AttendeeModuleBase],
  providers: [AttendeeService, AttendeeResolver],
  exports: [AttendeeService],
})
export class AttendeeModule {}

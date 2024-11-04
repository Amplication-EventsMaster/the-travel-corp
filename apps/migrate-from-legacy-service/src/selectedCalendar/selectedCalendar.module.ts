import { Module } from "@nestjs/common";
import { SelectedCalendarModuleBase } from "./base/selectedCalendar.module.base";
import { SelectedCalendarService } from "./selectedCalendar.service";
import { SelectedCalendarResolver } from "./selectedCalendar.resolver";

@Module({
  imports: [SelectedCalendarModuleBase],
  providers: [SelectedCalendarService, SelectedCalendarResolver],
  exports: [SelectedCalendarService],
})
export class SelectedCalendarModule {}

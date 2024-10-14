import { Module } from "@nestjs/common";
import { BookingModuleBase } from "./base/booking.module.base";
import { BookingService } from "./booking.service";
import { BookingResolver } from "./booking.resolver";

@Module({
  imports: [BookingModuleBase],
  providers: [BookingService, BookingResolver],
  exports: [BookingService],
})
export class BookingModule {}

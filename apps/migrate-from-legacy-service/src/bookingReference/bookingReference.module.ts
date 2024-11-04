import { Module } from "@nestjs/common";
import { BookingReferenceModuleBase } from "./base/bookingReference.module.base";
import { BookingReferenceService } from "./bookingReference.service";
import { BookingReferenceResolver } from "./bookingReference.resolver";

@Module({
  imports: [BookingReferenceModuleBase],
  providers: [BookingReferenceService, BookingReferenceResolver],
  exports: [BookingReferenceService],
})
export class BookingReferenceModule {}

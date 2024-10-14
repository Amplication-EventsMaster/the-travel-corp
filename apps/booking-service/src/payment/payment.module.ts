import { Module } from "@nestjs/common";
import { PaymentModuleBase } from "./base/payment.module.base";
import { PaymentService } from "./payment.service";
import { PaymentResolver } from "./payment.resolver";

@Module({
  imports: [PaymentModuleBase],
  providers: [PaymentService, PaymentResolver],
  exports: [PaymentService],
})
export class PaymentModule {}

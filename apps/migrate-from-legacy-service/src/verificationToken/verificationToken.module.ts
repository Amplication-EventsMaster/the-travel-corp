import { Module } from "@nestjs/common";
import { VerificationTokenModuleBase } from "./base/verificationToken.module.base";
import { VerificationTokenService } from "./verificationToken.service";
import { VerificationTokenResolver } from "./verificationToken.resolver";

@Module({
  imports: [VerificationTokenModuleBase],
  providers: [VerificationTokenService, VerificationTokenResolver],
  exports: [VerificationTokenService],
})
export class VerificationTokenModule {}

import { Module } from "@nestjs/common";
import { ResetPasswordRequestModuleBase } from "./base/resetPasswordRequest.module.base";
import { ResetPasswordRequestService } from "./resetPasswordRequest.service";
import { ResetPasswordRequestResolver } from "./resetPasswordRequest.resolver";

@Module({
  imports: [ResetPasswordRequestModuleBase],
  providers: [ResetPasswordRequestService, ResetPasswordRequestResolver],
  exports: [ResetPasswordRequestService],
})
export class ResetPasswordRequestModule {}

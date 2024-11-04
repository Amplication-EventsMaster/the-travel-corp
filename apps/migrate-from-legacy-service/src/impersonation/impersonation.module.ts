import { Module } from "@nestjs/common";
import { ImpersonationModuleBase } from "./base/impersonation.module.base";
import { ImpersonationService } from "./impersonation.service";
import { ImpersonationResolver } from "./impersonation.resolver";

@Module({
  imports: [ImpersonationModuleBase],
  providers: [ImpersonationService, ImpersonationResolver],
  exports: [ImpersonationService],
})
export class ImpersonationModule {}

import { Module } from "@nestjs/common";
import { SessionModuleBase } from "./base/session.module.base";
import { SessionService } from "./session.service";
import { SessionResolver } from "./session.resolver";

@Module({
  imports: [SessionModuleBase],
  providers: [SessionService, SessionResolver],
  exports: [SessionService],
})
export class SessionModule {}

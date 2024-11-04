import { Module } from "@nestjs/common";
import { MembershipModuleBase } from "./base/membership.module.base";
import { MembershipService } from "./membership.service";
import { MembershipResolver } from "./membership.resolver";

@Module({
  imports: [MembershipModuleBase],
  providers: [MembershipService, MembershipResolver],
  exports: [MembershipService],
})
export class MembershipModule {}

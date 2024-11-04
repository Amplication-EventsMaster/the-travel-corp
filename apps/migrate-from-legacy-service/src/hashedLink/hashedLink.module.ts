import { Module } from "@nestjs/common";
import { HashedLinkModuleBase } from "./base/hashedLink.module.base";
import { HashedLinkService } from "./hashedLink.service";
import { HashedLinkResolver } from "./hashedLink.resolver";

@Module({
  imports: [HashedLinkModuleBase],
  providers: [HashedLinkService, HashedLinkResolver],
  exports: [HashedLinkService],
})
export class HashedLinkModule {}

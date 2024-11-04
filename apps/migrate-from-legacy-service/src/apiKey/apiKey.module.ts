import { Module } from "@nestjs/common";
import { ApiKeyModuleBase } from "./base/apiKey.module.base";
import { ApiKeyService } from "./apiKey.service";
import { ApiKeyResolver } from "./apiKey.resolver";

@Module({
  imports: [ApiKeyModuleBase],
  providers: [ApiKeyService, ApiKeyResolver],
  exports: [ApiKeyService],
})
export class ApiKeyModule {}

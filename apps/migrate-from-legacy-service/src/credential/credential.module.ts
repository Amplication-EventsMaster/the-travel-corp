import { Module } from "@nestjs/common";
import { CredentialModuleBase } from "./base/credential.module.base";
import { CredentialService } from "./credential.service";
import { CredentialResolver } from "./credential.resolver";

@Module({
  imports: [CredentialModuleBase],
  providers: [CredentialService, CredentialResolver],
  exports: [CredentialService],
})
export class CredentialModule {}

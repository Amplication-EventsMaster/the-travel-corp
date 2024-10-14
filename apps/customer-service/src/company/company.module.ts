import { Module } from "@nestjs/common";
import { CompanyModuleBase } from "./base/company.module.base";
import { CompanyService } from "./company.service";
import { CompanyResolver } from "./company.resolver";

@Module({
  imports: [CompanyModuleBase],
  providers: [CompanyService, CompanyResolver],
  exports: [CompanyService],
})
export class CompanyModule {}

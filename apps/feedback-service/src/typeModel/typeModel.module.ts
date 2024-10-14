import { Module } from "@nestjs/common";
import { TypeModelModuleBase } from "./base/typeModel.module.base";
import { TypeModelService } from "./typeModel.service";
import { TypeModelResolver } from "./typeModel.resolver";

@Module({
  imports: [TypeModelModuleBase],
  providers: [TypeModelService, TypeModelResolver],
  exports: [TypeModelService],
})
export class TypeModelModule {}

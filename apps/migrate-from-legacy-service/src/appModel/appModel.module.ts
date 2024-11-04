import { Module } from "@nestjs/common";
import { AppModelModuleBase } from "./base/appModel.module.base";
import { AppModelService } from "./appModel.service";
import { AppModelResolver } from "./appModel.resolver";

@Module({
  imports: [AppModelModuleBase],
  providers: [AppModelService, AppModelResolver],
  exports: [AppModelService],
})
export class AppModelModule {}

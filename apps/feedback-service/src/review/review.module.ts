import { Module } from "@nestjs/common";
import { ReviewModuleBase } from "./base/review.module.base";
import { ReviewService } from "./review.service";
import { ReviewResolver } from "./review.resolver";

@Module({
  imports: [ReviewModuleBase],
  providers: [ReviewService, ReviewResolver],
  exports: [ReviewService],
})
export class ReviewModule {}

import { Module } from "@nestjs/common";
import { WebhookModuleBase } from "./base/webhook.module.base";
import { WebhookService } from "./webhook.service";
import { WebhookResolver } from "./webhook.resolver";

@Module({
  imports: [WebhookModuleBase],
  providers: [WebhookService, WebhookResolver],
  exports: [WebhookService],
})
export class WebhookModule {}

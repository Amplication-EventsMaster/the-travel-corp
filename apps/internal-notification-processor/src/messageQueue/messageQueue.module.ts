import { Module } from "@nestjs/common";
import { MessageQueueModuleBase } from "./base/messageQueue.module.base";
import { MessageQueueService } from "./messageQueue.service";
import { MessageQueueResolver } from "./messageQueue.resolver";

@Module({
  imports: [MessageQueueModuleBase],
  providers: [MessageQueueService, MessageQueueResolver],
  exports: [MessageQueueService],
})
export class MessageQueueModule {}

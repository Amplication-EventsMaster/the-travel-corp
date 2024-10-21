import * as graphql from "@nestjs/graphql";
import { MessageQueueResolverBase } from "./base/messageQueue.resolver.base";
import { MessageQueue } from "./base/MessageQueue";
import { MessageQueueService } from "./messageQueue.service";

@graphql.Resolver(() => MessageQueue)
export class MessageQueueResolver extends MessageQueueResolverBase {
  constructor(protected readonly service: MessageQueueService) {
    super(service);
  }
}

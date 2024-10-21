/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as graphql from "@nestjs/graphql";
import { GraphQLError } from "graphql";
import { isRecordNotFoundError } from "../../prisma.util";
import { MetaQueryPayload } from "../../util/MetaQueryPayload";
import { MessageQueue } from "./MessageQueue";
import { MessageQueueCountArgs } from "./MessageQueueCountArgs";
import { MessageQueueFindManyArgs } from "./MessageQueueFindManyArgs";
import { MessageQueueFindUniqueArgs } from "./MessageQueueFindUniqueArgs";
import { CreateMessageQueueArgs } from "./CreateMessageQueueArgs";
import { UpdateMessageQueueArgs } from "./UpdateMessageQueueArgs";
import { DeleteMessageQueueArgs } from "./DeleteMessageQueueArgs";
import { NotificationAttemptFindManyArgs } from "../../notificationAttempt/base/NotificationAttemptFindManyArgs";
import { NotificationAttempt } from "../../notificationAttempt/base/NotificationAttempt";
import { ProcessorLogFindManyArgs } from "../../processorLog/base/ProcessorLogFindManyArgs";
import { ProcessorLog } from "../../processorLog/base/ProcessorLog";
import { MessageQueueService } from "../messageQueue.service";
@graphql.Resolver(() => MessageQueue)
export class MessageQueueResolverBase {
  constructor(protected readonly service: MessageQueueService) {}

  async _messageQueuesMeta(
    @graphql.Args() args: MessageQueueCountArgs
  ): Promise<MetaQueryPayload> {
    const result = await this.service.count(args);
    return {
      count: result,
    };
  }

  @graphql.Query(() => [MessageQueue])
  async messageQueues(
    @graphql.Args() args: MessageQueueFindManyArgs
  ): Promise<MessageQueue[]> {
    return this.service.messageQueues(args);
  }

  @graphql.Query(() => MessageQueue, { nullable: true })
  async messageQueue(
    @graphql.Args() args: MessageQueueFindUniqueArgs
  ): Promise<MessageQueue | null> {
    const result = await this.service.messageQueue(args);
    if (result === null) {
      return null;
    }
    return result;
  }

  @graphql.Mutation(() => MessageQueue)
  async createMessageQueue(
    @graphql.Args() args: CreateMessageQueueArgs
  ): Promise<MessageQueue> {
    return await this.service.createMessageQueue({
      ...args,
      data: args.data,
    });
  }

  @graphql.Mutation(() => MessageQueue)
  async updateMessageQueue(
    @graphql.Args() args: UpdateMessageQueueArgs
  ): Promise<MessageQueue | null> {
    try {
      return await this.service.updateMessageQueue({
        ...args,
        data: args.data,
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }

  @graphql.Mutation(() => MessageQueue)
  async deleteMessageQueue(
    @graphql.Args() args: DeleteMessageQueueArgs
  ): Promise<MessageQueue | null> {
    try {
      return await this.service.deleteMessageQueue(args);
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }

  @graphql.ResolveField(() => [NotificationAttempt], {
    name: "notificationAttempts",
  })
  async findNotificationAttempts(
    @graphql.Parent() parent: MessageQueue,
    @graphql.Args() args: NotificationAttemptFindManyArgs
  ): Promise<NotificationAttempt[]> {
    const results = await this.service.findNotificationAttempts(
      parent.id,
      args
    );

    if (!results) {
      return [];
    }

    return results;
  }

  @graphql.ResolveField(() => [ProcessorLog], { name: "processorLogs" })
  async findProcessorLogs(
    @graphql.Parent() parent: MessageQueue,
    @graphql.Args() args: ProcessorLogFindManyArgs
  ): Promise<ProcessorLog[]> {
    const results = await this.service.findProcessorLogs(parent.id, args);

    if (!results) {
      return [];
    }

    return results;
  }
}

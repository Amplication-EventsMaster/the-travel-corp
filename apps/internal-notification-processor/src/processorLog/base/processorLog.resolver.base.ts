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
import { ProcessorLog } from "./ProcessorLog";
import { ProcessorLogCountArgs } from "./ProcessorLogCountArgs";
import { ProcessorLogFindManyArgs } from "./ProcessorLogFindManyArgs";
import { ProcessorLogFindUniqueArgs } from "./ProcessorLogFindUniqueArgs";
import { CreateProcessorLogArgs } from "./CreateProcessorLogArgs";
import { UpdateProcessorLogArgs } from "./UpdateProcessorLogArgs";
import { DeleteProcessorLogArgs } from "./DeleteProcessorLogArgs";
import { MessageQueue } from "../../messageQueue/base/MessageQueue";
import { ProcessorLogService } from "../processorLog.service";
@graphql.Resolver(() => ProcessorLog)
export class ProcessorLogResolverBase {
  constructor(protected readonly service: ProcessorLogService) {}

  async _processorLogsMeta(
    @graphql.Args() args: ProcessorLogCountArgs
  ): Promise<MetaQueryPayload> {
    const result = await this.service.count(args);
    return {
      count: result,
    };
  }

  @graphql.Query(() => [ProcessorLog])
  async processorLogs(
    @graphql.Args() args: ProcessorLogFindManyArgs
  ): Promise<ProcessorLog[]> {
    return this.service.processorLogs(args);
  }

  @graphql.Query(() => ProcessorLog, { nullable: true })
  async processorLog(
    @graphql.Args() args: ProcessorLogFindUniqueArgs
  ): Promise<ProcessorLog | null> {
    const result = await this.service.processorLog(args);
    if (result === null) {
      return null;
    }
    return result;
  }

  @graphql.Mutation(() => ProcessorLog)
  async createProcessorLog(
    @graphql.Args() args: CreateProcessorLogArgs
  ): Promise<ProcessorLog> {
    return await this.service.createProcessorLog({
      ...args,
      data: {
        ...args.data,

        messageQueue: args.data.messageQueue
          ? {
              connect: args.data.messageQueue,
            }
          : undefined,
      },
    });
  }

  @graphql.Mutation(() => ProcessorLog)
  async updateProcessorLog(
    @graphql.Args() args: UpdateProcessorLogArgs
  ): Promise<ProcessorLog | null> {
    try {
      return await this.service.updateProcessorLog({
        ...args,
        data: {
          ...args.data,

          messageQueue: args.data.messageQueue
            ? {
                connect: args.data.messageQueue,
              }
            : undefined,
        },
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

  @graphql.Mutation(() => ProcessorLog)
  async deleteProcessorLog(
    @graphql.Args() args: DeleteProcessorLogArgs
  ): Promise<ProcessorLog | null> {
    try {
      return await this.service.deleteProcessorLog(args);
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }

  @graphql.ResolveField(() => MessageQueue, {
    nullable: true,
    name: "messageQueue",
  })
  async getMessageQueue(
    @graphql.Parent() parent: ProcessorLog
  ): Promise<MessageQueue | null> {
    const result = await this.service.getMessageQueue(parent.id);

    if (!result) {
      return null;
    }
    return result;
  }
}
import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { MessageQueueServiceBase } from "./base/messageQueue.service.base";

@Injectable()
export class MessageQueueService extends MessageQueueServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

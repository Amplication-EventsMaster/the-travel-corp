import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { NotificationAttemptServiceBase } from "./base/notificationAttempt.service.base";

@Injectable()
export class NotificationAttemptService extends NotificationAttemptServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

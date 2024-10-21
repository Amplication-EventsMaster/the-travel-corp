import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { ProcessorLogServiceBase } from "./base/processorLog.service.base";

@Injectable()
export class ProcessorLogService extends ProcessorLogServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

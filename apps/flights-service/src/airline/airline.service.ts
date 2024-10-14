import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { AirlineServiceBase } from "./base/airline.service.base";

@Injectable()
export class AirlineService extends AirlineServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

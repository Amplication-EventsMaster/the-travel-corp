import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { AirportServiceBase } from "./base/airport.service.base";

@Injectable()
export class AirportService extends AirportServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

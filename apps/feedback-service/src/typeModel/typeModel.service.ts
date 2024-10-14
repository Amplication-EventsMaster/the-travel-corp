import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { TypeModelServiceBase } from "./base/typeModel.service.base";

@Injectable()
export class TypeModelService extends TypeModelServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

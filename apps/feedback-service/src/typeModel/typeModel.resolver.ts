import * as graphql from "@nestjs/graphql";
import { TypeModelResolverBase } from "./base/typeModel.resolver.base";
import { TypeModel } from "./base/TypeModel";
import { TypeModelService } from "./typeModel.service";

@graphql.Resolver(() => TypeModel)
export class TypeModelResolver extends TypeModelResolverBase {
  constructor(protected readonly service: TypeModelService) {
    super(service);
  }
}

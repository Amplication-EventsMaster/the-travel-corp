import * as graphql from "@nestjs/graphql";
import { CompanyResolverBase } from "./base/company.resolver.base";
import { Company } from "./base/Company";
import { CompanyService } from "./company.service";

@graphql.Resolver(() => Company)
export class CompanyResolver extends CompanyResolverBase {
  constructor(protected readonly service: CompanyService) {
    super(service);
  }
}

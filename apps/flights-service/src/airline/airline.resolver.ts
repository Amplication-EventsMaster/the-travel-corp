import * as graphql from "@nestjs/graphql";
import { AirlineResolverBase } from "./base/airline.resolver.base";
import { Airline } from "./base/Airline";
import { AirlineService } from "./airline.service";

@graphql.Resolver(() => Airline)
export class AirlineResolver extends AirlineResolverBase {
  constructor(protected readonly service: AirlineService) {
    super(service);
  }
}

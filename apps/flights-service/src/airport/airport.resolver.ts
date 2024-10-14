import * as graphql from "@nestjs/graphql";
import { AirportResolverBase } from "./base/airport.resolver.base";
import { Airport } from "./base/Airport";
import { AirportService } from "./airport.service";

@graphql.Resolver(() => Airport)
export class AirportResolver extends AirportResolverBase {
  constructor(protected readonly service: AirportService) {
    super(service);
  }
}

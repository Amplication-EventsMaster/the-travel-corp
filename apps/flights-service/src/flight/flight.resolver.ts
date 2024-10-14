import * as graphql from "@nestjs/graphql";
import { FlightResolverBase } from "./base/flight.resolver.base";
import { Flight } from "./base/Flight";
import { FlightService } from "./flight.service";

@graphql.Resolver(() => Flight)
export class FlightResolver extends FlightResolverBase {
  constructor(protected readonly service: FlightService) {
    super(service);
  }
}

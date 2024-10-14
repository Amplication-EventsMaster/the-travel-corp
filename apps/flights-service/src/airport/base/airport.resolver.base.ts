/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as graphql from "@nestjs/graphql";
import { GraphQLError } from "graphql";
import { isRecordNotFoundError } from "../../prisma.util";
import { MetaQueryPayload } from "../../util/MetaQueryPayload";
import { Airport } from "./Airport";
import { AirportCountArgs } from "./AirportCountArgs";
import { AirportFindManyArgs } from "./AirportFindManyArgs";
import { AirportFindUniqueArgs } from "./AirportFindUniqueArgs";
import { CreateAirportArgs } from "./CreateAirportArgs";
import { UpdateAirportArgs } from "./UpdateAirportArgs";
import { DeleteAirportArgs } from "./DeleteAirportArgs";
import { Flight } from "../../flight/base/Flight";
import { AirportService } from "../airport.service";
@graphql.Resolver(() => Airport)
export class AirportResolverBase {
  constructor(protected readonly service: AirportService) {}

  async _airportsMeta(
    @graphql.Args() args: AirportCountArgs
  ): Promise<MetaQueryPayload> {
    const result = await this.service.count(args);
    return {
      count: result,
    };
  }

  @graphql.Query(() => [Airport])
  async airports(
    @graphql.Args() args: AirportFindManyArgs
  ): Promise<Airport[]> {
    return this.service.airports(args);
  }

  @graphql.Query(() => Airport, { nullable: true })
  async airport(
    @graphql.Args() args: AirportFindUniqueArgs
  ): Promise<Airport | null> {
    const result = await this.service.airport(args);
    if (result === null) {
      return null;
    }
    return result;
  }

  @graphql.Mutation(() => Airport)
  async createAirport(
    @graphql.Args() args: CreateAirportArgs
  ): Promise<Airport> {
    return await this.service.createAirport({
      ...args,
      data: {
        ...args.data,

        departureFlights: args.data.departureFlights
          ? {
              connect: args.data.departureFlights,
            }
          : undefined,
      },
    });
  }

  @graphql.Mutation(() => Airport)
  async updateAirport(
    @graphql.Args() args: UpdateAirportArgs
  ): Promise<Airport | null> {
    try {
      return await this.service.updateAirport({
        ...args,
        data: {
          ...args.data,

          departureFlights: args.data.departureFlights
            ? {
                connect: args.data.departureFlights,
              }
            : undefined,
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }

  @graphql.Mutation(() => Airport)
  async deleteAirport(
    @graphql.Args() args: DeleteAirportArgs
  ): Promise<Airport | null> {
    try {
      return await this.service.deleteAirport(args);
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }

  @graphql.ResolveField(() => Flight, {
    nullable: true,
    name: "departureFlights",
  })
  async getDepartureFlights(
    @graphql.Parent() parent: Airport
  ): Promise<Flight | null> {
    const result = await this.service.getDepartureFlights(parent.id);

    if (!result) {
      return null;
    }
    return result;
  }
}

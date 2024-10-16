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
import { Airline } from "./Airline";
import { AirlineCountArgs } from "./AirlineCountArgs";
import { AirlineFindManyArgs } from "./AirlineFindManyArgs";
import { AirlineFindUniqueArgs } from "./AirlineFindUniqueArgs";
import { CreateAirlineArgs } from "./CreateAirlineArgs";
import { UpdateAirlineArgs } from "./UpdateAirlineArgs";
import { DeleteAirlineArgs } from "./DeleteAirlineArgs";
import { FlightFindManyArgs } from "../../flight/base/FlightFindManyArgs";
import { Flight } from "../../flight/base/Flight";
import { AirlineService } from "../airline.service";
@graphql.Resolver(() => Airline)
export class AirlineResolverBase {
  constructor(protected readonly service: AirlineService) {}

  async _airlinesMeta(
    @graphql.Args() args: AirlineCountArgs
  ): Promise<MetaQueryPayload> {
    const result = await this.service.count(args);
    return {
      count: result,
    };
  }

  @graphql.Query(() => [Airline])
  async airlines(
    @graphql.Args() args: AirlineFindManyArgs
  ): Promise<Airline[]> {
    return this.service.airlines(args);
  }

  @graphql.Query(() => Airline, { nullable: true })
  async airline(
    @graphql.Args() args: AirlineFindUniqueArgs
  ): Promise<Airline | null> {
    const result = await this.service.airline(args);
    if (result === null) {
      return null;
    }
    return result;
  }

  @graphql.Mutation(() => Airline)
  async createAirline(
    @graphql.Args() args: CreateAirlineArgs
  ): Promise<Airline> {
    return await this.service.createAirline({
      ...args,
      data: {
        ...args.data,

        arrivalFlights: args.data.arrivalFlights
          ? {
              connect: args.data.arrivalFlights,
            }
          : undefined,
      },
    });
  }

  @graphql.Mutation(() => Airline)
  async updateAirline(
    @graphql.Args() args: UpdateAirlineArgs
  ): Promise<Airline | null> {
    try {
      return await this.service.updateAirline({
        ...args,
        data: {
          ...args.data,

          arrivalFlights: args.data.arrivalFlights
            ? {
                connect: args.data.arrivalFlights,
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

  @graphql.Mutation(() => Airline)
  async deleteAirline(
    @graphql.Args() args: DeleteAirlineArgs
  ): Promise<Airline | null> {
    try {
      return await this.service.deleteAirline(args);
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new GraphQLError(
          `No resource was found for ${JSON.stringify(args.where)}`
        );
      }
      throw error;
    }
  }

  @graphql.ResolveField(() => [Flight], { name: "flights" })
  async findFlights(
    @graphql.Parent() parent: Airline,
    @graphql.Args() args: FlightFindManyArgs
  ): Promise<Flight[]> {
    const results = await this.service.findFlights(parent.id, args);

    if (!results) {
      return [];
    }

    return results;
  }

  @graphql.ResolveField(() => Flight, {
    nullable: true,
    name: "arrivalFlights",
  })
  async getArrivalFlights(
    @graphql.Parent() parent: Airline
  ): Promise<Flight | null> {
    const result = await this.service.getArrivalFlights(parent.id);

    if (!result) {
      return null;
    }
    return result;
  }
}

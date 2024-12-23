/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";
import {
  Prisma,
  Airport as PrismaAirport,
  Flight as PrismaFlight,
} from "@prisma/client";

export class AirportServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(args: Omit<Prisma.AirportCountArgs, "select">): Promise<number> {
    return this.prisma.airport.count(args);
  }

  async airports<T extends Prisma.AirportFindManyArgs>(
    args: Prisma.SelectSubset<T, Prisma.AirportFindManyArgs>
  ): Promise<PrismaAirport[]> {
    return this.prisma.airport.findMany<Prisma.AirportFindManyArgs>(args);
  }
  async airport<T extends Prisma.AirportFindUniqueArgs>(
    args: Prisma.SelectSubset<T, Prisma.AirportFindUniqueArgs>
  ): Promise<PrismaAirport | null> {
    return this.prisma.airport.findUnique(args);
  }
  async createAirport<T extends Prisma.AirportCreateArgs>(
    args: Prisma.SelectSubset<T, Prisma.AirportCreateArgs>
  ): Promise<PrismaAirport> {
    return this.prisma.airport.create<T>(args);
  }
  async updateAirport<T extends Prisma.AirportUpdateArgs>(
    args: Prisma.SelectSubset<T, Prisma.AirportUpdateArgs>
  ): Promise<PrismaAirport> {
    return this.prisma.airport.update<T>(args);
  }
  async deleteAirport<T extends Prisma.AirportDeleteArgs>(
    args: Prisma.SelectSubset<T, Prisma.AirportDeleteArgs>
  ): Promise<PrismaAirport> {
    return this.prisma.airport.delete(args);
  }

  async getDepartureFlights(parentId: string): Promise<PrismaFlight | null> {
    return this.prisma.airport
      .findUnique({
        where: { id: parentId },
      })
      .departureFlights();
  }
}

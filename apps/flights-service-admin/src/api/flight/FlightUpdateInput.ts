import { AirlineWhereUniqueInput } from "../airline/AirlineWhereUniqueInput";
import { AirportWhereUniqueInput } from "../airport/AirportWhereUniqueInput";

export type FlightUpdateInput = {
  airline?: AirlineWhereUniqueInput | null;
  arrivalAirport?: AirlineWhereUniqueInput | null;
  arrivalTime?: Date | null;
  availableSeats?: number | null;
  departureAirport?: AirportWhereUniqueInput | null;
  departureTime?: Date | null;
  flightNumber?: string | null;
};

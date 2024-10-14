import { FlightWhereUniqueInput } from "../flight/FlightWhereUniqueInput";

export type AirportUpdateInput = {
  departureFlights?: FlightWhereUniqueInput | null;
  location?: string | null;
  name?: string | null;
};

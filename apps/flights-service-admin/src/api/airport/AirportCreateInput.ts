import { FlightWhereUniqueInput } from "../flight/FlightWhereUniqueInput";

export type AirportCreateInput = {
  departureFlights?: FlightWhereUniqueInput | null;
  location?: string | null;
  name?: string | null;
};

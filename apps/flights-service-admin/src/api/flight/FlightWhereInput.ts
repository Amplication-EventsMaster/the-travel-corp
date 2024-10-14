import { AirlineWhereUniqueInput } from "../airline/AirlineWhereUniqueInput";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { AirportWhereUniqueInput } from "../airport/AirportWhereUniqueInput";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";

export type FlightWhereInput = {
  airline?: AirlineWhereUniqueInput;
  arrivalAirport?: AirlineWhereUniqueInput;
  arrivalTime?: DateTimeNullableFilter;
  availableSeats?: IntNullableFilter;
  departureAirport?: AirportWhereUniqueInput;
  departureTime?: DateTimeNullableFilter;
  flightNumber?: StringNullableFilter;
  id?: StringFilter;
};

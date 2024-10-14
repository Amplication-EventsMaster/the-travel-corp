import { FlightWhereUniqueInput } from "../flight/FlightWhereUniqueInput";
import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type AirportWhereInput = {
  departureFlights?: FlightWhereUniqueInput;
  id?: StringFilter;
  location?: StringNullableFilter;
  name?: StringNullableFilter;
};

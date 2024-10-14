import { FlightWhereUniqueInput } from "../flight/FlightWhereUniqueInput";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { FlightListRelationFilter } from "../flight/FlightListRelationFilter";
import { StringFilter } from "../../util/StringFilter";

export type AirlineWhereInput = {
  arrivalFlights?: FlightWhereUniqueInput;
  country?: StringNullableFilter;
  flights?: FlightListRelationFilter;
  id?: StringFilter;
  name?: StringNullableFilter;
};

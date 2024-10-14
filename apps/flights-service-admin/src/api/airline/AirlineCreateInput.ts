import { FlightWhereUniqueInput } from "../flight/FlightWhereUniqueInput";
import { FlightCreateNestedManyWithoutAirlinesInput } from "./FlightCreateNestedManyWithoutAirlinesInput";

export type AirlineCreateInput = {
  arrivalFlights?: FlightWhereUniqueInput | null;
  country?: string | null;
  flights?: FlightCreateNestedManyWithoutAirlinesInput;
  name?: string | null;
};

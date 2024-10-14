import { FlightWhereUniqueInput } from "../flight/FlightWhereUniqueInput";
import { FlightUpdateManyWithoutAirlinesInput } from "./FlightUpdateManyWithoutAirlinesInput";

export type AirlineUpdateInput = {
  arrivalFlights?: FlightWhereUniqueInput | null;
  country?: string | null;
  flights?: FlightUpdateManyWithoutAirlinesInput;
  name?: string | null;
};

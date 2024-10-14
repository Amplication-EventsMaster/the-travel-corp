import { AirportWhereUniqueInput } from "./AirportWhereUniqueInput";
import { AirportUpdateInput } from "./AirportUpdateInput";

export type UpdateAirportArgs = {
  where: AirportWhereUniqueInput;
  data: AirportUpdateInput;
};

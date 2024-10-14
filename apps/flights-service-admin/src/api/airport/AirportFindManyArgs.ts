import { AirportWhereInput } from "./AirportWhereInput";
import { AirportOrderByInput } from "./AirportOrderByInput";

export type AirportFindManyArgs = {
  where?: AirportWhereInput;
  orderBy?: Array<AirportOrderByInput>;
  skip?: number;
  take?: number;
};

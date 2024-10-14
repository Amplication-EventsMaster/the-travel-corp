import { AirlineWhereInput } from "./AirlineWhereInput";
import { AirlineOrderByInput } from "./AirlineOrderByInput";

export type AirlineFindManyArgs = {
  where?: AirlineWhereInput;
  orderBy?: Array<AirlineOrderByInput>;
  skip?: number;
  take?: number;
};

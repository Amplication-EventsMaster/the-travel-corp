import { Flight } from "../flight/Flight";

export type Airline = {
  arrivalFlights?: Flight | null;
  country: string | null;
  createdAt: Date;
  flights?: Array<Flight>;
  id: string;
  name: string | null;
  updatedAt: Date;
};

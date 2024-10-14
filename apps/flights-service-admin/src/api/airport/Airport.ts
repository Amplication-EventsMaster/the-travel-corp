import { Flight } from "../flight/Flight";

export type Airport = {
  createdAt: Date;
  departureFlights?: Flight | null;
  id: string;
  location: string | null;
  name: string | null;
  updatedAt: Date;
};

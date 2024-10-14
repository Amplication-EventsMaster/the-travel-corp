import { Airport as TAirport } from "../api/airport/Airport";

export const AIRPORT_TITLE_FIELD = "name";

export const AirportTitle = (record: TAirport): string => {
  return record.name?.toString() || String(record.id);
};

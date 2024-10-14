import { Airline as TAirline } from "../api/airline/Airline";

export const AIRLINE_TITLE_FIELD = "name";

export const AirlineTitle = (record: TAirline): string => {
  return record.name?.toString() || String(record.id);
};

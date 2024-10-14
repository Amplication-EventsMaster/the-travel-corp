import { Flight as TFlight } from "../api/flight/Flight";

export const FLIGHT_TITLE_FIELD = "flightNumber";

export const FlightTitle = (record: TFlight): string => {
  return record.flightNumber?.toString() || String(record.id);
};

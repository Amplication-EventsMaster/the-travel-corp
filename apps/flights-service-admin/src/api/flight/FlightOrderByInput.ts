import { SortOrder } from "../../util/SortOrder";

export type FlightOrderByInput = {
  airlineId?: SortOrder;
  arrivalAirportId?: SortOrder;
  arrivalTime?: SortOrder;
  availableSeats?: SortOrder;
  createdAt?: SortOrder;
  departureAirportId?: SortOrder;
  departureTime?: SortOrder;
  flightNumber?: SortOrder;
  id?: SortOrder;
  updatedAt?: SortOrder;
};

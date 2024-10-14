import { SortOrder } from "../../util/SortOrder";

export type AirportOrderByInput = {
  createdAt?: SortOrder;
  departureFlightsId?: SortOrder;
  id?: SortOrder;
  location?: SortOrder;
  name?: SortOrder;
  updatedAt?: SortOrder;
};

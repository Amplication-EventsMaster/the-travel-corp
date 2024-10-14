import { SortOrder } from "../../util/SortOrder";

export type AirlineOrderByInput = {
  arrivalFlightsId?: SortOrder;
  country?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  name?: SortOrder;
  updatedAt?: SortOrder;
};

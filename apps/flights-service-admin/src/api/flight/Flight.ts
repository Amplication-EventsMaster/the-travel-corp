import { Airline } from "../airline/Airline";
import { Airport } from "../airport/Airport";

export type Flight = {
  airline?: Airline | null;
  arrivalAirport?: Airline | null;
  arrivalTime: Date | null;
  availableSeats: number | null;
  createdAt: Date;
  departureAirport?: Airport | null;
  departureTime: Date | null;
  flightNumber: string | null;
  id: string;
  updatedAt: Date;
};

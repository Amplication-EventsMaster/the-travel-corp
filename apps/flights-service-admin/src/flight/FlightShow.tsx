import * as React from "react";
import {
  Show,
  SimpleShowLayout,
  ShowProps,
  ReferenceField,
  TextField,
  DateField,
} from "react-admin";
import { AIRLINE_TITLE_FIELD } from "../airline/AirlineTitle";
import { AIRPORT_TITLE_FIELD } from "../airport/AirportTitle";

export const FlightShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <ReferenceField label="Airline" source="airline.id" reference="Airline">
          <TextField source={AIRLINE_TITLE_FIELD} />
        </ReferenceField>
        <ReferenceField
          label="ArrivalAirport"
          source="airline.id"
          reference="Airline"
        >
          <TextField source={AIRLINE_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="arrivalTime" source="arrivalTime" />
        <TextField label="availableSeats" source="availableSeats" />
        <DateField source="createdAt" label="Created At" />
        <ReferenceField
          label="DepartureAirport"
          source="airport.id"
          reference="Airport"
        >
          <TextField source={AIRPORT_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="departureTime" source="departureTime" />
        <TextField label="flightNumber" source="flightNumber" />
        <TextField label="ID" source="id" />
        <DateField source="updatedAt" label="Updated At" />
      </SimpleShowLayout>
    </Show>
  );
};

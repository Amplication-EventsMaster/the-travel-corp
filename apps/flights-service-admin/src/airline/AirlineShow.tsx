import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  ReferenceField,
  TextField,
  DateField,
  ReferenceManyField,
  Datagrid,
} from "react-admin";

import { AIRLINE_TITLE_FIELD } from "./AirlineTitle";
import { AIRPORT_TITLE_FIELD } from "../airport/AirportTitle";
import { FLIGHT_TITLE_FIELD } from "../flight/FlightTitle";

export const AirlineShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <ReferenceField
          label="Arrival Flights"
          source="flight.id"
          reference="Flight"
        >
          <TextField source={FLIGHT_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="country" source="country" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <TextField label="name" source="name" />
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceManyField
          reference="Flight"
          target="airlineId"
          label="Flights"
        >
          <Datagrid rowClick="show">
            <ReferenceField
              label="Airline"
              source="airline.id"
              reference="Airline"
            >
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
          </Datagrid>
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};

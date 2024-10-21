import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  ReferenceInput,
  SelectInput,
  DateTimeInput,
  NumberInput,
  TextInput,
} from "react-admin";

import { AirlineTitle } from "../airline/AirlineTitle";
import { AirportTitle } from "../airport/AirportTitle";

export const FlightCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <ReferenceInput source="airline.id" reference="Airline" label="Airline">
          <SelectInput optionText={AirlineTitle} />
        </ReferenceInput>
        <ReferenceInput
          source="arrivalAirport.id"
          reference="Airline"
          label="ArrivalAirport"
        >
          <SelectInput optionText={AirlineTitle} />
        </ReferenceInput>
        <DateTimeInput label="arrivalTime" source="arrivalTime" />
        <NumberInput step={1} label="availableSeats" source="availableSeats" />
        <ReferenceInput
          source="departureAirport.id"
          reference="Airport"
          label="DepartureAirport"
        >
          <SelectInput optionText={AirportTitle} />
        </ReferenceInput>
        <DateTimeInput label="departureTime" source="departureTime" />
        <TextInput label="flightNumber" source="flightNumber" />
      </SimpleForm>
    </Create>
  );
};
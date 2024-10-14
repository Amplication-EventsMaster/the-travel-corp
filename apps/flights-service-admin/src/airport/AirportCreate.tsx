import * as React from "react";
import {
  Create,
  SimpleForm,
  CreateProps,
  ReferenceInput,
  SelectInput,
  TextInput,
} from "react-admin";
import { FlightTitle } from "../flight/FlightTitle";

export const AirportCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <ReferenceInput
          source="departureFlights.id"
          reference="Flight"
          label="Departure Flights"
        >
          <SelectInput optionText={FlightTitle} />
        </ReferenceInput>
        <TextInput label="location" source="location" />
        <TextInput label="name" source="name" />
      </SimpleForm>
    </Create>
  );
};

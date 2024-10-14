import * as React from "react";
import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceInput,
  SelectInput,
  TextInput,
} from "react-admin";
import { FlightTitle } from "../flight/FlightTitle";

export const AirportEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
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
    </Edit>
  );
};

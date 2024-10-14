import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceInput,
  SelectInput,
  TextInput,
  ReferenceArrayInput,
  SelectArrayInput,
} from "react-admin";

import { FlightTitle } from "../flight/FlightTitle";

export const AirlineEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <ReferenceInput
          source="arrivalFlights.id"
          reference="Flight"
          label="Arrival Flights"
        >
          <SelectInput optionText={FlightTitle} />
        </ReferenceInput>
        <TextInput label="country" source="country" />
        <ReferenceArrayInput
          source="flights"
          reference="Flight"
          parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
          format={(value: any) => value && value.map((v: any) => v.id)}
        >
          <SelectArrayInput optionText={FlightTitle} />
        </ReferenceArrayInput>
        <TextInput label="name" source="name" />
      </SimpleForm>
    </Edit>
  );
};

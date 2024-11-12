import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceInput,
  SelectInput,
  DateTimeInput,
  TextInput,
  NumberInput,
} from "react-admin";

import { CustomerTitle } from "../customer/CustomerTitle";

export const OrderEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <ReferenceInput
          source="customer.id"
          reference="Customer"
          label="Customer"
        >
          <SelectInput optionText={CustomerTitle} />
        </ReferenceInput>
        <DateTimeInput label="orderDate" source="orderDate" />
        <TextInput label="orderNumber" source="orderNumber" />
        <NumberInput label="totalAmount" source="totalAmount" />
      </SimpleForm>
    </Edit>
  );
};

import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  TextInput,
  NumberInput,
  ReferenceArrayInput,
  SelectArrayInput,
} from "react-admin";

import { ReviewTitle } from "../review/ReviewTitle";

export const FeedbackCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="Booking" source="booking" />
        <TextInput label="comments" multiline source="comments" />
        <NumberInput step={1} label="rating" source="rating" />
        <TextInput label="remarks" source="remarks" />
        <ReferenceArrayInput source="reviews" reference="Review">
          <SelectArrayInput
            optionText={ReviewTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
      </SimpleForm>
    </Create>
  );
};

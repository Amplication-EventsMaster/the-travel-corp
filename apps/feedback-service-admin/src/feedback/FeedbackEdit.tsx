import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  TextInput,
  NumberInput,
  ReferenceArrayInput,
  SelectArrayInput,
} from "react-admin";

import { ReviewTitle } from "../review/ReviewTitle";

export const FeedbackEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
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
    </Edit>
  );
};

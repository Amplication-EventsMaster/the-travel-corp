import * as React from "react";
import {
  Create,
  SimpleForm,
  CreateProps,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";
import { FeedbackTitle } from "../feedback/FeedbackTitle";
import { TypeModelTitle } from "../typeModel/TypeModelTitle";

export const ReviewCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="content" multiline source="content" />
        <ReferenceInput
          source="feedback.id"
          reference="Feedback"
          label="feedback"
        >
          <SelectInput optionText={FeedbackTitle} />
        </ReferenceInput>
        <TextInput label="title" source="title" />
        <ReferenceInput
          source="typeField.id"
          reference="TypeModel"
          label="type"
        >
          <SelectInput optionText={TypeModelTitle} />
        </ReferenceInput>
      </SimpleForm>
    </Create>
  );
};

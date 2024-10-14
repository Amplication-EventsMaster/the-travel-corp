import * as React from "react";
import {
  Edit,
  SimpleForm,
  EditProps,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";
import { FeedbackTitle } from "../feedback/FeedbackTitle";
import { TypeModelTitle } from "../typeModel/TypeModelTitle";

export const ReviewEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
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
    </Edit>
  );
};

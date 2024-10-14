import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  DateField,
  TextField,
  ReferenceManyField,
  Datagrid,
  ReferenceField,
} from "react-admin";

import { FEEDBACK_TITLE_FIELD } from "../feedback/FeedbackTitle";
import { TYPEMODEL_TITLE_FIELD } from "./TypeModelTitle";

export const TypeModelShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <TextField label="name" source="name" />
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceManyField
          reference="Review"
          target="typeFieldId"
          label="Reviews"
        >
          <Datagrid rowClick="show" bulkActionButtons={false}>
            <TextField label="content" source="content" />
            <DateField source="createdAt" label="Created At" />
            <ReferenceField
              label="feedback"
              source="feedback.id"
              reference="Feedback"
            >
              <TextField source={FEEDBACK_TITLE_FIELD} />
            </ReferenceField>
            <TextField label="ID" source="id" />
            <TextField label="title" source="title" />
            <ReferenceField
              label="type"
              source="typemodel.id"
              reference="TypeModel"
            >
              <TextField source={TYPEMODEL_TITLE_FIELD} />
            </ReferenceField>
            <DateField source="updatedAt" label="Updated At" />
          </Datagrid>
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};

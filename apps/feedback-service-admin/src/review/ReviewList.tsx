import * as React from "react";
import {
  List,
  Datagrid,
  ListProps,
  TextField,
  DateField,
  ReferenceField,
} from "react-admin";
import Pagination from "../Components/Pagination";
import { FEEDBACK_TITLE_FIELD } from "../feedback/FeedbackTitle";
import { TYPEMODEL_TITLE_FIELD } from "../typeModel/TypeModelTitle";

export const ReviewList = (props: ListProps): React.ReactElement => {
  return (
    <List {...props} title={"Reviews"} perPage={50} pagination={<Pagination />}>
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
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};

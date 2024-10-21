import * as React from "react";

import {
  List,
  Datagrid,
  ListProps,
  TextField,
  DateField,
  ReferenceField,
  BooleanField,
} from "react-admin";

import Pagination from "../Components/Pagination";
import { MESSAGEQUEUE_TITLE_FIELD } from "../messageQueue/MessageQueueTitle";

export const NotificationAttemptList = (
  props: ListProps
): React.ReactElement => {
  return (
    <List
      {...props}
      title={"NotificationAttempts"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <TextField label="attemptCount" source="attemptCount" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <ReferenceField
          label="MessageQueue"
          source="messagequeue.id"
          reference="MessageQueue"
        >
          <TextField source={MESSAGEQUEUE_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="result" source="result" />
        <BooleanField label="successful" source="successful" />
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};

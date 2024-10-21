import * as React from "react";
import {
  List,
  Datagrid,
  ListProps,
  DateField,
  TextField,
  ReferenceField,
} from "react-admin";
import Pagination from "../Components/Pagination";
import { MESSAGEQUEUE_TITLE_FIELD } from "../messageQueue/MessageQueueTitle";

export const ProcessorLogList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      title={"ProcessorLogs"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <TextField label="logType" source="logType" />
        <ReferenceField
          label="MessageQueue"
          source="messagequeue.id"
          reference="MessageQueue"
        >
          <TextField source={MESSAGEQUEUE_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="timestamp" source="timestamp" />
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};

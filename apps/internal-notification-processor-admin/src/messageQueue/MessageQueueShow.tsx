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
  BooleanField,
} from "react-admin";

import { MESSAGEQUEUE_TITLE_FIELD } from "./MessageQueueTitle";

export const MessageQueueShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <TextField label="priority" source="priority" />
        <TextField label="queueName" source="queueName" />
        <TextField label="status" source="status" />
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceManyField
          reference="NotificationAttempt"
          target="messageQueueId"
          label="NotificationAttempts"
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
            <DateField source="updatedAt" label="Updated At" />
          </Datagrid>
        </ReferenceManyField>
        <ReferenceManyField
          reference="ProcessorLog"
          target="messageQueueId"
          label="ProcessorLogs"
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
            <DateField source="updatedAt" label="Updated At" />
          </Datagrid>
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};

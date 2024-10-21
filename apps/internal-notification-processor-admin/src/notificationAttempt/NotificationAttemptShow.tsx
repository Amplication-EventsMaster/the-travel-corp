import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
  ReferenceField,
  BooleanField,
} from "react-admin";

import { MESSAGEQUEUE_TITLE_FIELD } from "../messageQueue/MessageQueueTitle";

export const NotificationAttemptShow = (
  props: ShowProps
): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
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
      </SimpleShowLayout>
    </Show>
  );
};

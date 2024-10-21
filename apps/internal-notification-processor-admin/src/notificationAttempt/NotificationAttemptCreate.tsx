import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  NumberInput,
  ReferenceInput,
  SelectInput,
  TextInput,
  BooleanInput,
} from "react-admin";

import { MessageQueueTitle } from "../messageQueue/MessageQueueTitle";

export const NotificationAttemptCreate = (
  props: CreateProps
): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <NumberInput step={1} label="attemptCount" source="attemptCount" />
        <ReferenceInput
          source="messageQueue.id"
          reference="MessageQueue"
          label="MessageQueue"
        >
          <SelectInput optionText={MessageQueueTitle} />
        </ReferenceInput>
        <TextInput label="result" multiline source="result" />
        <BooleanInput label="successful" source="successful" />
      </SimpleForm>
    </Create>
  );
};

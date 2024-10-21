import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  TextInput,
  ReferenceArrayInput,
  SelectArrayInput,
  NumberInput,
  SelectInput,
} from "react-admin";

import { NotificationAttemptTitle } from "../notificationAttempt/NotificationAttemptTitle";
import { ProcessorLogTitle } from "../processorLog/ProcessorLogTitle";

export const MessageQueueCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="comment" source="comment" />
        <ReferenceArrayInput
          source="notificationAttempts"
          reference="NotificationAttempt"
        >
          <SelectArrayInput
            optionText={NotificationAttemptTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <NumberInput step={1} label="priority" source="priority" />
        <ReferenceArrayInput source="processorLogs" reference="ProcessorLog">
          <SelectArrayInput
            optionText={ProcessorLogTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <TextInput label="queueName" source="queueName" />
        <SelectInput
          source="status"
          label="status"
          choices={[{ label: "Option 1", value: "Option1" }]}
          optionText="label"
          allowEmpty
          optionValue="value"
        />
      </SimpleForm>
    </Create>
  );
};

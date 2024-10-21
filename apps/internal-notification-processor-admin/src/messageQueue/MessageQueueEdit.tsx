import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceArrayInput,
  SelectArrayInput,
  NumberInput,
  TextInput,
  SelectInput,
} from "react-admin";

import { NotificationAttemptTitle } from "../notificationAttempt/NotificationAttemptTitle";
import { ProcessorLogTitle } from "../processorLog/ProcessorLogTitle";

export const MessageQueueEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
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
    </Edit>
  );
};

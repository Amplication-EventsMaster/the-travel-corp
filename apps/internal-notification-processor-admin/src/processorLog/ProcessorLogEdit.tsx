import * as React from "react";
import {
  Edit,
  SimpleForm,
  EditProps,
  SelectInput,
  ReferenceInput,
  DateTimeInput,
} from "react-admin";
import { MessageQueueTitle } from "../messageQueue/MessageQueueTitle";

export const ProcessorLogEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <SelectInput
          source="logType"
          label="logType"
          choices={[{ label: "Option 1", value: "Option1" }]}
          optionText="label"
          allowEmpty
          optionValue="value"
        />
        <ReferenceInput
          source="messageQueue.id"
          reference="MessageQueue"
          label="MessageQueue"
        >
          <SelectInput optionText={MessageQueueTitle} />
        </ReferenceInput>
        <DateTimeInput label="timestamp" source="timestamp" />
      </SimpleForm>
    </Edit>
  );
};

import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  ReferenceArrayInput,
  SelectArrayInput,
  TextInput,
} from "react-admin";

import { ApiKeyTitle } from "../apiKey/ApiKeyTitle";
import { CredentialTitle } from "../credential/CredentialTitle";
import { WebhookTitle } from "../webhook/WebhookTitle";

export const AppModelCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <ReferenceArrayInput source="apiKey" reference="ApiKey">
          <SelectArrayInput
            optionText={ApiKeyTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <SelectArrayInput
          label="Categories"
          source="categories"
          choices={[
            { label: "calendar", value: "calendar" },
            { label: "messaging", value: "messaging" },
            { label: "other", value: "other" },
            { label: "payment", value: "payment" },
            { label: "video", value: "video" },
            { label: "web3", value: "web3" },
          ]}
          optionText="label"
          optionValue="value"
        />
        <ReferenceArrayInput source="credentials" reference="Credential">
          <SelectArrayInput
            optionText={CredentialTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <TextInput label="Dir Name" source="dirName" />
        <div />
        <ReferenceArrayInput source="webhook" reference="Webhook">
          <SelectArrayInput
            optionText={WebhookTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
      </SimpleForm>
    </Create>
  );
};

import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { MessageQueueList } from "./messageQueue/MessageQueueList";
import { MessageQueueCreate } from "./messageQueue/MessageQueueCreate";
import { MessageQueueEdit } from "./messageQueue/MessageQueueEdit";
import { MessageQueueShow } from "./messageQueue/MessageQueueShow";
import { NotificationAttemptList } from "./notificationAttempt/NotificationAttemptList";
import { NotificationAttemptCreate } from "./notificationAttempt/NotificationAttemptCreate";
import { NotificationAttemptEdit } from "./notificationAttempt/NotificationAttemptEdit";
import { NotificationAttemptShow } from "./notificationAttempt/NotificationAttemptShow";
import { ProcessorLogList } from "./processorLog/ProcessorLogList";
import { ProcessorLogCreate } from "./processorLog/ProcessorLogCreate";
import { ProcessorLogEdit } from "./processorLog/ProcessorLogEdit";
import { ProcessorLogShow } from "./processorLog/ProcessorLogShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"Internal Notification Processor"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="MessageQueue"
          list={MessageQueueList}
          edit={MessageQueueEdit}
          create={MessageQueueCreate}
          show={MessageQueueShow}
        />
        <Resource
          name="NotificationAttempt"
          list={NotificationAttemptList}
          edit={NotificationAttemptEdit}
          create={NotificationAttemptCreate}
          show={NotificationAttemptShow}
        />
        <Resource
          name="ProcessorLog"
          list={ProcessorLogList}
          edit={ProcessorLogEdit}
          create={ProcessorLogCreate}
          show={ProcessorLogShow}
        />
      </Admin>
    </div>
  );
};

export default App;

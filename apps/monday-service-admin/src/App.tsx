import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { CustomerList } from "./customer/CustomerList";
import { CustomerCreate } from "./customer/CustomerCreate";
import { CustomerEdit } from "./customer/CustomerEdit";
import { CustomerShow } from "./customer/CustomerShow";
import { OrderList } from "./order/OrderList";
import { OrderCreate } from "./order/OrderCreate";
import { OrderEdit } from "./order/OrderEdit";
import { OrderShow } from "./order/OrderShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"monday service"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="Customer"
          list={CustomerList}
          edit={CustomerEdit}
          create={CustomerCreate}
          show={CustomerShow}
        />
        <Resource
          name="Order"
          list={OrderList}
          edit={OrderEdit}
          create={OrderCreate}
          show={OrderShow}
        />
      </Admin>
    </div>
  );
};

export default App;

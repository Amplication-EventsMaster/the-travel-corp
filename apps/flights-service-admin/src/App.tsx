import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import buildGraphQLProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { AirlineList } from "./airline/AirlineList";
import { AirlineCreate } from "./airline/AirlineCreate";
import { AirlineEdit } from "./airline/AirlineEdit";
import { AirlineShow } from "./airline/AirlineShow";
import { AirportList } from "./airport/AirportList";
import { AirportCreate } from "./airport/AirportCreate";
import { AirportEdit } from "./airport/AirportEdit";
import { AirportShow } from "./airport/AirportShow";
import { FlightList } from "./flight/FlightList";
import { FlightCreate } from "./flight/FlightCreate";
import { FlightEdit } from "./flight/FlightEdit";
import { FlightShow } from "./flight/FlightShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  const [dataProvider, setDataProvider] = useState<DataProvider | null>(null);
  useEffect(() => {
    buildGraphQLProvider
      .then((provider: any) => {
        setDataProvider(() => provider);
      })
      .catch((error: any) => {
        console.log(error);
      });
  }, []);
  if (!dataProvider) {
    return <div>Loading</div>;
  }
  return (
    <div className="App">
      <Admin
        title={"Flights Service"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="Airline"
          list={AirlineList}
          edit={AirlineEdit}
          create={AirlineCreate}
          show={AirlineShow}
        />
        <Resource
          name="Airport"
          list={AirportList}
          edit={AirportEdit}
          create={AirportCreate}
          show={AirportShow}
        />
        <Resource
          name="Flight"
          list={FlightList}
          edit={FlightEdit}
          create={FlightCreate}
          show={FlightShow}
        />
      </Admin>
    </div>
  );
};

export default App;

import React, { Component, useEffect, useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { Button, Card, CardBody, CardHeader, Col, Container, Row } from "reactstrap";
import ContactTable from './components/ContactTable';
/*
export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
    );
  }
}
*/

const App = () => {

    const [contacts, setcontacts] = useState([]);

    const ShowContacts = async () => {
        const res = await fetch("/IdUser/2");
        if (res.ok) {
            const data = await res.json();
            setcontacts(data)
        } else {
            console.log("no data :(");
        }
    }

    useEffect(() => {
        ShowContacts()
    },[])

    return (
        <Container> 
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5> List of Contacts</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success"> New Contact</Button>
                            <hr></hr>
                            <ContactTable data={contacts} />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </Container>
        )
}

export default App;
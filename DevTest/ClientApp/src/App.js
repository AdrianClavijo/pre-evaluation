import React, { Component, useEffect, useState } from 'react';
import { Button, Card, CardBody, CardHeader, Col, Container, Row } from "reactstrap";
import ContactTable from './components/ContactTable';
import ContactModal from './components/modals/ContactModal';

const App = () => {

    const [contacts, setcontacts] = useState([]);
    const [ShowModal, SetModal] = useState(false);


    const ShowContacts = async () => {
        const res = await fetch("/IdUser/IdContact/2");
        if (res.ok) {
            const data = await res.json();
            setcontacts(data)
        } else {
        }
    }

    useEffect(() => {
        ShowContacts()
    },[])


    const SaveContact = async (Contact) => {

        const res = await fetch("/", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(Contact)
        })

        if (res.ok) {
            ShowModal(!SetModal);
            ShowContacts()
        }
    }

    return (
        <Container> 
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5> List of Contacts</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success"
                                onClick={() => ShowModal(!this.SetModal)}
                            > New Contact</Button>
                            <hr></hr>
                            <ContactTable data={contacts} />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ContactModal
                setModal={SetModal}  
                showModal={ShowModal}  
                saveContact={SaveContact}
            />
        </Container>
        )
}

export default App;
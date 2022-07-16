import { useState } from "react"

import { Modal, ModalBody, ModalHeader, ModalFooter, Form, FormGroup, Input, Button, Label } from "reactstrap"

const ContactM = {
    IdUser : 2,
    Name: "",
    Email:""
}


const ContactModal = ({showModal,setModal}) => {

    const [Contact, SetContact] = useState(ContactM);

    const update = (e) => {
        console.log(Contact);
        SetContact(
            {
                ...Contact,
                [e.target.name]: e.target.value
            }
        )
    }

    const sendData = () => {
        if (Contact.IdUser == 2) {
            saveContact(Contact)
        }
    }

    const saveContact = async (Contact) => {

        const res = await fetch("/Save", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(Contact)
        })

        if (res.ok) {
            console.log(Contact);
            //ShowModal(!SetModal);
            //ShowContacts()
        }
    }
    return (
        <Modal isOpen={true}>
            <ModalHeader>
                New Contact
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label> Name </Label>
                        <Input name="Name" onChange={(e) => update(e)} value={Contact.name}/>
                    </FormGroup>
                    <FormGroup>
                        <Label> Email </Label>
                        <Input name="Email" onChange={(e) => update(e)} value={Contact.email}/>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" onClick={sendData}> Save </Button>
                <Button color="danger" size="sm" onClick={() => setModal(!showModal) } > Close </Button>
                </ModalFooter>
        </Modal>
        )
}

export default ContactModal;
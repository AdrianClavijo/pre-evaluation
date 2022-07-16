import { Modal } from "bootstrap"
import { } from "reactstrap"

const UserModal = () => {
    return (
        <Modal isOpen={true}>
            <ModalHeader>
                New Contact
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <label> FullName </label>
                        <Input />
                    </FormGroup>
                    <FormGroup>
                        <label> Username </label>
                        <Input />
                    </FormGroup>
                    <FormGroup>
                        <label type="password"> Password </label>
                        <Input />
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm"> Save </Button>
                <Button color="danger" size="sm"> Close </Button>
            </ModalFooter>
        </Modal>
        )
}

export default UserModal;
import { Button, Table } from "reactstrap";
const ContactTable = ({ data }) => {
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="3"> No Contacts </td>
                        </tr>
                    ) : (
                            data.map((item) => (
                                <tr key={item.IdUser}>
                                    <td>{item.name}</td>
                                    <td>{item.email}</td>
                                    <td>
                                        <Button color="primary" size="sm" className="me-2">Edit</Button>
                                        <Button color="danger" size="sm">Delete</Button>
                                    </td>
                                </tr>
                                )
                            )
                        )
                }
            </tbody>
        </Table>
        )
}
export default ContactTable;
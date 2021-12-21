import React, { Component } from 'react';
import axios from "axios"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBook, faEdit, faEye, faPlus } from '@fortawesome/free-solid-svg-icons';
import { Button, Table } from "react-bootstrap";
import * as moment from 'moment'
import { Link } from "react-router-dom";

export default class BooksList extends Component {
    static displayName = BooksList.name;

    constructor(props) {
        super(props);
        this.state = { books: [], loading: true };
    }

    componentDidMount() {
        this.populateBooks();
    }

    static renderBooksTable(books) {
        return (
            <>
                <div className="container">
                    <div className="card o-hidden border-0 shadow-lg my-5">
                        <div className="card-body p-0">
                            <div className="row">
                                <div className="col-lg-10 m-5">
                                    <div className="d-sm-flex align-items-center justify-content-center mb-4">
                                        <h1 className="h3 mb-0 text-gray-800 float-left">
                                            {" "}
                                            <FontAwesomeIcon icon={faBook}/> Books List
                                        </h1>
                               
                                    </div>
                                    <Table warn className="table-sm" striped hover bordered responsive>
                                        <thead>
                                            <th>#ID</th>
                                            <th>Book Name</th>
                                            <th>Release Date</th>
                                            <th>Price</th>
                                            <th>
                                             
                                            </th>
                                        </thead>
                                        <tbody>
                                            {
                                                books.map(book => {
                                                    return (
                                                        <tr key={book.bookId}>
                                                            <td>{book.bookId}</td>
                                                            <td>{book.bookName}</td>
                                                            <td>{moment(new Date(book.releaseDate)).format("DD/MM/YYYY")}</td>
                                                            <td>{book.price} $</td>
                                                            <td>
                                                                <Link to={`/admin/books/${book.bookId}/detail`}
                                                                    className="btn btn-primary">
                                                                    <FontAwesomeIcon icon={faEye} />
                                                                </Link>{" "}
                                                                <Link to={`/admin/books/${book.bookId}/edit`}
                                                                    className="btn btn-success">
                                                                    <FontAwesomeIcon icon={faEdit} />
                                                                </Link>
                                                             
                                                            </td>
                                                        </tr>
                                                    )
                                                })
                                            }
                                        </tbody>
                                    </Table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BooksList.renderBooksTable(this.state.books);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateBooks() {
        const response = await axios.get('https://localhost:7069/books');
        const { data } = await response;
        this.setState({ books: data, loading: false });
    }
}

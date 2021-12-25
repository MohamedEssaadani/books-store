import React, { Component } from 'react';
import axios from "axios"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBook, faEdit, faEye } from '@fortawesome/free-solid-svg-icons';
import { Table } from "react-bootstrap";
import * as moment from 'moment'
import { Link } from "react-router-dom";

export default class AuthorsList extends Component {
    static displayName = AuthorsList.name;

    constructor(props) {
        super(props);
        this.state = { authors: [], loading: true };
    }

    componentDidMount() {
        this.populateAuthors();
    }

    static renderAuthorsTable(authors) {
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
                                            <FontAwesomeIcon icon={faBook} /> Authors List
                                        </h1>

                                    </div>
                                    <Table warn className="table-sm" striped hover bordered responsive>
                                        <thead>
                                            <th>#ID</th>
                                            <th>Author Name</th>
                                            <th>

                                            </th>
                                        </thead>
                                        <tbody>
                                            {
                                                authors.map(author => {
                                                    return (
                                                        <tr key={author.authorId}>
                                                            <td>{author.authorId}</td>
                                                            <td>{author.authorName}</td>
                                                            <td>
                                                                <Link to={`/admin/authors/${author.authorId}/detail`}
                                                                    className="btn btn-primary">
                                                                    <FontAwesomeIcon icon={faEye} />
                                                                </Link>{" "}
                                                                <Link to={`/admin/authors/${author.authorId}/edit`}
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
            : AuthorsList.renderAuthorsTable(this.state.authors);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateAuthors() {
        const response = await axios.get('https://localhost:7069/api/authors');
        const { data } = await response;
        this.setState({ authors: data, loading: false });

    }
}

import React, { Component } from 'react';
import axios from "axios"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBook, faEdit, faEye } from '@fortawesome/free-solid-svg-icons';
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";

export default class CategoriesList extends Component {
    static displayName = CategoriesList.name;

    constructor(props) {
        super(props);
        this.state = { categories: [], loading: true };
    }

    componentDidMount() {
        this.populateCategories();
    }

    static renderCategoriesTable(categories) {
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
                                            <FontAwesomeIcon icon={faBook} /> Categories List
                                        </h1>

                                    </div>
                                    <Table warn className="table-sm" striped hover bordered responsive>
                                        <thead>
                                            <th>#ID</th>
                                            <th>Category Name</th>
                                            <th>

                                            </th>
                                        </thead>
                                        <tbody>
                                            {
                                                categories.map(category => {
                                                    return (
                                                        <tr key={category.categoryId}>
                                                            <td>{category.categoryId}</td>
                                                            <td>{category.categoryName}</td>
                                                            <td>
                                                                <Link to={`/admin/categories/${category.categoryId}/detail`}
                                                                    className="btn btn-primary">
                                                                    <FontAwesomeIcon icon={faEye} />
                                                                </Link>{" "}
                                                                <Link to={`/admin/categories/${category.categoryId}/edit`}
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
            : CategoriesList.renderCategoriesTable(this.state.categories);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateCategories() {
        const response = await axios.get('https://localhost:7069/api/categories');
        const { data } = await response;
        this.setState({ categories: data, loading: false });
    }
}

import * as React from 'react';
import {Link} from 'react-router-dom'
import {Dropdown} from "react-bootstrap";
import {LinkContainer} from "react-router-bootstrap";
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome'
import {
    faBook,
    faChartArea,
    faList,
    faPlus, faTabletAlt,
    faUser,
    faUsers
} from '@fortawesome/free-solid-svg-icons'

export function Sidebar() {
    return (
        <>
            <ul
                className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion"
                id="accordionSidebar"
            >
                <a className="sidebar-brand d-flex align-items-center justify-content-center">
                    <div className="sidebar-brand-icon rotate-n-15">
                        <FontAwesomeIcon icon={faBook}/>
                    </div>
                    <div className="sidebar-brand-text mx-3">Books Store</div>
                </a>

                <hr className="sidebar-divider"/>

                <div className="sidebar-heading">Books Management</div>

                <Dropdown className="nav-item">
                    <Dropdown.Toggle className="nav-link myDrop">
                        <FontAwesomeIcon icon={faBook} />
                        {" "}Books
                    </Dropdown.Toggle>

                    <Dropdown.Menu>
                        <LinkContainer to={"/admin/books"}>
                            <Dropdown.Item>
                                <FontAwesomeIcon icon={faBook} />
                                {" "}<span>Books</span>
                            </Dropdown.Item>
                        </LinkContainer>
                        <LinkContainer to={"/admin/new-customer"}>
                            <Dropdown.Item>
                                <FontAwesomeIcon icon={faPlus}/>
                                {" "}<span>New Book</span>
                            </Dropdown.Item>
                        </LinkContainer>
                    </Dropdown.Menu>
                </Dropdown>

                <hr className="sidebar-divider"/>

                <div className="sidebar-heading">Categories Management</div>
                <Dropdown className="nav-item">
                    <Dropdown.Toggle className="nav-link myDrop">
                        <FontAwesomeIcon icon={faList}/>
                        {" "}Categories
                    </Dropdown.Toggle>

                    <Dropdown.Menu>
                        <LinkContainer to={"/admin/accounts"}>
                            <Dropdown.Item>
                                <FontAwesomeIcon icon={faList} />
                                {" "}<span>Categories</span>
                            </Dropdown.Item>
                        </LinkContainer>
                        <LinkContainer to={"/admin/new-account"}>
                            <Dropdown.Item>
                                <FontAwesomeIcon icon={faPlus}/>
                                {" "}<span>New Category</span>
                            </Dropdown.Item>
                        </LinkContainer>
                    </Dropdown.Menu>
                </Dropdown>

                <div className="sidebar-heading">Authors Management</div>
                <Dropdown className="nav-item">
                    <Dropdown.Toggle className="nav-link myDrop">
                        <FontAwesomeIcon icon={faUsers} />
                        {" "}Authors
                    </Dropdown.Toggle>

                    <Dropdown.Menu>
                        <LinkContainer to={"/admin/accounts"}>
                            <Dropdown.Item>
                                <FontAwesomeIcon icon={faUsers} />
                                {" "}<span>Authors</span>
                            </Dropdown.Item>
                        </LinkContainer>
                        <LinkContainer to={"/admin/new-account"}>
                            <Dropdown.Item>
                                <FontAwesomeIcon icon={faPlus} />
                                {" "}<span>New Author</span>
                            </Dropdown.Item>
                        </LinkContainer>
                    </Dropdown.Menu>
                </Dropdown>
            </ul>
        </>
    )
        ;
}
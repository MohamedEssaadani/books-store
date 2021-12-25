import {Sidebar} from "./components/Sidebar";
import {BrowserRouter as Router, Switch, Route} from "react-router-dom";
import {Dropdown} from "react-bootstrap";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import { faPlus, faSignOutAlt, faUser, faUsers } from "@fortawesome/free-solid-svg-icons";
import BooksList from "./components/books/BooksList";
import AuthorsList from "./components/authors/AuthorsList";
import CategoriesList from "./components/categories/CategoriesList";

function App() {
    return (
        <div className="App">
            <Router>
                <div id="wrapper">
                    <Sidebar/>
                    <div id="content-wrapper" className="d-flex flex-column">
                        <div id="content">
                            <nav className="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">
                                <button
                                    id="sidebarToggleTop"
                                    className="btn btn-link d-md-none rounded-circle mr-3"
                                >
                                    <i className="fa fa-bars"></i>
                                </button>

                                <ul className="navbar-nav ml-auto">
                                    <li className="d-inline-block ml-auto ml-md-3 my-2 my-md-0 mw-100 pt-2">
                                        <Dropdown className="nav-item">
                                            <Dropdown.Toggle className="btn btn-default"
                                                             style={{backgroundColor: "white", color: "black"}}>
                                                <FontAwesomeIcon icon={faUser}/>
                                                {" ES-SAADANI Mohamed"}
                                            </Dropdown.Toggle>

                                            <Dropdown.Menu>
                                                <Dropdown.Item
                                                >
                                                    <FontAwesomeIcon icon={faUser}/>
                                                    {" "}<span> Profil</span>
                                                </Dropdown.Item>
                                                <Dropdown.Item >
                                                    <FontAwesomeIcon icon={faSignOutAlt}/>
                                                    {" "}<span> Déconnecter</span>
                                                </Dropdown.Item>
                                            </Dropdown.Menu>
                                        </Dropdown>

                                    </li>
                                </ul>
                            </nav>
                            <Switch>
                                <Route path="/" exact component={BooksList} />
                                <Route path="/admin/books" exact component={BooksList} />
                                <Route path="/admin/authors" exact component={AuthorsList} />
                                <Route path="/admin/categories" exact component={CategoriesList} />
                            </Switch>
                        </div>
                    </div>
                </div>
            </Router>
        </div>
    )
        ;
}

export default App;

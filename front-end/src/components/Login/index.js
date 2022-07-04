import React, {useState} from "react";

import {Button} from "react-bootstrap";
import "./styles.css";
import {SignInButton} from "../MSAuth/SignInButton";
import login from "../../queries/login";
import {useNavigate} from "react-router-dom";

function Login() {
    // React States
    const [errorMessages, setErrorMessages] = useState({});
    const [uname, setUname] = useState('');
    const [pass, setPass] = useState('');

    const errors = {
        uname: "Pseudo ou adresse mail incorrect",
        pass: "Mot de passe incorrect"
    };

    const handleSubmit = (event) => {
        //Prevent page reload
        event.preventDefault();
    };

    // Generate JSX code for error message
    const renderErrorMessage = (name) =>
        name === errorMessages.name && (
            <div className="error">{errorMessages.message}</div>
        );

    let navigate = useNavigate();
    const redirectGame = () => {
        navigate('../game', {replace: false});
    }

    const loginUser = () => {
        login({
            uname,
            pass
        }).then((res) => {
            switch (res.status) {
                case 200:
                    console.log("Succes")
                    redirectGame();
                    break;
                case 401:
                    // Invalid password
                    setErrorMessages({name: "pass", message: errors.pass});
                    break;
                case 404:
                    // Username not found
                    setErrorMessages({name: "uname", message: errors.uname});
                    break;
                default:
                    console.log("Another code", res.status)
                    break;
            }
        });
    }
    // JSX code for login form
    const renderForm = (
        <div className="form">
            <form onSubmit={handleSubmit}>
                <div className="input-container">
                    <label>Pseudo ou adresse mail </label>
                    <input type="text" name="uname" onChange={(e) => setUname(e.target.value)} required/>
                    {renderErrorMessage("uname")}
                </div>
                <div className="input-container">
                    <label>Mot de passe </label>
                    <input type="password" name="pass" onChange={(e) => setPass(e.target.value)} required/>
                    {renderErrorMessage("pass")}
                </div>
                <div className="button-container">
                    <Button variant="primary" type="submit" onClick={loginUser}>Se connecter</Button>
                </div>
            </form>
        </div>
    );

    return (
        <div className="app">
            <div className="login-form">
                <div className="title">S'identifier</div>
                {renderForm}
                <hr/>
                <div className="button-container">
                    <SignInButton text={'Se connecter avec Microsoft'}/>
                </div>
                <hr/>
                <p>
                    Vous n'avez pas encore de compte ?
                    <br/>
                    <a className="button-container" href="/signup">S'inscrire maintenant</a>
                </p>

            </div>
        </div>
    );
}

export default Login;
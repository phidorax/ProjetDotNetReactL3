import React, {useState} from "react";

import {Button} from "react-bootstrap";
import "./styles.css";
import {SignInButton} from "../MSAuth/SignInButton";
import login from "../../queries/login";

function Login() {
    // React States
    const [errorMessages, setErrorMessages] = useState({});
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [uname, setUname] = useState('');
    const [pass, setPass] = useState('');


    // User Login info
    const database = [
        {
            username: "user1",
            password: "pass1"
        },
        {
            username: "user2",
            password: "pass2"
        }
    ];

    const errors = {
        uname: "Pseudo ou adresse mail incorrect",
        pass: "Mot de passe"
    };

    const handleSubmit = (event) => {
        //Prevent page reload
        event.preventDefault();

        var {uname, pass} = document.forms[0];

        // Find user login info
        const userData = database.find((user) => user.username === uname.value);

        // Compare user info
        if (userData) {
            if (userData.password !== pass.value) {
                // Invalid password
                setErrorMessages({name: "pass", message: errors.pass});
            } else {
                setIsSubmitted(true);
            }
        } else {
            // Username not found
            setErrorMessages({name: "uname", message: errors.uname});
        }
    };

    // Generate JSX code for error message
    const renderErrorMessage = (name) =>
        name === errorMessages.name && (
            <div className="error">{errorMessages.message}</div>
        );

    const loginUser = () => {
        login({
            uname,
            pass
        });
    }
    // JSX code for login form
    const renderForm = (
        <div className="form">
            <form onSubmit={handleSubmit}>
                <div className="input-container">
                    <label>Pseudo ou adresse mail </label>
                    <input type="text" name="uname" required/>
                    {renderErrorMessage("uname")}
                </div>
                <div className="input-container">
                    <label>Mot de passe </label>
                    <input type="password" name="pass" required/>
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
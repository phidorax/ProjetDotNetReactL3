import React, {useState} from "react";

import {Button} from "react-bootstrap";
import "./styles.css";
import {SignInButton} from "../MSAuth/SignInButton";
import signup from "../../queries/signup";

function SignUp() {
    const [email, setEmail] = useState('');
    const [pseudo, setPseudo] = useState('');
    const [nom, setNom] = useState('');
    const [prenom, setPrenom] = useState('');
    const [password, setPassword] = useState('');

    const addUser = () => {
        signup({
            email,
            pseudo,
            nom,
            prenom,
            password
        });
    }

    return (
        <div className="app">
            <div className="login-form">
                <div className="title">S'inscrire</div>
                <div className="form">
                        <div className="input-container">
                            <label>Pseudo</label>
                            <input type="text" name="pseudo" onChange={(e) => setPseudo(e.target.value)}  required/>
                        </div>
                        <div className="input-container">
                            <label>Nom</label>
                            <input type="text" name="nom" onChange={(e) => setNom(e.target.value)}/>
                        </div>
                        <div className="input-container">
                            <label>Prénom</label>
                            <input type="text" name="prenom" onChange={(e) => setPrenom(e.target.value)}/>
                        </div>
                        <div className="input-container">
                            <label>Adresse mail</label>
                            <input type="text" name="email" onChange={(e) => setEmail(e.target.value)} required/>
                        </div>
                        <div className="input-container">
                            <label>Mot de passe </label>
                            <input type="password" name="password" onChange={(e) => setPassword(e.target.value)} required/>
                        </div>
                        <div className="button-container">
                            <Button variant="primary" type="submit" onClick={addUser} >S'inscrire</Button>
                        </div>
                </div>
                <hr/>
                <div className="button-container">
                    <SignInButton text={"S'inscrire avec Microsoft"}/>
                </div>
                <hr/>
                <div>
                    <p className="account-container">Vous avez un compte ?</p>
                    <a className="account-container" href="/login">S'identifier maintenant</a>
                </div>
            </div>
        </div>
    );
}

export default SignUp;
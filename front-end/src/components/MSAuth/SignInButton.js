import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "./authConfig";
import Button from "react-bootstrap/Button";
import MicrosoftIcon from "./MicrosoftIcon";
import {useNavigate} from "react-router-dom";

function handleLogin(instance, navigate) {
    instance.loginPopup(loginRequest).catch(e => {
        console.error(e);
    }).finally(()=>{
        navigate('../check/ms', {replace: false});
    });
}

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButton = ({ text }) => {
    const { instance } = useMsal();
    let navigate = useNavigate();

    return (
        <Button variant="dark" className="ml-auto" onClick={() => handleLogin(instance, navigate)}><MicrosoftIcon/> {text}</Button>
    );
}
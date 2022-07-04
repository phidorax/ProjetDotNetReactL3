import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "./authConfig";
import Button from "react-bootstrap/Button";
import MicrosoftIcon from "./MicrosoftIcon";

function handleLogin(instance) {
    instance.loginPopup(loginRequest).catch(e => {
        console.error(e);
    }).finally(()=>{console.log("Finally")});
}

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButton = ({ text }) => {
    const { instance } = useMsal();

    return (
        <Button variant="dark" className="ml-auto" onClick={() => handleLogin(instance)}><MicrosoftIcon/> {text}</Button>
    );
}
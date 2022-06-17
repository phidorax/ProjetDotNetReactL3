import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "./authConfig";
import Button from "react-bootstrap/Button";
import MicrosoftIcon from "./MicrosoftIcon";

function handleLogin(instance) {
    instance.loginRedirect(loginRequest).catch(e => {
        console.error(e);
    });
}

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButton = () => {
    const { instance } = useMsal();

    return (
        <Button variant="dark" startIcon={<MicrosoftIcon/>} className="ml-auto" onClick={() => handleLogin(instance)}>Se connecter avec Microsoft</Button>
    );
}
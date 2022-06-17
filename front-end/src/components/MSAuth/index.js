import React from "react";
import {AuthenticatedTemplate, UnauthenticatedTemplate} from "@azure/msal-react";
import { SignInButton } from "./SignInButton";
import { SignOutButton } from "./SignOutButton";
import ProfileContent from "./ProfileContent";

/**
 * Renders the navbar component with a sign-in button if a user is not authenticated
 */
export default function MSAuth() {

    return (
        <div>
            <AuthenticatedTemplate>
                <p>You are signed in!</p>
                <ProfileContent/>
                <SignOutButton/>
            </AuthenticatedTemplate>
            <UnauthenticatedTemplate>
                <p>You are not signed in! Please sign in.</p>
                <SignInButton/>
            </UnauthenticatedTemplate>
        </div>
    );
}
/*

    const isAuthenticated = useIsAuthenticated();

    return (
        <>
            <Navbar bg="primary" variant="dark">
                <a className="navbar-brand" href="/">MSAL React Tutorial</a>
                { isAuthenticated ? <SignOutButton /> : <SignInButton /> }
            </Navbar>
            <h5><center>Welcome to the Microsoft Authentication Library For React Tutorial</center></h5>
            <br />
            <br />
            {props.children}
        </>
    );
};*/

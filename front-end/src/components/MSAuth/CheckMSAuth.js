import React, {useEffect, useState} from "react";
import {useIsAuthenticated, useMsal} from "@azure/msal-react";
import {loginRequest} from "./authConfig";
import {callMsGraph} from "./graph";
import {useNavigate} from "react-router-dom";
import microsoft from "../../queries/microsoft";

export function CheckMSAuth() {
    const {instance, accounts} = useMsal();
    const isAuthenticated = useIsAuthenticated();
    const navigate = useNavigate();

    function RequestProfileData() {
        const request = {
            ...loginRequest,
            account: accounts[0]
        };

        // Silently acquires an access token which is then attached to a request for Microsoft Graph data
        instance.acquireTokenSilent(request).then((response) => {
            callMsGraph(response.accessToken).then(response => {
                console.log(response)
                microsoft(response)
            });
        }).catch((e) => {
            instance.acquireTokenPopup(request).then((response) => {
                callMsGraph(response.accessToken).then(response => {
                    console.log(response)
                    microsoft(response)
                });
            });
        });
    }
    
    useEffect(() => {
        console.log('useEffect', isAuthenticated)
        if (isAuthenticated) {
            RequestProfileData();
        } else {
            navigate(-1, {replace: true});
        }
    }, []);

    return (<React.Fragment>
        <p>Anyone can see this paragraph.</p>
        {isAuthenticated && (<p>At least one account is signed in!</p>)}
        {!isAuthenticated && (<p>No users are signed in!</p>)}
    </React.Fragment>);
}
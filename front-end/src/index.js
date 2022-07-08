import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './components/App';
import Header from './components/Header/Header'
import Footer from './components/Footer/Footer'
import reportWebVitals from './reportWebVitals';
import {BrowserRouter} from 'react-router-dom';
import {PublicClientApplication} from "@azure/msal-browser";
import {MsalProvider} from "@azure/msal-react";
import {msalConfig} from "./components/MSAuth/authConfig";

const root = ReactDOM.createRoot(document.getElementById('root'));
const msalInstance = new PublicClientApplication(msalConfig);

root.render(
    <MsalProvider instance={msalInstance}>
        <BrowserRouter>
            <Header/>
            <App/>
            <Footer/>
        </BrowserRouter>
    </MsalProvider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

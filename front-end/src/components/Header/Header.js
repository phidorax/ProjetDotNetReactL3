import React from 'react'
import {Link, Route, Routes} from "react-router-dom";
import Home from "../Home";
import Login from "../Login";
import Game from "../Game";
import SignUp from "../SignUp";
import MSAuth from "../MSAuth";
import {CheckMSAuth} from "../MSAuth/CheckMSAuth";
import logo from '../../logo.svg'
function Header(){
    return(
        <div class="header">
            <img src={logo} className="LogoHeader" alt="logo"/>
            <div className="navigation">
                <Link className="margin" to="/">Home</Link>
                <Link className="margin" to="/login">Login</Link>
                <Link className="margin" to="/signup">Signup</Link>
                <Link className="margin" to="/msauth">Microsoft Authentification</Link>
                <Link className="margin" to="/check/ms">Check Microsoft Authentification</Link>
            </div>

            <Routes>
                <Route path="/" element={<Home text={''} />} />
                <Route path="login" element={<Login />} />
                <Route path="game" element={<Game />} />
                <Route path="signup" element={<SignUp />} />
                <Route path="msauth" element={<MSAuth />} />
                <Route path="/check/ms" element={<CheckMSAuth />} />
            </Routes>
        </div>
    );
}
export default Header
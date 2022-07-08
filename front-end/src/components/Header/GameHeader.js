import React, {useState} from 'react'
import {Link, Route, Routes} from "react-router-dom";
import Home from "../Home";
import Login from "../Login";
import Game from "../Game";
import SignUp from "../SignUp";
import MSAuth from "../MSAuth";
import {CheckMSAuth} from "../MSAuth/CheckMSAuth";
import logo from '../../assets/loading.gif'
import Monde from "../Monde";
import Ile from "../Ile";
import Mer from "../Mer";
import Village from "../Village";
import Classement from "../Classement";
function GameHeader({ressource}){
    return(
        <div class="gameHeader">
            <img src={logo} className="gameLogo" alt="img2"/>
            <div className="gameNavigation">
                <Link className="margin" to="/monde">Monde</Link>
                <Link className="margin" to="/mer">Mer</Link>
                <Link className="margin" to="/ile">Ile</Link>
                <Link className="margin" to="/village">Village</Link>
                <Link className="margin" to="/classement">Classement</Link>
                <p>Bois : {ressource.ressource1}</p>
                <p>Pierre : {ressource.ressource2}</p>
                <p>Métal : {ressource.ressource3}</p>
                <p>Classement : {ressource.classement}</p>
            </div>
            <Routes>
                <Route path="/game" element={<Game text={'Bienvenue sur le jeu'} />} />
                <Route path="monde" element={<Monde />} />
                <Route path="mer" element={<Mer />} />
                <Route path="ile" element={<Ile ressource={ressource}/>} />
                <Route path="village" element={<Village ressource={ressource}/>} />
                <Route path="/classement" element={<Classement ressource={ressource}/>} />
            </Routes>
        </div>
    );
}
export default GameHeader
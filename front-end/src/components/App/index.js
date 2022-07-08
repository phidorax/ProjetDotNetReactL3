import { Routes, Route, Link } from 'react-router-dom'

import Home from '../Home';
import Login from '../Login';
import SignUp from '../SignUp';
import MSAuth from '../MSAuth';
import Header from '../Header/Header';

import './index.css';
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import Game from "../Game";
import {CheckMSAuth} from "../MSAuth/CheckMSAuth";
import GameHeader from "../Header/GameHeader";
import React, {useState} from "react";

export default function App() {
	const [ressource1, setRessource1] = useState(10);
	const [ressource2, setRessource2] = useState(10);
	const [ressource3, setRessource3] = useState(10);
	const [classement, setClassement] = useState(100);
	const [classement1, setClassement1] = useState(100);
	const classements={classement1, classement};
	const ressource={ressource1,ressource2,ressource3, classements};

	return (
		<div className="my-app">
			{
				true ?
					<GameHeader ressource={ressource}/>
				:
					<p>Accueil</p>
			}

			<div class="ressources">
				<button onClick={() => {
					setRessource1(ressource1 + 10);
					setRessource2(ressource2 + 10);
					setRessource3(ressource3 + 10);
				}}>AddRessources
				</button>
			</div>
				<div className="classement">
					<button onClick={() => {
						setClassement(ressource.classements.classement + 100);
					}}>AddClassement
					</button>
					<button onClick={() => {
						setClassement1(ressource.classements.classement1 + 100);
					}}>AddClassement2
					</button>
			</div>

		</div>
	);
}

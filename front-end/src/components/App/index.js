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

export default function App() {
	return (
		<div className="my-app">
			{
				false ?
				<GameHeader/>
				:
					<p>Accueil</p>
			}


		</div>
	);
}

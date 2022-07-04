import { Routes, Route, Link } from 'react-router-dom'

import Home from '../Home';
import Login from '../Login';
import SignUp from '../SignUp';
import MSAuth from '../MSAuth';

import './index.css';
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import Game from "../Game";

export default function App() {
	return (
		<div className="my-app">
			<div>
				<Link className="margin" to="/">Home</Link>
				<Link className="margin" to="/login">Login</Link>
				<Link className="margin" to="/signup">Signup</Link>
				<Link className="margin" to="/msauth">Microsoft Authentification</Link>
			</div>

			<Routes>
				<Route path="/" element={<Home text={'Bienvenue sur le jeu'} />} />
				<Route path="login" element={<Login />} />
				<Route path="game" element={<Game />} />
				<Route path="signup" element={<SignUp />} />
				<Route path="msauth" element={<MSAuth />} />
			</Routes>
		</div>
	);
}

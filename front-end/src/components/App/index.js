import { Routes, Route, Link } from 'react-router-dom'

import MyComponent from '../MyComponent';
import UserList from '../UserList';
import Auth from '../Auth';
import MSAuth from '../MSAuth';

import './index.css';
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';

export default function App() {
	return (
		<div className="my-app">
			Test<br />

			<div>
				<Link to="/">Home</Link><br/>
				<Link to="/users">Users</Link><br/>
				<Link to="/auth">Standard Authentification</Link><br/>
				<Link to="/msauth">Microsoft Authentification</Link><br/>
			</div>

			<Routes>
				<Route path="/" element={<MyComponent name={'world'} />} />
				<Route path="users" element={<UserList />} />
				<Route path="auth" element={<Auth />} />
				<Route path="msauth" element={<MSAuth />} />
			</Routes>
		</div>
	);
}

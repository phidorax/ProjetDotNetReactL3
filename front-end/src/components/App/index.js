import { Routes, Route, Link } from 'react-router-dom'

import Counter from '../Counter';
import MyComponent from '../MyComponent';
import TodoList from '../TodoList';
import UserList from '../UserList';
import MSAuth from '../MSAuth';

import './index.css';

export default function App() {
	return (
		<div className="my-app">
			Test<br />

			<div>
				<Link to="/">Home</Link><br/>
				<Link to="/counter">Counter</Link><br/>
				<Link to="/todo">Todo</Link><br/>
				<Link to="/users">Users</Link><br/>
				<Link to="/msauth">Microsoft Authentification</Link><br/>
			</div>

			<Routes>
				<Route path="/" element={<MyComponent name={'world'} />} />
				<Route path="counter" element={<Counter />} />
				<Route path="todo" element={<TodoList />} />
				<Route path="users" element={<UserList />} />
				<Route path="msauth" element={<MSAuth />} />
			</Routes>
		</div>
	);
}

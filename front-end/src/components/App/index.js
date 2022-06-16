import { Routes, Route, Link } from 'react-router-dom'

import Counter from '../Counter';
import MyComponent from '../MyComponent';
import TodoList from '../TodoList';
import UserList from '../UserList';

import './index.css';

export default function App() {
	return (
		<div className="my-app">
			Test<br />

			<div>
				<Link to="/">Home</Link>
				<Link to="/counter">Counter</Link>
				<Link to="/todo">Todo</Link>
				<Link to="/users">Users</Link>
			</div>

			<Routes>
				<Route path="/" element={<MyComponent name={'world'} />} />
				<Route path="counter" element={<Counter />} />
				<Route path="todo" element={<TodoList />} />
				<Route path="users" element={<UserList />} />
			</Routes>
		</div>
	);
}

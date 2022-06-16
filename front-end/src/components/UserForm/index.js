import { useState } from 'react';

import createUser from '../../queries/createUser';

export default function UserForm() {
	const [name, setName] = useState('');
	const [age, setAge] = useState(null);

	const addUser = () => {
		createUser({
			name,
			age: parseInt(age, 10),
			id: Date.now() % 10000
		});

		setAge(null);
		setName('');
	}

	return (
		<div>
			<input type="text" onChange={(e) => setName(e.target.value)} placeholder="name" />
			<input type="number" onChange={(e) => setAge(e.target.value)} placeholder="age" />
			<input type="button" onClick={addUser} value="Ajouter utilisateur" />
		</div>
	)
}
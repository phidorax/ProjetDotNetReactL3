import { useEffect, useState } from 'react';

export default function useUserList() {
	const [userList, setUserList] = useState([]);
	const [isLoading, setLoading] = useState(true);
	const [error, setError] = useState(null);

	useEffect(() => {
		async function getUsers() {
			const res = await fetch('https://localhost:7064/Users/all');

			if(res.status !== 200) {
				setError(res.statusText);
			} else {
				setUserList(
					await res.json()
				);
			}

			setLoading(false);
		}

		getUsers();
	}, [])

	return {
		isLoading,
		userList,
		error
	};
}
import { useEffect, useState } from 'react';

export default function Counter() {
	const [count, setCount] = useState(0);

	useEffect(() => {
		document.title = `Counter: ${count}`;
	}, [count]);

	let data = [];
	for(let i = 0; i < count; i++) {
		data.push(i);
	}

	return (
		<>
			<p>Counter: {count}</p>
			<input
				type="button"
				onClick={() => setCount(count + 1)}
				value="Click me !"
			/>
			{(count % 2 === 0) && <span>Pair</span>}
			{data.map((i) => <p>{i}</p>)}
		</>
	)
}
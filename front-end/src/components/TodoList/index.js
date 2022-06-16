import { useEffect, useState } from 'react';

export default function TodoList() {
    const [newItem, setNewItem] = useState('');
    const [list, setList] = useState(
        JSON.parse(localStorage.TodoList || '[]')
    );

    useEffect(() => {
        localStorage.TodoList = JSON.stringify(list);
    });

    const addToTodoList = () => {
        list.push(newItem);
        setNewItem('');
    };

    const removeItemFromTodoList = (index) => {
        //setList([...list.splice(index, 1)]);
        setList(list.filter((_, i) => i !== index));
    };

    // 1/ Ajout
    // 2/ Lister
    // 3/ Supprimer
    // 4/ Persister dans local Storage

	return (
		<div>
			<h1>To do</h1>
            <ul>
                {list.map((line, index) => {
                return (
                    <li key={index}>
                        {line}
                        <input
                            type="button"
                            value="X"
                            onClick={()=>{removeItemFromTodoList(index)}}
                        />
                    </li>
                );
            })}</ul>
            <input
                type="text"
                placeholder="Nouvel item"
                onChange={(e)=>{setNewItem(e.target.value)}}
                value={newItem}
            />
            <input
                type="button"
                value="+"
                onClick={addToTodoList}
            />
		</div>
	)
}
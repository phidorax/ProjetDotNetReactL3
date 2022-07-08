import GameHeader from "../Header/GameHeader";
import logo from "../../assets/mer.jpeg";
import React, {useState} from "react";
let timer;
export default function Mer() {
	const [ressource1, setRessource1] = useState(0);
	const [ressource2, setRessource2] = useState(0);
	const [ressource3, setRessource3] = useState(0);
	const [counterState, setCounter] = React.useState(0);
	React.useEffect(() => {
		clearInterval(timer)
		timer = setInterval(()=> {
			if(counterState === 100) {
				clearInterval(timer)
				return
			}
			setCounter(prev => prev+1)
			setRessource1(ressource1 + 10)
			setRessource2(ressource2 + 20)
			setRessource3(ressource3 + 15)
		}, 100)
		return () => clearInterval(timer)
	}, [counterState])
	return (
		<div class="mer col-md-12">
			<div className="affichage col-md-6">
				<img src={logo} className="gameScene" alt="logo"/>
			</div>
			<div className="affichageList col-md-6">
				<h1>Bienvenue Mer</h1>
				<ul>
					<li>Mer 1</li>
					<li>Mer 2</li>
					<li>Mer 3</li>
					<h4>Incrémentation automatique :</h4>
					<p> Bois {ressource1} Pierre {ressource2} Métal {ressource3}</p>
				</ul>
			</div>
		</div>
	);
}
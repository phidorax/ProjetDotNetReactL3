import GameHeader from "../Header/GameHeader";
import logo from "../../assets/village.jpg";
import React from "react";
import {useState} from "react";
export default function Village({ressource}) {
	const [niveau, setNiveau] = useState(1);
	return (
		<div class="village col-md-12">
			<div className="affichage col-md-6">
				<img src={logo} className="gameScene" alt="logo"/>
			</div>
			<div className="affichageList col-md-6">
				<h1>Bienvenue Village</h1>
				<ul>
					<li>Mairie {niveau}</li>
					<li>Scierie {niveau}</li>
					<li>Mine de fer {niveau}</li>
					<li>Ferme {niveau}</li>
					<li>Carrière {niveau}</li>
					<li>Entrepot {niveau}</li>
				</ul>
				<button onClick={() => {
					if((ressource.ressource1 >= 50) && (ressource.ressource2 >= 50) && (ressource.ressource3 >= 50 )){
						setNiveau(niveau + 1);
						//setRessource(ressource.ressource1 - 50);
					}

				}}>Upgrate batiment
				</button>
			</div>
		</div>
	);
}
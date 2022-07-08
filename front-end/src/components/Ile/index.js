import GameHeader from "../Header/GameHeader";
import logo from "../../assets/ile.jpg";
import React from "react";
import {useState} from "react";
export default function Ile({ressource}) {
	let [libre, setLibre] = useState("");
	let [libre2, setLibre2] = useState("");
	let [libre3, setLibre3] = useState("");
	let [libre4, setLibre4] = useState("");
	return (
		<div class="ile col-md-12">
			<div className="affichage col-md-6">
				<img src={logo} className="gameScene" alt="logo"/>
			</div>
			<div className="affichageList col-md-6">
				<h1>Bienvenue Ile</h1>
				<ul>
					<li>Village 1 : {libre == "" ? "Joueur 1" : libre}  </li>
					<li>Village 2 :{libre == "" ? "libre cout : 50 50 50" : libre}  <button onClick={() => {
						if((ressource.ressource1 >= 50) && (ressource.ressource2 >= 50) && (ressource.ressource3 >= 50 ))
						setLibre(libre = "joueur 1" );
					}}>V
					</button></li>
					<li>Village 3 :{libre2 == "" ? "libre cout : 60 60 60" : libre2}  <button onClick={() => {
						if((ressource.ressource1 >= 60) && (ressource.ressource2 >= 60) && (ressource.ressource3 >= 60 ))
							setLibre2(libre2 = "joueur 1" );
					}}>V
					</button></li>
					<li>Village 4 :{libre3 == "" ? "libre cout : 70 70 70" : libre3} <button onClick={() => {
						if((ressource.ressource1 >= 70) && (ressource.ressource2 >= 70) && (ressource.ressource3 >= 70 ))
							setLibre3(libre3 = "joueur 1" );
					}}>V
					</button></li>
					<li>Village 5 : {libre4 == "" ? "libre cout : 80 80 80" : libre4}
						<button onClick={() => {
						if((ressource.ressource1 >= 80) && (ressource.ressource2 >= 80) && (ressource.ressource3 >= 80 ))
							setLibre4(libre4 = "joueur 1" );
					}}>V
					</button></li>
					<li>Village . . .:</li>
				</ul>
			</div>
		</div>
	);
}
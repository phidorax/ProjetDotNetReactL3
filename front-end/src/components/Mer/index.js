import GameHeader from "../Header/GameHeader";
import logo from "../../assets/mer.jpeg";
import React from "react";
export default function Mer() {
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
				</ul>
			</div>
		</div>
	);
}
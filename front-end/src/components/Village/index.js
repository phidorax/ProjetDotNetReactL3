import GameHeader from "../Header/GameHeader";
import logo from "../../assets/village.jpg";
import React from "react";
export default function Village() {
	return (
		<div class="village col-md-12">
			<div className="affichage col-md-6">
				<img src={logo} className="gameScene" alt="logo"/>
			</div>
			<div className="affichageList col-md-6">
				<h1>Bienvenue Village</h1>
				<ul>
					<li></li>
					<li></li>
					<li></li>
				</ul>
			</div>
		</div>
	);
}
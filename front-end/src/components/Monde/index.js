import GameHeader from "../Header/GameHeader";
import logo from "../../assets/monde.jpg";
import React from "react";
export default function Monde() {
	return (
		<div class="monde col-md-12">
			<div className="affichage col-md-6">
				<img src={logo} className="gameScene" alt="logo"/>
			</div>
			<div className="affichageList col-md-6">
				<h1>Bienvenue Monde</h1>
				<ul>
					<li>Terre</li>
					<li>Uranus</li>
					<li>Thèbes</li>
				</ul>
			</div>

		</div>
	);
}
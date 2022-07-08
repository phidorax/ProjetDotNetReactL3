import GameHeader from "../Header/GameHeader";
import React from "react";
export default function Classement({ressource}) {
	return (
		<div class="classement col-md-12">
			<div className="affichage col-md-6">
				<h1>Bienvenue classement</h1>
			</div>

			<div className="affichageList col-md-6">
				<h1>2 eme partie</h1>
				<ul>
					<li>{ressource.classements.classement}</li>
					<li>{ressource.classements.classement1}</li>
					<li></li>
				</ul>
			</div>
		</div>
	);
}
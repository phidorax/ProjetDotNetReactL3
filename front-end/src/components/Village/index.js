import GameHeader from "../Header/GameHeader";
import logo from "../../assets/village.jpg";
import React from "react";
import {useState} from "react";
export default function Village({ressource}) {
	const [niveauMairie, setNiveauMairie] = useState(1);
	const [niveauScierie, setNiveauScierie] = useState(1);
	const [niveauMineDeFer, setNiveauMineDeFer] = useState(1);
	const [niveauFerme, setNiveauFerme] = useState(1);
	const [niveauCarriere, setNiveauCarriere] = useState(1);
	const [niveauEntrepot, setNiveauEntrepot] = useState(1);
	let [scoreVillage, setScoreVillage] = useState(0);
	const progression = 15;
	return (
		<div class="village col-md-12">
			<div className="affichage col-md-6">
				<img src={logo} className="gameScene" alt="logo"/>
			</div>
			<div className="affichageList col-md-6">
				<h1>Bienvenue Village</h1>
				<h2>Score du village : {scoreVillage}</h2>
				<ul>
					<li>Mairie {niveauMairie} Statistique => Cout : ({progression + (niveauMairie * 2)}) | score Batiment : {(progression * (niveauMairie-1))}
						<button onClick={() => {
							if((ressource.ressource1 >= progression + (niveauMairie * 2)) && (ressource.ressource2 >= progression + (niveauMairie * 2)) && (ressource.ressource3 >= progression + (niveauMairie * 2) )){
								setNiveauMairie(niveauMairie + 1);
								setScoreVillage(scoreVillage + (progression * niveauMairie));
								//setRessource(ressource.ressource1 - 50);
							}

						}}>Upgrate
						</button></li>
					<li>Scierie {niveauScierie}  Statistique => Cout : ({progression + (niveauScierie * 2)}) | score Batiment : {(progression * (niveauScierie-1))}
						<button onClick={() => {
							if((ressource.ressource1 >= progression + (niveauScierie * 2)) && (ressource.ressource2 >= progression + (niveauScierie * 2)) && (ressource.ressource3 >= progression + (niveauScierie * 2) )){
								setNiveauScierie(niveauScierie + 1);
								setScoreVillage(scoreVillage + (progression * niveauScierie));
							}

						}}>Upgrate
						</button></li>
					<li>Mine de fer {niveauMineDeFer}  Statistique => Cout : ({progression + (niveauMineDeFer * 2)}) | score Batiment : {(progression * (niveauMineDeFer-1))}
						<button onClick={() => {
							if((ressource.ressource1 >= progression + (niveauMineDeFer * 2)) && (ressource.ressource2 >= progression + (niveauMineDeFer * 2)) && (ressource.ressource3 >= progression + (niveauMineDeFer * 2) )){
								setNiveauMineDeFer(niveauMineDeFer + 1);
								setScoreVillage(scoreVillage + (progression * niveauMineDeFer));
							}

						}}>Upgrate
						</button></li>
					<li>Ferme {niveauFerme}  Statistique => Cout : ({progression + (niveauFerme * 2)}) | score Batiment : {(progression * (niveauFerme-1))}
						<button onClick={() => {
							if((ressource.ressource1 >= progression + (niveauFerme * 2)) && (ressource.ressource2 >= progression + (niveauFerme * 2)) && (ressource.ressource3 >= progression + (niveauFerme * 2) )){
								setNiveauFerme(niveauFerme + 1);
								setScoreVillage(scoreVillage + (progression * niveauFerme));
							}

						}}>Upgrate
						</button></li>
					<li>Carrière {niveauCarriere}  Statistique => Cout : ({progression + (niveauCarriere * 2)}) | score Batiment : {(progression * (niveauCarriere-1))}
						<button onClick={() => {
							if((ressource.ressource1 >= progression + (niveauCarriere * 2)) && (ressource.ressource2 >=  progression + (niveauCarriere * 2)) && (ressource.ressource3 >=  progression + (niveauCarriere * 2) )){
								setNiveauCarriere(niveauCarriere + 1);
								setScoreVillage(scoreVillage + (progression * niveauCarriere));
							}

						}}>Upgrate
						</button></li>
					<li>Entrepot {niveauEntrepot}  Statistique => Cout : ({progression + (niveauEntrepot * 2)}) | score Batiment : {(progression * (niveauEntrepot -1))}
						<button onClick={() => {
							if((ressource.ressource1 >=  progression + (niveauCarriere * 2)) && (ressource.ressource2 >= progression + (niveauCarriere * 2)) && (ressource.ressource3 >= progression + (niveauCarriere * 2) )){
								setNiveauEntrepot(niveauEntrepot + 1);
								setScoreVillage(scoreVillage + (progression * niveauEntrepot));
							}

						}}>Upgrate
						</button></li>
				</ul>
			</div>
		</div>
	);
}
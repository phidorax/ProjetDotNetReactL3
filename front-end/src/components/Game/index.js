import GameHeader from "../Header/GameHeader";
export default function Game() {
	return (
		<div class="game">
			<h1>Bienvenue joueur</h1>
			<GameHeader />
			<ul>
				<li><button>Affichage ressources</button></li>
				<li><button>Affichage batiment</button></li>
				<li><button>Affichage classement</button></li>
				<li><button>Affichage monde</button></li>
			</ul>
		</div>
	);
}
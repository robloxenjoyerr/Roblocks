<script lang="ts">
	import { onMount } from 'svelte';
	import GamesMapper from '../lib/components/GamesMapper.svelte';
	import Sidebar from '../lib/components/Sidebar.svelte';
	import Header from '../lib/components/Header.svelte';
	import LandingPage from '../lib/components/LandingPage.svelte';
	import GamePage from '../lib/components/GamePage.svelte';
	

	let contentState = $state('landingPage');
	
	const friendsArr = [
	{ id: 0, username: "Tung Tung Sahur", status: "online", avatarUrl: "avatar-1.jpg" },
	{ id: 1, username: "Skibidi Sahur King", status: "playing", avatarUrl: "avatar-2.jpg" },
	{ id: 2, username: "Rizzler Noob Destroyer", status: "offline", avatarUrl: "avatar-3.jpg" },
	{ id: 3, username: "Ohio Brainrot Dealer", status: "afk", avatarUrl: "avatar-4.jpg" },
	{ id: 4, username: "Sigma Toilet Commander", status: "playing", avatarUrl: "avatar-5.jpg" },
	{ id: 5, username: "Gigachad Skibidi Hunter", status: "offline", avatarUrl: "avatar-6.jpg" },
	{ id: 6, username: "NPC Awakening Unit", status: "online", avatarUrl: "avatar-7.jpg" },
	{ id: 7, username: "Brainrot CEO 3000", status: "playing", avatarUrl: "avatar-8.jpg" },
	{ id: 8, username: "Skull Emoji Warrior", status: "afk", avatarUrl: "avatar-9.jpg" },
	{ id: 9, username: "Rizzless Chaos Goblin", status: "online", avatarUrl: "avatar-10.jpg" },
	{ id: 10, username: "Toilet Titan Slayer", status: "playing", avatarUrl: "avatar-11.jpg" },
	{ id: 11, username: "Sigma Drift Phantom", status: "offline", avatarUrl: "avatar-12.jpg" },
	{ id: 12, username: "Ohio Final Boss", status: "online", avatarUrl: "avatar-13.jpg" },
	{ id: 13, username: "Skibidi Meme Overlord", status: "playing", avatarUrl: "avatar-14.jpg" },
	{ id: 14, username: "Braincell Fragmented", status: "offline", avatarUrl: "avatar-15.jpg" },
	{ id: 15, username: "Ultra Instinct Rizzer", status: "afk", avatarUrl: "avatar-16.jpg" },
	{ id: 16, username: "Tung Tung Reborn", status: "afk", avatarUrl: "avatar-17.jpg" },
	{ id: 17, username: "Sahur Dimension Breaker", status: "offline", avatarUrl: "avatar-18.jpg" }
];
	
	let friends = $state(friendsArr)
	const url = 'http://localhost:5147/api/v1/games';
	type Game = {
		id: number;
		name: string;
		imageUrl: string;
		players: string;
	};

	let games: Game[] = $state([]);

	onMount(async () => {
		try {
			const res = await fetch(`${url}/1`);
			const data = await res.json();

			games = [...games, ...data];
			console.log(games);
		} catch (err) {
			console.error(err);
		}
	});

	async function fetchInsertDemoGames() {
		try {
			const res = await fetch(`${url}/insertDemoGames`);

			if (res.ok) {
				console.log(res);
			}
		} catch (err) {
			console.error(err);
		}
	}
</script>

<div class="flex h-screen overflow-hidden bg-gray-200 text-[14px] text-gray-900">
	<!-- SIDEBAR -->
	<Sidebar/>

	<!-- RIGHT SIDE -->
	<div class="flex min-w-0 flex-1 flex-col">
		<!-- HEADER -->
		<Header/>
		<LandingPage friends={friends} lastPlayedGames={[]} popularGames={games} />
		<GamePage />
	</div>
</div>

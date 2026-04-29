<script lang="ts">
	import Button from '../components/Button.svelte';
	import { onMount } from 'svelte';
	import GamesMapper from '../components/GamesMapper.svelte';

	const url = 'http://localhost:5147/api/v1/games';
	type Game = {
		id: number;
		name: string;
		imageUrl: string;
		players: string;
	};

	let games: Game[] = [];

	onMount(async () => {
		try {
			const res = await fetch(url);
			const data = await res.json();

			games = data;
		} catch (err) {
			console.error(err);
		}
	});

	async function fetchInsertDemoGames(){
		try{
			const res = await fetch(`${url}/insertDemoGames`)

			if(res.ok){
				console.log(res)
			}
		}
		catch(err){
			console.error(err)
		}
	}
</script>

<div class="flex h-screen overflow-hidden bg-gray-200 text-[14px] text-gray-900">
	<!-- SIDEBAR -->
	<aside class="flex w-[200px] shrink-0 flex-col border-r border-gray-200 bg-[#f2f2f2] py-4">
		<div class="flex flex-col gap-6 px-4 pt-4">
			<Button iconUrl="user" label="Profile" />
			<Button iconUrl="friends" label="Friends" />
			<Button iconUrl="marketplace" label="Marketplace" />
			<Button iconUrl="love" label="Favorites" />
			<Button iconUrl="friends" label="Groups" />
		</div>
	</aside>

	<!-- RIGHT SIDE -->
	<div class="flex min-w-0 flex-1 flex-col">
		<!-- HEADER -->
		<header class="h-25 border-b border-gray-200 bg-[#f2f2f2]">
			<nav class="flex h-full items-center justify-between px-6">
				<img class="h-30" src="/Roblocks-Header.png" alt="" />

				<div class="flex items-center gap-4">
					<input
						class="w-[260px] rounded-full border border-gray-300 bg-gray-50 px-4 py-1.5 text-sm focus:border-fuchsia-400 focus:outline-none"
						placeholder="Search games..."
					/>

					<a
						href="/login"
						class="rounded-lg bg-fuchsia-500 px-5 py-1.5 text-sm font-semibold text-white hover:bg-fuchsia-600"
					>
						Log In
					</a>
				</div>
			</nav>
		</header>

		<!-- CONTENT -->
		<main class="flex-1 space-y-10 overflow-y-auto px-8 py-6">
			<!-- FRIENDS -->
			<section>
				<div class="mb-4 flex items-center justify-between">
					<h2 class="text-xl font-bold">Friends</h2>
					<span class="cursor-pointer text-sm text-fuchsia-500">See All →</span>
				</div>

				<div class="flex gap-6 overflow-x-auto pb-8">
					{#each Array(22) as _, i}
						<div class="flex min-w-[70px] flex-col items-center">
							<div class="relative">
								<img class="h-14 w-14 rounded-full bg-gray-300" src="/avatar.png" />
								<div
									class="absolute right-0 bottom-0 h-3 w-3 rounded-full border-2 border-white bg-green-500"
								></div>
							</div>
							<span class="mt-1 text-xs">Player</span>
						</div>
					{/each}
				</div>
			</section>

			<!-- GAMES -->
			<GamesMapper games={games} label="Last played"/>
			<Button onClick={fetchInsertDemoGames} label="insertDemoGames"/>
		</main>
	</div>
</div>

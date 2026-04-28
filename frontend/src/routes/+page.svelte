<script>
	import Button from '../components/Button.svelte';
	const trendingGames = [
		{ id: 1, name: 'Ninja Fighters', imageUrl: '/game-icons/IMG_0799.WEBP', players: '1.2k' },
		{ id: 2, name: 'Blob Hunter', imageUrl: '/game-icons/IMG_0800.WEBP', players: '1.2k' },
		{ id: 3, name: 'Scary Game', imageUrl: '/game-icons/IMG_0801.WEBP', players: '1.2k' },
		{ id: 4, name: 'Steal a Brainrot', imageUrl: '/game-icons/IMG_0802.WEBP', players: '1.2k' },
		{ id: 5, name: 'Kick a Brainrot', imageUrl: '/game-icons/IMG_0803.WEBP', players: '1.2k' },
		{ id: 6, name: 'Catch a fish', imageUrl: '/game-icons/IMG_0804.WEBP', players: '1.2k' },
		{ id: 7, name: 'Attack on Titan', imageUrl: '/game-icons/IMG_0805.WEBP', players: '1.2k' },
		{ id: 8, name: 'Steal a Brainrot 2', imageUrl: '/game-icons/IMG_0806.WEBP', players: '1.2k' },
		{ id: 9, name: 'Kill the Brainrots', imageUrl: '/game-icons/IMG_0807.WEBP', players: '1.2k' },
		{ id: 10, name: 'Cheese Hunting Game', imageUrl: '/game-icons/IMG_0808.WEBP', players: '1.2k' },
		{ id: 11, name: 'Dont fall in the lava', imageUrl: '/game-icons/IMG_0809.WEBP', players: '1.2k' },
		{ id: 12, name: 'Mining Tycoon', imageUrl: '/game-icons/IMG_0810.WEBP', players: '1.2k' },
		{ id: 13, name: 'Catch a LuckyBlock', imageUrl: '/game-icons/IMG_0811.WEBP', players: '1.2k' },
		{ id: 14, name: '67 Game', imageUrl: '/game-icons/IMG_0812.WEBP', players: '1.2k' },
		{ id: 15, name: 'Eat all the Puppys', imageUrl: '/game-icons/IMG_0813.WEBP', players: '1.2k' },
		{ id: 16, name: 'Piss of your Girlfriend Game', imageUrl: '/game-icons/IMG_0814.WEBP', players: '1.2k' },
		{ id: 17, name: 'Aura Game', imageUrl: '/game-icons/IMG_0815.WEBP', players: '1.2k' },
		{ id: 18, name: 'Dont let him catch you', imageUrl: '/game-icons/IMG_0816.WEBP', players: '1.2k' },
		{ id: 19, name: 'Money Tycoon', imageUrl: '/game-icons/IMG_0817.WEBP', players: '1.2k' },
		{ id: 20, name: 'ZERO: Basketball', imageUrl: '/game-icons/IMG_0818.WEBP', players: '1.2k' },
	
	];
</script>

<div class="bg-background text-text-main flex h-screen overflow-hidden">
	<!-- SIDEBAR -->
	<aside class="w-fit bg-gray-300 shadow-md">
		<div class="flex flex-col p-5 gap-6 pt-6">
			<Button iconUrl="user" label="Profile" />
			<Button iconUrl="friends" label="Friends" />
			<Button iconUrl="marketplace" label="Marketplace" />
			<Button iconUrl="love" label="Favorites" />
			<Button iconUrl="friends" label="Groups" />
		</div>
	</aside>

	<!-- RIGHT SIDE (HEADER + CONTENT) -->
	<div class="flex flex-1 flex-col">
		<!-- HEADER -->
		<header class="h-20 bg-gray-300 shadow-sm">
			<nav class="flex h-full w-full items-center justify-between px-5">
				<span class="flex items-center gap-5">
					<img class="w-70 " src="/Roblocks-Header.png" alt="">
				</span>

				<a href="/login" class="bg-primary rounded-lg px-6 py-2 font-bold text-red-500"> Log In </a>
			</nav>
		</header>

		<!-- CONTENT AREA -->
		<main class="flex-1 overflow-y-auto">
			<!-- Friends -->
			<section class="p-6 relative h-75 bg-black/30 text-left text-white">
				<h2 class="mb-5 text-black font-extrabold text-3xl ">Friends</h2>
				<div class="flex  gap-15 h-30 inset-0 z-0 overflow-auto">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
					<img class="w-25 h-25" src="/avatar.png" alt="">
				</div>

			</section>

			<!-- GAMES -->
			<section class="p-6 bg-background bg-black/30">
				<div class="container">
					<h2 class="mb-5 font-extrabold text-left text-3xl text-black">Featured Games</h2>

					<div class="grid grid-cols-2 gap-10 md:grid-cols-4">
						{#each trendingGames as game (game.id)}
							<a
								href="/games/{game.id}"
								class="group bg-surface block bg-black/50 overflow-hidden rounded-lg shadow-md transition hover:shadow-fuchsia-400"
							>
								<img
									src={game.imageUrl}
									alt=""
									class="h-48 w-full object-cover transition group-hover:scale-105"
								/>

								<div class="p-4">
									<h4 class="truncate font-bold">{game.name}</h4>
								</div>
							</a>
						{/each}
					</div>
				</div>
			</section>
		</main>
	</div>
</div>

<script>
	import Button from '../components/Button.svelte';
	const trendingGames = [
		{ id: 1, name: 'Tower of Misery', imageUrl: '/avatar.png', players: '1.2k' },
		{ id: 2, name: 'Adopt a Pet!', imageUrl: '/avatar.png', players: '5.8k' },
		{ id: 3, name: 'Escape the Dungeon Obby', imageUrl: '/avatar.png', players: '3.4k'},
		{ id: 4, name: 'Tycoon Simulator', imageUrl: '/avatar.png', players: '2.1k' },
		{ id: 5, name: 'Tycoon Simulator', imageUrl: '/avatar.png', players: '2.1k' },
		{ id: 6, name: 'Tycoon Simulator', imageUrl: '/avatar.png', players: '2.1k' },
		{ id: 7, name: 'Tycoon Simulator', imageUrl: '/avatar.png', players: '2.1k' },
		{ id: 8, name: 'Tycoon Simulator', imageUrl: '/avatar.png', players: '2.1k' }
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

<script>
	import Button from '../components/Button.svelte';

	// In einer echten App würden diese Daten von deiner API kommen.
	const trendingGames = [
		{ id: 1, name: 'Tower of Misery', imageUrl: '/placeholder-game-1.jpg', players: '1.2k' },
		{ id: 2, name: 'Adopt a Pet!', imageUrl: '/placeholder-game-2.jpg', players: '5.8k' },
		{
			id: 3,
			name: 'Escape the Dungeon Obby',
			imageUrl: '/placeholder-game-3.jpg',
			players: '3.4k'
		},
		{ id: 4, name: 'Tycoon Simulator', imageUrl: '/placeholder-game-4.jpg', players: '2.1k' }
	];
</script>
<div class="bg-background text-text-main min-h-screen">
	<!-- 1. Header -->
	<header
		class="bg-surface/80 sticky top-0 z-50 border-b border-gray-200 bg-transparent backdrop-blur-sm"
	>
		<nav class="flex w-full items-center justify-between px-5 py-4">
            <span class="flex gap-5 justify-center items-center">
                <Button iconUrl="menu" label=""  />
                <a href="/" class="text-primary self-center text-5xl font-extrabold text-red-500 uppercase">Roblocks</a>
            </span>
			<div>
				<a
					href="/login"
					class="text-red-500 bg-primary rounded-lg px-6 py-2 font-bold transition-opacity hover:opacity-90"
				>
					Log In
				</a>
			</div>
		</nav>
	</header>
	<nav id="side-navbar" class="fixed hidden top-0 left-0 z-40 h-screen w-20 bg-black/50 text-white">
		<div class="flex flex-col items-center gap-6 pt-6">
			<span class="text-xs">123</span>
		</div>
	</nav>

	<main>
		<!-- Hero Section -->
		<section class=" h-250 bg-black/50 text-center text-white">
			<div class="absolute inset-0 bg-black">
				<img src="./roblocks.png" alt="Stuff" class="-z-50 h-full w-full object-cover opacity-80" />
				<div
					class="from-background via-background/50 absolute inset-0 bg-gradient-to-t to-transparent"
				></div>
			</div>
			<div class="relative container mx-auto px-6 py-32 md:py-48">
				<h1 class="text-4xl font-extrabold text-shadow-lg md:text-6xl">Millions of Games!</h1>
				<p class="text-shadow mx-auto mt-4 max-w-2xl text-lg md:text-xl">
					Create or Play Games created by other users!
				</p>
				<div class="mt-8">
					<a
						href="/register"
						class="bg-accent transform rounded-lg px-10 py-4 text-xl font-bold text-white transition-opacity hover:scale-105 hover:opacity-90"
					>
						Register and Play
					</a>
				</div>
			</div>
		</section>

		<!-- Trending Games Section -->
		<section class="bg-background py-20">
			<div class="container mx-auto px-6">
				<h2 class="mb-12 text-center text-3xl font-bold">Featured Games</h2>
				<div class="grid grid-cols-2 gap-6 md:grid-cols-4">
					{#each trendingGames as game (game.id)}
						<a
							href="/games/{game.id}"
							class="group bg-surface block overflow-hidden rounded-lg shadow-md transition-shadow hover:shadow-fuchsia-400"
						>
							<div class="relative">
								<img
									src={game.imageUrl}
									alt={game.name}
									class="h-48 w-full object-cover transition-transform group-hover:scale-105"
								/>
								<div
									class="absolute right-2 bottom-2 rounded bg-black/50 px-2 py-1 text-xs text-white"
								>
									{game.players} Players
								</div>
							</div>
							<div class="p-4">
								<h4 class="truncate font-bold">{game.name}</h4>
							</div>
						</a>
					{/each}
				</div>
			</div>
		</section>
	</main>

	<!-- Footer -->
	<footer class="bg-surface border-t border-gray-200 py-8">
		<div class="text-text-secondary container mx-auto px-6 text-center">
			<p>&copy; {new Date().getFullYear()} Roblocks Corporation. All rights reserved.</p>
			<div class="mt-4 flex justify-center space-x-6">
				<a href="#" class="hover:text-primary">About us</a>
				<a href="#" class="hover:text-primary">Jobs</a>
				<a href="#" class="hover:text-primary">Privacy</a>
				<a href="#" class="hover:text-primary">Other</a>
			</div>
		</div>
	</footer>
</div>

<style>
	.text-shadow {
		text-shadow: 0px 2px 4px rgba(0, 0, 0, 0.5);
	}
	.text-shadow-lg {
		text-shadow: 0px 4px 8px rgba(0, 0, 0, 0.5);
	}
</style>

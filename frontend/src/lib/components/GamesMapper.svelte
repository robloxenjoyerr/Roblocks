<script lang="ts">
	import Button from './Button.svelte';
	import SeeAll from './SeeAll.svelte';
	

	const url = 'http://localhost:5147/api/v1/games';

	type Props = {
		label?: string;
		games?: any;
		style?: string;
	};

	let { label = 'Undefined', games = [], style = '' }: Props = $props();

	async function loadMoreGames() {
		try {
			const data = await fetch(`${url}/2`);
		} catch (err) {
			console.error(err);
		}
	}
</script>

<section class="flex w-full flex-col gap-2">
	<div class="flex w-full justify-between">
		<h1 class="text-xl font-bold">{label}</h1>
		<SeeAll />
	</div>
	<div class={`grid grid-cols-2 gap-5 md:grid-cols-4 xl:grid-cols-6 ${style}`}>
		{#if games?.length}
			{console.log(games)}
			{#each games as game (game.id)}
				<a
					href="/games/{game.id}"
					class="overflow-hidden rounded-xl bg-white shadow-sm transition hover:shadow-lg"
				>
					<div class="h-36 bg-gray-200">
						<img
							src={game.imageUrl}
							alt="/placeholder.png"
							class="h-full w-full object-cover transition hover:scale-105"
						/>
					</div>

					<div class="p-3">
						<h4 class="truncate text-sm font-semibold">{game.name}</h4>
						<p class="text-xs text-gray-500">{game.players} playing</p>
					</div>
				</a>
			{/each}
		{:else}
			<div
				class="col-span-full flex flex-col items-center justify-center rounded-2xl border border-dashed border-gray-300 bg-white/60 py-4 text-center shadow-sm"
			>
				<h3 class="mt-3 text-lg font-semibold text-gray-700">No games found</h3>

				<p class="mt-1 max-w-sm text-sm text-gray-500">
					We couldn’t load any games yet. Play a game now and it will show here after!.
				</p>
			</div>
		{/if}
	</div>
	{#if games.length > 0}
		<Button onClick={() => loadMoreGames()} style="justify-center" label="load more" />
	{/if}
</section>

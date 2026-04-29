<script lang="ts">
	type Props = {
		label?: string;
		games?: any;
		style?: string;
	};

	let { label = 'Undefined', games = [], style = '' }: Props = $props();

</script>

<section class="flex w-full flex-col gap-2">
	<div class="flex w-full items-center justify-between">
		<span class="text-xl font-bold">{label}</span>
		<span class="cursor-pointer text-sm text-fuchsia-500">See All →</span>
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
			<span class="text-gray-400">No last played..</span>
		{/if}
	</div>
</section>

<script lang="ts">
	import TitleDisplay from './titleDisplay.svelte';
	import InfoBox from './infoBox.svelte';
	import { onMount } from 'svelte';
	import { api } from '$lib/services/ApiClient';
	import { page } from '$app/state';

	let gameName = $state();

	onMount(async () => {
		try {
			let { params } = page;
			gameName = params.gameName;
			const data = await api.v1GamesDetail(0);
			// const data = await api.v1GamesDetail(0);
		} catch {}
	});
</script>

<h1>{gameName}</h1>

<div class="flex h-screen w-screen justify-center bg-gray-200 pt-20">
	<div class="inline-flex flex-col">
		<div class="flex">
			<img src={data.imageUrl} alt={data.imageDescription} class="h-[45vh]" />
			<TitleDisplay gameTitle={data.name} creator={data.creator} />
		</div>
		<InfoBox
			text_data={{
				About: 'Example About',
				Store: 'Buy everything for 3 billion robux',
				Servers: 'We have 0 Servers'
			}}
		/>
	</div>
</div>

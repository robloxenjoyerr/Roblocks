<script>
	import TitleDisplay from './titleDisplay.svelte';
	import InfoBox from './infoBox.svelte';

	let { data } = $props();
</script>

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

<script>
	import TitleDisplay from './titleDisplay.svelte';

	let { data } = $props();
</script>

<div class="h-screen w-screen p-10 pl-30">
	<div class="flex">
		<img src={data.imageUrl} alt={data.imageDescription} class="h-[50vh]" />
		<TitleDisplay gameTitle={data.name} creator={data.creator} />
	</div>
	<div>{data.description}</div>
</div>

<script lang="ts">
	let {
		label = "Button",
		iconUrl = "",
		style = "",
		onClick = () => {}
	} = $props();

	function handleClick(event: MouseEvent) {
		onClick(event);
	}
</script>

<button
	onclick={handleClick}
	class={`flex h-fit w-full gap-4  p-3 font-bold uppercase hover:bg-black/20 active:bg-black/30 ${style}`}
>
	{#if iconUrl.length > 0}
		<img class="h-5 w-5 self-center" src={`/${iconUrl}.png`} alt="icon" />
	{/if}

	{label}
</button>
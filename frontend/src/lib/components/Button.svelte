
<script lang="ts">

	let {
		label = 'Button',
		iconUrl = '',
		fileType = 'png',
		iconFirst = true,
		style = '',
		href = "",
		onClick = () => {},
		
	}: {
		label?: string;
		iconUrl?: string;
		fileType?: string;
		iconFirst?: boolean;
		style?: string;
		href?: string;
		onClick?: (e: MouseEvent) => void;
	} = $props();

	function handleClick(event: MouseEvent) {
		onClick(event);
	}
</script>

{#if href}
	<a href={href}>
		<button
			
			class={`flex h-fit gap-4 rounded-2xl p-3 text-center font-bold uppercase hover:bg-black/20 active:bg-black/30 ${style}`}
		>
			{#if iconFirst && iconUrl}
				<img class="h-5 w-5 self-center" src={`/${iconUrl}.${fileType}`} alt="icon" />
				{label}
			{:else}
				{label}
				<img class="h-5 w-5 self-center" src={`/${iconUrl}.${fileType}`} alt="icon" />
			{/if}
		</button> 
	</a>
	{:else}
		<button
			onclick={handleClick}
			class={`flex h-fit gap-4 rounded-2xl p-3 text-center font-bold uppercase hover:bg-black/20 active:bg-black/30 ${style}`}
		>
			{#if iconFirst && iconUrl}
				<img class="h-5 w-5 self-center" src={`/${iconUrl}.${fileType}`} alt="icon" />
				{label}
			{:else}
				{label}
				<img class="h-5 w-5 self-center" src={`/${iconUrl}.${fileType}`} alt="icon" />
			{/if}
		</button> 

{/if}

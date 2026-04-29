<script lang="ts">
	import { Texts, type TextData } from './types.js';

	interface Props {
		text_data: TextData;
	}
	let { text_data }: Props = $props();

	let text = $state(text_data[Texts.About]);

	function updateText(selected: Texts) {
		text = text_data[selected];
	}
</script>

<div class="flex h-10 w-full bg-white">
	{#each [Texts.About, Texts.Store, Texts.Servers] as label}
		<button
			class="flex grow items-center justify-center font-bold"
			onclick={(event) => {
				updateText(label);
			}}>{label}</button
		>
	{/each}
</div>
<div class="p-4">{text}</div>

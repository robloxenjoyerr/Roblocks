<script lang="ts">
	type SeeAllProps = {
		disabled?: boolean;
		value?: any[];
		label?: string;
		onClick?: () => void;
	};

	let { disabled = false, label = 'See All', value = [], onClick }: SeeAllProps = $props();

	function handleClick() {
		if (disabled) return;
		onClick?.();
	}
</script>

<div class="">
	<button
		
		onclick={handleClick}
		class={`${value.length === 0 || value === null || disabled ? 'cursor-not-allowed text-gray-400' : 'cursor-pointer text-fuchsia-500'}  text-sm text-fuchsia-500`}
		>See All →</button
	>
</div>

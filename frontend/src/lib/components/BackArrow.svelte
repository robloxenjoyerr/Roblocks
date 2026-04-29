<script lang="ts">
	let { redirectTo = '' } = $props();

	function goBack() {
		history.back();
	}
</script>

<button onclick={() => goBack()} class=" w-fit p-1 rounded-2xl hover:cursor-pointer hover:bg-black/20">
	<img src="/arrow-back.svg" alt="" />
</button>

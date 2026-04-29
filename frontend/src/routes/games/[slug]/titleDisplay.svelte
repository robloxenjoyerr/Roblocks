<script>
	let { gameTitle, creator } = $props();
</script>

<div class="flex h-[48vh] flex-col justify-center pt-6 pl-6">
	<h1 class="text-4xl font-bold">{gameTitle}</h1>
	<div>By <span class="font-bold">{creator}</span></div>
	<div class="grow"></div>
	<button class="mb-7 h-13 w-full rounded-xl bg-green-600">Play</button>
</div>

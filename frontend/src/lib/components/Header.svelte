<script>
	import Input from "./Input.svelte";

</script>


<header class="h-25 border-b border-gray-200 bg-[#f2f2f2]">
			<nav class="flex h-full items-center justify-between px-6">
				<img class="h-30" src="/Roblocks-Header.png" alt="" />

				<div class="flex items-center gap-4">
					<Input/>

					<a
						href="/login"
						class="rounded-lg bg-fuchsia-500 px-5 py-1.5 text-sm font-semibold text-white hover:bg-fuchsia-600"
					>
						Log In
					</a>
				</div>
			</nav>
		</header>
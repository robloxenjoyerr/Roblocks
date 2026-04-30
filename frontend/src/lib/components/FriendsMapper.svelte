<script lang="ts">
	import SeeAll from "./SeeAll.svelte";

	type FriensMapperProps = {
		friends: any[];
	};

	let { friends = [] }: FriensMapperProps = $props();

	function handleClick() {}
</script>

<section>
	<SeeAll value={friends}/>

	<div class="flex gap-6 overflow-x-auto pb-8">
		{#if friends && friends.length > 1}
			{#each friends as f, i}
				<div class="flex min-w-[70px] flex-col items-center">
					<div class="relative">
						<a class="relative block h-full w-full " title="Profile" href={`/friends/${f.username}`}>
							<img
								class="h-14 w-14 border-2 border-black/5 rounded-full bg-gray-300"
								src={`/profile-avatars/${f.avatarUrl}`}
								alt={`/profile-avatars/${f.avatarUrl}`}
							/>
							{#if f.status === 'online'}
								<div
									class="absolute right-0 bottom-0 h-3 w-3 rounded-full border-2 border-white bg-green-500"
								></div>
							{:else if f.status === 'playing'}
								<div
									class="absolute right-0 bottom-0 h-3 w-3 rounded-full border-2 border-white bg-blue-500"
								></div>
							{:else if f.status === 'afk'}
								<div
									class="absolute right-0 bottom-0 h-3 w-3 rounded-full border-2 border-white bg-yellow-500"
								></div>
							{:else if f.status === 'offline'}
								<div
									class="absolute right-0 bottom-0 h-3 w-3 rounded-full border-2 border-white bg-gray-500"
								></div>
							{/if}
						</a>
					</div>
					<span class="mt-1 text-xs">{f.username}</span>
				</div>
			{/each}
		{:else}
			<div
				class="col-span-full flex flex-col items-center w-full justify-center rounded-2xl border border-dashed border-gray-300 bg-white/60 py-4 text-center shadow-sm"
			>
			
				<h3 class="mt-3 text-lg font-semibold text-gray-700">No friends found</h3>
				<span class="flex gap-1">
					<p class="mt-1 max-w-sm text-sm text-gray-500">
						We couldn’t find any friends on your profile! Add new friends 
					</p>
					<a href="/friends/add" class="mt-1 max-w-sm text-sm text-blue-500">
						here
					</a>
				</span>
			</div>
		{/if}
	</div>
</section>

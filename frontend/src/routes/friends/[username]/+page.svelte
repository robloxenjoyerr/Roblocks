<script lang="ts">
	import Header from '$lib/components/Header.svelte';
	import Sidebar from '$lib/components/Sidebar.svelte';

	import { page } from '$app/state';
	import GamesMapper from '$lib/components/GamesMapper.svelte';
	import { onMount } from 'svelte';
	import BackArrow from '$lib/components/BackArrow.svelte';
	let { params } = page;

	const url = 'http://localhost:5147/api/v1/friends';
	let usernameState = $state(params.username)
	const userInfo = {
		username: usernameState,
		currentlyPlaying: "none",
		status: "offline",
		achievements: [],
		avatarUrl: ""
	}

	async function getUserData(){
		try{
			const data = await fetch(`${url}/${userInfo.username}`)

			
		} catch(err){
			console.error(err)
		}
	}

	onMount(async ()=> await getUserData())
</script>
<div class="flex h-screen overflow-hidden bg-gray-200 text-[14px] text-gray-900">
	<Sidebar />
	<div class="flex min-w-0 flex-1 flex-col">
		<Header />
		
		<main class="flex-1 overflow-y-auto p-8 space-y-8">
			
			<BackArrow/>
			<!-- PROFILE HEADER -->
			<div class="flex items-center gap-6 rounded-3xl bg-white p-6 shadow-md">

				<!-- Avatar -->
				<div class="relative">
					<img
						class="h-24 w-24 rounded-full bg-gray-300 object-cover"
						src={`/profile-avatars/${userInfo.avatarUrl || "placeholder.png"}`}
						alt='/profile-avatars/placeholder.png'
					/>

					<!-- Status -->
					<div class="absolute bottom-1 right-1 h-4 w-4 rounded-full border-2 border-white bg-yellow-500"></div>
				</div>

				<!-- Info -->
				<div class="flex flex-col">
					<h1 class="text-2xl font-bold">{params.username}</h1>
					<p class="text-sm text-gray-500">Currently playing: </p>

					<div class="mt-3 flex gap-3">
						<a href={`/friends/${userInfo.username}/chat`} class="rounded-lg bg-fuchsia-500 px-4 py-1.5 text-white text-sm hover:bg-fuchsia-600">
							Message
						</a>
						<button class="rounded-lg border border-gray-300 px-4 py-1.5 text-sm hover:bg-gray-100">
							Invite
						</button>
					</div>
				</div>
			</div>

			<!-- STATS -->
			<div class="grid grid-cols-3 gap-4">
				<div class="rounded-xl bg-white p-4 shadow-sm text-center">
					<p class="text-lg font-bold">24</p>
					<p class="text-xs text-gray-500">Games Played</p>
				</div>
				<div class="rounded-xl bg-white p-4 shadow-sm text-center">
					<p class="text-lg font-bold">1.2k</p>
					<p class="text-xs text-gray-500">Hours</p>
				</div>
				<div class="rounded-xl bg-white p-4 shadow-sm text-center">
					<p class="text-lg font-bold">18</p>
					<p class="text-xs text-gray-500">Favorites</p>
				</div>
			</div>

			<!-- LAST PLAYED -->
			<GamesMapper label="Last Played" games={[]} />

			<!-- FAVORITES -->
			<GamesMapper label="Favorite Games" games={[]} />

		</main>
	</div>
</div>
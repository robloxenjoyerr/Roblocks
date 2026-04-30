<script lang="ts">
	import Input from '$lib/components/Input.svelte';
	import { api } from '$lib/services/ApiClient';
	import { redirect } from '@sveltejs/kit';
	import { preventDefault } from 'svelte/legacy';

	let usernameState = $state("")
	let emailState = $state("")
	let passwordState = $state("")

	async function handleSubmit(){
		const newUser = {
			username: usernameState,
			email: emailState,
			password: passwordState
		}

		try{
			const res = await api.

			
			if(res.ok){
				redirect(200 , "/")
			}
		} catch(err) {console.error(err)}


	}

</script>

<div class="relative flex flex-col h-screen overflow-hidden bg-gray-200 text-[14px] text-gray-900">
    
    <!-- Background Image -->
<img
  class="absolute inset-0 h-full w-full object-cover z-0"
  src="/roblocks.png"
  alt=""
/>
<div class="w-screen h-screen absolute inset-0 bg-black/60 z-10"></div>

<div class="relative z-20 flex min-w-0 flex-1 flex-col">
        <header class="w-screen h-30 flex justify-center">
        <img class="h-fit w-fit" src="./Roblocks-Header.png" alt="">
    </header>
		<main class="flex flex-1 items-center justify-center p-8">
			<div class="w-full max-w-sm rounded-3xl bg-white p-8 shadow-md">
				<h1 class="mb-8 p-2 text-center text-2xl font-bold">Register</h1>

				<!-- SSO Buttons -->
				<div class="mb-5 flex flex-col gap-3">
					<button
						class="hover:cursor-pointer flex h-10 w-full items-center justify-center gap-3 rounded-xl border border-gray-300 px-4 ..."
					>
						<!-- Google -->
						<svg width="18" height="18" viewBox="0 0 24 24">
							<path
								fill="#4285F4"
								d="M22.56 12.25c0-.78-.07-1.53-.2-2.25H12v4.26h5.92c-.26 1.37-1.04 2.53-2.21 3.31v2.77h3.57c2.08-1.92 3.28-4.74 3.28-8.09z"
							/>
							<path
								fill="#34A853"
								d="M12 23c2.97 0 5.46-.98 7.28-2.66l-3.57-2.77c-.98.66-2.23 1.06-3.71 1.06-2.86 0-5.29-1.93-6.16-4.53H2.18v2.84C3.99 20.53 7.7 23 12 23z"
							/>
							<path
								fill="#FBBC05"
								d="M5.84 14.09c-.22-.66-.35-1.36-.35-2.09s.13-1.43.35-2.09V7.07H2.18C1.43 8.55 1 10.22 1 12s.43 3.45 1.18 4.93l2.85-2.22.81-.62z"
							/>
							<path
								fill="#EA4335"
								d="M12 5.38c1.62 0 3.06.56 4.21 1.64l3.15-3.15C17.45 2.09 14.97 1 12 1 7.7 1 3.99 3.47 2.18 7.07l3.66 2.84c.87-2.6 3.3-4.53 6.16-4.53z"
							/>
						</svg>
						Sign in with Google
					</button>

					<button
						class="hover:cursor-pointer flex h-10 w-full items-center justify-center gap-3 rounded-xl border border-gray-300 px-4 ..."
					>
						<!-- Apple -->
						<svg width="18" height="18" viewBox="0 0 24 24" fill="currentColor">
							<path
								d="M17.05 20.28c-.98.95-2.05.86-3.08.41-1.09-.46-2.09-.48-3.24 0-1.44.62-2.2.44-3.06-.41C2.79 15.25 3.51 7.7 9.05 7.4c1.39.07 2.35.74 3.15.8 1.19-.24 2.33-.93 3.6-.84 1.54.12 2.7.7 3.44 1.8-3.12 1.87-2.38 5.98.48 7.13-.57 1.56-1.32 3.1-2.67 3.99z"
							/>
						</svg>
						Sign in with Apple
					</button>

					<button
						class="hover:cursor-pointer flex h-10 w-full items-center justify-center gap-3 rounded-xl border border-gray-300 px-4 ..."
					>
						<!-- Bosch -->
						<svg width="18" height="18" viewBox="0 0 100 100">
							<rect width="100" height="100" fill="#005691" rx="6" />
							<text
								x="50"
								y="68"
								font-size="56"
								font-weight="700"
								fill="white"
								text-anchor="middle"
								font-family="Arial">B</text
							>
						</svg>
						Sign in with Bosch SSO
					</button>
				</div>

				<!-- Divider -->
				<div class="mb-5 flex items-center gap-3">
					<div class="h-px flex-1 bg-gray-200"></div>
					<span class="text-xs text-gray-400">or with E-Mail</span>
					<div class="h-2 flex-1 bg-gray-200"></div>
				</div>

				<!-- Form -->
				<form onsubmit={(e)=> {e.preventDefault(); handleSubmit()}} class="flex flex-col gap-3">
					<div class="flex flex-col gap-1">
						<label for="username" class="text-xs text-gray-500">Username</label>
						<Input bind:value={usernameState} required id="username" placeholder="Tung tung tung Sahur" />
					</div>
					<div class="flex flex-col gap-1">
						<label for="email" class="text-xs text-gray-500">E-Mail</label>
						<Input bind:value={emailState} type="email" required id="email" placeholder="tung@sahur.sigma" />
					</div>
					<div class="flex flex-col gap-1">
						<div class="flex items-center justify-between">
							<label for="password" class="text-xs text-gray-500">Password</label>
							
						</div>
						<Input bind:value={passwordState} type="password" required id="password" placeholder="password" />
					</div>
					<div class="flex flex-col gap-1">
						<div class="flex items-center justify-between">
							<label for="password-reenter" class="text-xs text-gray-500">Re-enter password</label>
						
						</div>
						<Input type="password" required id="password-reenter" placeholder="password" />
					</div>

					<button
						type="submit"
						class="hover:cursor-pointer mt-1 h-10 w-full rounded-xl bg-fuchsia-500 px-4 text-sm font-semibold text-white transition-colors hover:bg-fuchsia-600"
					>
						Register
					</button>
				</form>

				<p class="mt-4 text-center text-xs text-gray-400">
					No account yet?
					<a href="/login" class="font-medium text-fuchsia-500 hover:text-fuchsia-600">
						Login
					</a>
				</p>
			</div>
		</main>
	</div>
</div>

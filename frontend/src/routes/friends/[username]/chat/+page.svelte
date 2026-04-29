<script lang="ts">
	import BackArrow from '$lib/components/BackArrow.svelte';
	import Button from '$lib/components/Button.svelte';
	import GamesMapper from '$lib/components/GamesMapper.svelte';
	import Header from '$lib/components/Header.svelte';
	import Input from '$lib/components/Input.svelte';
	import Sidebar from '$lib/components/Sidebar.svelte';

	const userinfo = {};

    type Message={
        message: string,
        sender: string
    }

	let chatHistory = $state<Message[]>([]);
    let message = $state("")
    function handleSubmit(e: SubmitEvent){
        e.preventDefault()

        if(!message.trim()) return

        console.log("Sending: ", message)
        chatHistory.push({message: message, sender: "user"})
        message = ""
    }
</script>

<div class="flex h-screen overflow-hidden bg-gray-200 text-[14px] text-gray-900">
	<Sidebar />
	<div class="flex flex-1 flex-col">
		<Header />

		<BackArrow />

		<section class="m-5 flex h-full flex-col gap-3 rounded-2xl bg-black/5 p-5">
			<div class="flex h-full w-full rounded-2xl border-2 border-fuchsia-500">
				{#if chatHistory.length > 0}{:else}
					<span class=" animate-pulse text-black/70">Sorry, no messages yet.</span>
				{/if}
			</div>
			<div class="flex w-full gap-3">
				<form  class="flex w-full gap-3" onsubmit={handleSubmit}>
					<Input bind:value={message}  style="flex-1 min-w-0" label="Message" />
					<Button type="submit" style="w-24 shrink-0" iconUrl="Send" iconFirst={false} label="Send" />
				</form>
			</div>
		</section>
	</div>
</div>

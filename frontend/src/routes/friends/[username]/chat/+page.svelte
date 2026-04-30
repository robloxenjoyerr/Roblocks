<script lang="ts">
	import BackArrow from '../../../../lib/components/BackArrow.svelte';
	import Button from '../../../../lib/components/Button.svelte';
	import Header from '../../../../lib/components/Header.svelte';
	import Input from '../../../../lib/components/Input.svelte';
	import Sidebar from '../../../../lib/components/Sidebar.svelte';

    type Message={
		id: string,
        message: string,
        sender: string
    }

	let chatHistory = $state<Message[]>([]);
    let message = $state("")
    function handleSubmit(e: SubmitEvent){
        e.preventDefault()

        if(!message.trim()) return

        console.log("Sending: ", message)
        chatHistory.push()
        message = ""
    }
</script>

<div class="flex h-screen overflow-hidden bg-gray-200 text-[14px] text-gray-900">
	<Sidebar />
	<div class="flex flex-1 flex-col">
		<Header />

		
		<section class="flex h-full flex-col space-y-8 gap-3 rounded-2xl p-8">
			<BackArrow />
			<div class="flex h-full w-full justify-center items-center rounded-2xl border-2 border-fuchsia-500">
				{#if chatHistory.length > 0}
					<p class="  animate-pulse text-black/70">Sorry, no messages yet.</p>

				{:else}
					{#each chatHistory as message (message.id)}
						
					{/each}
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

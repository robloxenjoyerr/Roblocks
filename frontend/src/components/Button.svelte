<script>
    let name = "Button"

    const {
        label = "Button",
        iconUrl = "",
        style =""
    } = $props()
</script>

    <button class={`flex gap-3 w-fit h-fit bg-black/10 p-2 hover:bg-black/20 active:bg-black/30 border border-black rounded-xl uppercase font-bold ${style}`}>
        {#if iconUrl.length > 0}
            <img class="w-5 h-5 self-center" src={`/${iconUrl}.png`} alt="/avatar.png">
        {/if}
        {label}
    </button>


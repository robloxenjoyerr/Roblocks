<script lang="ts">

    let {
        label = "Search..",
        style = "",
        value = $bindable(''),
        ...others
    } = $props()

</script>
    
<input
    {...others}
    bind:value
	class={` rounded-full border border-gray-300 bg-gray-50 px-4 py-1.5 text-sm focus:border-fuchsia-400 focus:outline-none ${style}`}

/>

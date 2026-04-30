<script lang="ts">
	import FriendsMapper from './FriendsMapper.svelte';
	import GamesMapper from './GamesMapper.svelte';

	type LandingPageProps = {
		friends: any[];
		lastPlayedGames: any[];
		popularGames: any[];
	};

	let { friends, lastPlayedGames = [], popularGames = [] }: LandingPageProps = $props();
</script>

<!-- CONTENT -->
<main class="flex-1 space-y-10 overflow-y-auto px-8 py-8">
	<FriendsMapper {friends} />
	<GamesMapper games={lastPlayedGames} label="Last Played" />
	<GamesMapper games={popularGames} label="Popular Games" />
</main>

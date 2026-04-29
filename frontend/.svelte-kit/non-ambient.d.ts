
// this file is generated — do not edit it


declare module "svelte/elements" {
	export interface HTMLAttributes<T> {
		'data-sveltekit-keepfocus'?: true | '' | 'off' | undefined | null;
		'data-sveltekit-noscroll'?: true | '' | 'off' | undefined | null;
		'data-sveltekit-preload-code'?:
			| true
			| ''
			| 'eager'
			| 'viewport'
			| 'hover'
			| 'tap'
			| 'off'
			| undefined
			| null;
		'data-sveltekit-preload-data'?: true | '' | 'hover' | 'tap' | 'off' | undefined | null;
		'data-sveltekit-reload'?: true | '' | 'off' | undefined | null;
		'data-sveltekit-replacestate'?: true | '' | 'off' | undefined | null;
	}
}

export {};


declare module "$app/types" {
	type MatcherParam<M> = M extends (param : string) => param is (infer U extends string) ? U : string;

	export interface AppTypes {
		RouteId(): "/" | "/friends" | "/friends/[username]" | "/friends/[username]/chat" | "/home";
		RouteParams(): {
			"/friends/[username]": { username: string };
			"/friends/[username]/chat": { username: string }
		};
		LayoutParams(): {
			"/": { username?: string };
			"/friends": { username?: string };
			"/friends/[username]": { username: string };
			"/friends/[username]/chat": { username: string };
			"/home": Record<string, never>
		};
		Pathname(): "/" | `/friends/${string}` & {} | `/friends/${string}/chat` & {} | "/home";
		ResolvedPathname(): `${"" | `/${string}`}${ReturnType<AppTypes['Pathname']>}`;
		Asset(): "/arrow-back.svg" | "/avatar.png" | "/friends.png" | "/game-icons/IMG_0799.WEBP" | "/game-icons/IMG_0800.WEBP" | "/game-icons/IMG_0801.WEBP" | "/game-icons/IMG_0802.WEBP" | "/game-icons/IMG_0803.WEBP" | "/game-icons/IMG_0804.WEBP" | "/game-icons/IMG_0805.WEBP" | "/game-icons/IMG_0806.WEBP" | "/game-icons/IMG_0807.WEBP" | "/game-icons/IMG_0808.WEBP" | "/game-icons/IMG_0809.WEBP" | "/game-icons/IMG_0810.WEBP" | "/game-icons/IMG_0811.WEBP" | "/game-icons/IMG_0812.WEBP" | "/game-icons/IMG_0813.WEBP" | "/game-icons/IMG_0814.WEBP" | "/game-icons/IMG_0815.WEBP" | "/game-icons/IMG_0816.WEBP" | "/game-icons/IMG_0817.WEBP" | "/game-icons/IMG_0818.WEBP" | "/Home.svg" | "/love.png" | "/marketplace.png" | "/menu.png" | "/multiple-users-silhouette.png" | "/placeholder.png" | "/profile-avatars/avatar-1.jpg" | "/profile-avatars/avatar-10.jpg" | "/profile-avatars/avatar-11.jpg" | "/profile-avatars/avatar-12.jpg" | "/profile-avatars/avatar-13.jpg" | "/profile-avatars/avatar-14.jpg" | "/profile-avatars/avatar-15.jpg" | "/profile-avatars/avatar-2.jpg" | "/profile-avatars/avatar-3.jpg" | "/profile-avatars/avatar-4.jpg" | "/profile-avatars/avatar-5.jpg" | "/profile-avatars/avatar-6.jpg" | "/profile-avatars/avatar-7.jpg" | "/profile-avatars/avatar-8.jpg" | "/profile-avatars/avatar-9.jpg" | "/profile-avatars/placeholder.png" | "/Roblocks-Header.png" | "/roblocks.png" | "/robots.txt" | "/Send.png" | "/user.png" | string & {};
	}
}
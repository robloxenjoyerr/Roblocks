
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
		RouteId(): "/" | "/home";
		RouteParams(): {
			
		};
		LayoutParams(): {
			"/": Record<string, never>;
			"/home": Record<string, never>
		};
		Pathname(): "/" | "/home";
		ResolvedPathname(): `${"" | `/${string}`}${ReturnType<AppTypes['Pathname']>}`;
		Asset(): "/avatar.png" | "/friends.png" | "/game-icons/IMG_0799.WEBP" | "/game-icons/IMG_0800.WEBP" | "/game-icons/IMG_0801.WEBP" | "/game-icons/IMG_0802.WEBP" | "/game-icons/IMG_0803.WEBP" | "/game-icons/IMG_0804.WEBP" | "/game-icons/IMG_0805.WEBP" | "/game-icons/IMG_0806.WEBP" | "/game-icons/IMG_0807.WEBP" | "/game-icons/IMG_0808.WEBP" | "/game-icons/IMG_0809.WEBP" | "/game-icons/IMG_0810.WEBP" | "/game-icons/IMG_0811.WEBP" | "/game-icons/IMG_0812.WEBP" | "/game-icons/IMG_0813.WEBP" | "/game-icons/IMG_0814.WEBP" | "/game-icons/IMG_0815.WEBP" | "/game-icons/IMG_0816.WEBP" | "/game-icons/IMG_0817.WEBP" | "/game-icons/IMG_0818.WEBP" | "/love.png" | "/marketplace.png" | "/menu.png" | "/multiple-users-silhouette.png" | "/Roblocks-Header.png" | "/roblocks.png" | "/robots.txt" | "/user.png" | string & {};
	}
}
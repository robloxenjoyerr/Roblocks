
export const load = async ({ params, fetch }) => {
    const slug = params.slug

    return { name: slug, creator: "sombody that i used to know", description: "description", imageUrl: "https://upload.wikimedia.org/wikipedia/en/thumb/7/77/Steal_a_Brainrot_thumbnail.webp/250px-Steal_a_Brainrot_thumbnail.webp.png", imageDescription: "brainrot" }
}
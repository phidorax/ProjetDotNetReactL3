export default async function signup(user) {
    await fetch(
        'https://localhost:7004/signup',
        {
            headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(user)
        }
    )
}
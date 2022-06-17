export default async function login(credentials) {
    await fetch(
        'https://localhost:7004/login',
        {
            headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(credentials)
        }
    )
}
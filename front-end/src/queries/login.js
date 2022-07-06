export default async function login(credentials) {
    const res = await fetch(
        'https://localhost:7004/login/basic',
        {
            headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(credentials)
        }
    )
    return res;
}
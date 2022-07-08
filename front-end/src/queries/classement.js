export default async function classement() {
    const res = await fetch(
        'https://localhost:7004/GetAllClassements',
        {
            headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
            },
            method: 'GET',
            body: JSON.stringify()
        }
    )
    return res;
}
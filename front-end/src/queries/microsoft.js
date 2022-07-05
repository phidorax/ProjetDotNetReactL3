export default async function microsoft(graphData) {
    const credentials = {
        first_name: graphData.givenName,
        name: graphData.surname,
        email: graphData.userPrincipalName,
        id: graphData.id
    }
    console.log(credentials)
    const res = await fetch(
        'https://localhost:7004/login/ms',
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
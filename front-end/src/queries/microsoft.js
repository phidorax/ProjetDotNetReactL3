export default async function microsoft(graphData) {
    const credentials = {
        displayName: graphData.displayName,
        firstName: graphData.givenName,
        lastName: graphData.surname,
        Email: graphData.userPrincipalName,
        ID: graphData.id
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
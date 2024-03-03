# ExcerciseBlazorAndApi

## Endpoints

| Path           | Method | Request           | Response | Status |
| -------------- | ------ | ----------------- | -------- | ------ |
| /api/users     | Get    | -                 | User[]   | 200    |
| /api/users{id} | Get    | string id         | User     | 200    |
| /api/users     | Post   | UserDto           | User     | 200    |
| /api/users{id} | Put    | string id UserDto | -        | 200    |
| /api/users{id} | Delete | string id         | -        | 200    |

| Path              | Method | Request           | Response  | Status |
| ----------------- | ------ | ----------------- | --------- | ------ |
| /api/messages     | Get    | -                 | Message[] | 200    |
| /api/messages{id} | Get    | string id         | Message   | 200    |
| /api/messages     | Post   | MessageDto        | Message   | 200    |
| /api/messages{id} | Put    | string id UserDto | -         | 200    |
| /api/messages{id} | Delete | string id         | -         | 200    |

## Skapa Vyer

I Client-projektet sätt upp en mapp för servicar.
Lägg till en UserService och en MessageService med metoder för Get och Post
Gör det nedan med hårdkodade listor i servicarna till att börja med (registrera servicarna som Singleton).
Injecta dessa i respektive vy efter att du skapat dem.

1. Skapa en vy för vardera endpoint-grupp
2. User-vyn ska ha ett formulär för att lägga till en user
3. Message-Vyn ska ha ett formulär för att skicka meddelanden
   1. Message-vyn ska också kunna visa alla messages

## Anropa APIet

1. Registrera en HttpClient i Client-projektet med BaseAddress från APIet.
2. Skapa fält för en HttpClient och injecta IHttpClientFactory i Servicarna, tilldela fälten HttpClient från Factoryn.
3. Gör så att metoderna i servicarna anropar lämpliga endpoints

## Testa och utöka

1. Testa så att GetAll och Post funkar
2. Utöka så att man kan välja att visa messages skickade från en specifik User
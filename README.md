# Todo Lists app
Prepared in scope of interviews for Senior Software Dev position in Ezra.
It contains `todo-list-api` app implemented in .NET Core 9 as backend (EF + Sqlite) and `todo-list-web-react` app implemented in React.js as frontend.

This work took me about 16 hours, across 2 days, just working between interviews and home/kids chores.

## How to run the app
### Prerequisites
1. `docker` ver.20+ 
2. `docker-compose` ver.1.25+

### To run the app
1. Perform `docker-compose up --build`
2. Open `localhost:3000` in browser.

Additionally you can exchange by REST with backend on `http://localhost:5051` (openapi: http://localhost:5051/openapi/v1.json)

## Dev Notes
- I dockerized it, so it would be easier to setup and to ship and use altogether. I put healthchecks and dependencies between services in place, but in the real prod I would strongly recommend using Kubernetes or any other mature orchestrator, which would provide restarting on Unhealthy and scaling.
- For production usage the ngnix in docker should have been used instead of simple `npm run dev`.
- I used only one IRepository for everything around data storage, if data models will grow, for example operations on TodoListItem (which needed), Users and so on, I would consider creating more repositories under the same IRepository umbrella.
- I used EF standard migration mechanism with initial seed data, to make sure testing would not start from the scratch all the time.
- I created a cached version of EF repository (in-memory cache) using Decorator pattern, to be able to easily switch it or replace.
- If ever scale the API app, then in-memory cache should be replaced with distributed cache, right now this API + in-memory cache solution is not scalable.
- Implemented a few unit tests for backend validation, though very minimal and if time allowed I would have bumped unit testing up.
- In the data structure I would add also 'weight' for both TodoList and TodoListItem so users could set the way data is sorted precisely.
- In the react web app I would make significant changes: I would add sorting and filtering by Completed/Uncompleted lists, also modifying all data points presented on the screen.

# Known issues
- No constant refreshing of the list on FE side.
- No sorting on backend or frontend.
- No way to create TodoList with 'completed' TodoListItem.
- No PUT verb, so data is not mutable. (big issue as for API and for web app).
- This app needs Authorization and supporting different users, so another DB table with Users needed.

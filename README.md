# Heroes IMS:
*Heroes IMS* (Information management system)
Example project's purpose is to store basic information about heroes (Nickname, gender, country, powers).
> Project can be used as starter for **ASP.NET Web Api2** with **Vue.js**

## Project Techincal Overview
The main project consists of several parts: 
1. **Heroes.Data:** holds Data Transfer Objects and their mappings
2. **Heroes.DataAccessLayer:** contains entity objects, entity context, migrations, generic repository model and unit of work
3. **Heroes.BusinessLogicLayer:** contains services and their abstractions (+ Unit Tests)
4. **Heroes:** main **ASP.NET Web Api** (and also MVC) (REST API)
5. **Heroes/heroes-cli:** **Vue.js** frontend part, built using **Typescript**

## Built using
- Backend
  - ASP.NET Web Api2
  - Entity Framework 6
  - Unity DI (Microsoft)
  - Automapper
  - SQL Server
- Frontend
  - Vuejs2  with Typescript
  - Webpack
  - Bootstrap 3

## Examples
###### The page with the list of available heroes, with searching/filtering form
![List and Search of heroes](./docs/list-heroes.gif)
###### The page of creating a new hero
![Create New Hero](./docs/create-hero.gif)

# JewelleryStore
An application for a jewellery store to estimate gold prices.
The application is organised in a domain-driven and clean architechture design.
The API's are secured using the JWT authentication scheme.
The Entity framework core is used for data access.
The following diagram illustrates the dependencies between various application components.
The inner layers are totally independant from the outer layers which are generally technology related.
This ensures that the core business rules are developed without depending on the API or storage technologies.

![image](https://user-images.githubusercontent.com/9382122/117107826-de8b2b80-ad9f-11eb-9b51-8707f2836c12.png)

1. Domain - contains core business rules.
2. Model - contains the classes used for representing the data to API consumers.
3. DbModel - contains classes used for interacting with database.
4. Application - Handles application service requests
5. API - provides endpoints for application service
 
# Requirements
1. .NET 5 SDK
2. MSSQL server
3. Visual Studio 2019

# Steps to run app
1. Clone the solution to local workspace
2. Run the database script DatabaseSetup.sql available in the root folder.
3. Replace the connection string in appsettings.json in the JewellleryStore.API folder i.e. ConnectionStrings.mssql with your local mssql connection string.
4. Run the solution JewellleryStore.API.sln using visual studio IIS Express.
5. Application will be hosted on https://localhost:44303
6. A swagger UI will be launched with list of all APIs.
7. To test gold price API, swagger UI needs to be authorised with bearer token by opening the authorise box.
9. Use { "username":"Normal","password":"Normal") or {"username":"Privileged","password":"Privileged"} in the authenticate request body and fetch the token.

# Test APIs using the shared Postman collection
https://www.getpostman.com/collections/a8f45cf7c923410da80a

1. Import the shared link into postman through File->Import->Link-> paste link
2. The link imports the collection - JewelleryStore API
3. Test cases
    i. Unknown user authentication
   ii. Normal user authentication
  iii. Privileged user authentication
   iv. Get gold price with authentication
    v. Get gold price without authentication



# JewelleryStore
An application for a jewellery store to estimate gold prices.
The application is organised in a domain-driven and clean architechture design.
The API's are secured using the JWT authentication scheme.
The following diagram illustrates the dependencies between various application components.
The inner layers are totally independant from the outer layers which are generally technology related. This ensures that the core business rules are developed without depending on the API or storage technologies.
![image](https://user-images.githubusercontent.com/9382122/117103949-ed221480-ad98-11eb-8248-954273d46191.png)

# Requirements
1. .NET 5
2. SQl Database
3. Visual Studio 2019

# Steps to run app
1. Clone the solution to local workspace
2. Run the database script DatabaseSetup.sql
3. Replace the connection string in appsettings.json i.e. ConnectionStrings.mssql with your local connection string.
4. Run the solution using visual studio.
5. Application will be hosted on https://localhost:44303

# Postman collection
https://www.getpostman.com/collections/a8f45cf7c923410da80a

1. Import the shared link into postman through File->Import->Link-> paste link
2. The link imports the collection - JewelleryStore API
3. Test cases
    i. Unknown user authentication
   ii. Normal user authentication
  iii. Privileged user authentication
   iv. Get gold price with authentication
    v. Get gold price without authentication



# CMPG323-Project-2-42686784
Welcome to my API Development project 2
###
![download](https://github.com/user-attachments/assets/9d63d326-0b09-4064-8e84-0266d52deb1d)

## About the Project:
This is a Web API project that works with a database called DatabaseOLA. This database is on a SQL Server database that is hosted on Azure. 
###
###
## this picture shows all the tables used and the picture is in sequal server management studio which is used to manage SQL databases
###
![image](https://github.com/user-attachments/assets/25f53411-cdcb-4ddd-8a18-b4fa69f8691e)

# Microsoft Azure database
1. Started off by creating an account on Microsft Azure.
2. Created a Monthly budget to avoid running out of credits.
3. Created a resource group called Project2_42686784.
4. Created a SQL server and database under the resource group Project2_42686784.

# API Creation
I created the web API using Visual Studio and added controllers to manage the database tables hosted on the Azure server. Subsequently, I implemented security measures to ensure that only authorized users can access the API functionalities.

# Hosting the API
I deployed the API using Visual Studio and then accessed it from the Azure platform.

## Security:
The API is secured in the sense that not everyone has access to it right away. You must register an account in order to use the API to access and manipulate database data. This is a token-based, secure system. The server on which the database is hosted is also secured, and those details are not accessible to everyone. I also used the git ignore file for all passwords in the appsettings.json file. (For protection purposes)

# API Usage Guide

Welcome to the API Usage Guide for the Project Name API. This guide will help you understand how to interact with the API to access and manipulate data from the ecocloudhub database.

# Getting Started
Once you have access to the API link, 
You should: Register an Account:

Visit the API registration page to create an admin user account.
This account is required to access and manipulate database tables.

# Log In:
Use the login credentials from the registration to log in.
After successful login, you'll receive an authentication token.

#Using the API
Endpoints
JobTelemetry
GET/api/JobTelemetry:  Retrieve a list of all JobTelemetry data
POST/api/JobTe1emetry:  Create a new JobTelemetry
GET/api/products/{id}: gets specific JobTelemetry
PUT/api/JobTelemetry/{id}: Update product JobTelemetry
DELETE /api/JobTelemetry/{id}: Delete a JobTelemetry.
GET/api/JobTelemetry/savings : gets savings for JobTelemetry

# Authentication
Include the authentication token received upon login in the Authorization header for each request.
Example: Authorization: Bearer <your-token-here>
Example Workflow

# Register an admin account.
Log in to receive the authentication token.
Use the token in the Authorization header for subsequent requests.
Access customer, order, and product data using the provided endpoints.
Make GET, POST, PUT, or DELETE requests as needed.
Security Notes
The API is secured using token-based authentication.
Only admin users have access to the API endpoints.
The server hosting the database is also secure

#resource group
https://portal.azure.com/#@nwuac.onmicrosoft.com/resource/subscriptions/36901f75-831e-42af-8bc1-9e17fe6b0c49/resourceGroups/Project2_42686784/overview

# Link to API
https://apidevelopmentproject2.azurewebsites.net/index.html

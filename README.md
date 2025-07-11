# A product catalogue project on Azure
## Description
This project is following my learning plan to create a C# Minimal API, hosted on Azure, deployed with GitHub Actions.

## Tech and techniques
- C# Minimal API
    - separating the service code from the API (dependency injected)
    - initially using a hard-coded JSON file as the sample data
    - data access is dependency injected, so can be readily swapped for a database later
- Dapper for SQL data access
- NUnit unit test suite for the service layer
    - the test suite is to be integrated into the GitHub Actions pipeline so that the code will only deploy on a successful test

Initially, a walking skeleton is to be built allowing me to discover what services I will require and to understand how to build them. This will allow me to get a working CI/CD pipeline built from the start.

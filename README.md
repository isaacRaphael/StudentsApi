# StudentsApi

## Case Study Solution Guide
### Database
The database used for this case study solution is PostGreSql.

### Migrations
Migrations have already been added and can be found in the Migrations folder within the Data Layer.

### Connection String
To run the program, please provide your own connection string by replacing the one in my app settings with yours.

### Updating the Database
To update the database, please run "update-database" on the Package Manager Console. Make sure to target the appropriate project, i.e., the startup project is StudentsApi, while the default project set in the Package Manager Console should be Students.Data.

### Running the Solution
Once the database is updated, the solution can be run without any issues.

If you intend to run the solution from the frontend, please confirm that the port used by the API is the same as the one set in the baseurl property of the app.tsx file in the frontend project.

### Solution Overview
In this solution, concerns were separated by using specific layers to handle different logic domains. FluentValidation was used for DTO validation, and auto validation was registered as a service. Postgresql was used as the database.

Thank you for reviewing this case study solution guide. If you have any questions or concerns, please feel free to reach out.

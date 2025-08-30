## 🛠️ How to Run the Solution Locally

To set up and run the Online Election System on your local machine, follow these steps:

1. **Update the Connection String**  
   Open `Web.config` and modify the connection string to point to your local SQL Server instance.

2. **Ensure SQL Server is Running**  
   Make sure your SQL Server Management Studio (SSMS) is running and the instance is accessible.

3. **Apply Entity Framework Migrations**  
   Open the **Package Manager Console** in Visual Studio and run:
Update-Database
This will apply all existing migrations and create the database schema.

4. **Run the Solution**  
Build and run the project from Visual Studio. The application should launch successfully.

5. **Login Credentials**  
Default admin credentials are seeded via migration or available directly in the database. You can query the `Users` or `SecurityUsers` table to retrieve them.

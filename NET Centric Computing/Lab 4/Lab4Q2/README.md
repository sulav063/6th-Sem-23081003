use Console App (.NET Framework)

Install-Package EntityFramework

Query:


CREATE DATABASE DatabaseFirstDB;
GO


USE DatabaseFirstDB;
GO


CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50),
    Age INT
);
GO


INSERT INTO Students (Name, Age) VALUES
('Ram', 20),
('Sita', 17),
('Shyam', 22),
('Gita', 19),
('Mohan', 18);
GO



# Add ADO.NET Entity Data Model (Database First)

1. **Right-click your project** in Solution Explorer → choose **Add → New Item…**

2. In the **Add New Item** window:  
   - Select **Data** on the left panel.  
   - Choose **ADO.NET Entity Data Model**.  
   - In the **Name** field, type:  
     ```
     DatabaseFirstModel.edmx
     ```  
     (This will be the name of your EDMX file.)  
   - Click **Add**.

3. In the **Entity Data Model Wizard** window:  
   - Select **EF Designer from database**.  
   - Click **Next**.

4. **Choose your database connection**:  
   - Select an existing connection or create a new connection to your database (e.g., `DatabaseFirstDB` in SSMS).  
   - Test the connection to make sure it works.  
   - Click **Next**.

5. **Choose database objects**:  
   - Expand the **Tables** node.  
   - Check the tables you want to include (e.g., `Students`).  
   - You can also include **Views** or **Stored Procedures** if needed.  
   - Click **Finish**.

6. **Visual Studio generates**:  
   - The **Entity Framework context class**:  
     ```
     DatabaseFirstDBEntities
     ```  
   - Entity classes for each table:  
     ```
     Student
     ```  
   - The **EDMX design diagram** showing tables and relationships.

7. After this step, your project can use **Database First EF** to query, insert, update, and delete data using the generated context and entity classes.

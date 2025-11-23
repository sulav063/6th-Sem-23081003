use Console App

Install-Package Microsoft.EntityFrameworkCore -Version 8.0.8
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.8
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.8

CodeFirst/
│
├─ Data/
│ └─ AppDbContext.cs
│
├─ Models/
│ └─ Student.cs
│
└─ Program.cs

Write models & DbContext →

Build solution →

In console:
Add-Migration InitialCreate

Update-Database

Run your program

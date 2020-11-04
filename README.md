# BookListRazorWebApp

Pretty simple CRUD web appliaction made while learning basics of **ASP.NET Core 3.1** & **Entity Framework**.

It allows to add books to the database and also read, update and remove these.

### #1. Run.
To run this appliaction you have to clone it and open using Visual Studio.
You can change server name in `appsettings.json` file. In my case it is just `localhost`:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Trusted_Connection=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

Now you have to add new migration using **NuGet Package Manager**. To open command line go to the `Tools -> NuGet Package Manager -> Package Manager Console`.
You can add new migration using below command:

`add-migration InitializeDb`

Now you can create database:

`update-database`

### #2. Add new Book properties & update database.
If you want to describe books using more data (e.g. number of pages) you can just add new poperty to the Book (Book.cs file) model.
After you add new property, add new migration and update database:
`add-migration AddNumberOfPagesToBook`
`update-database`

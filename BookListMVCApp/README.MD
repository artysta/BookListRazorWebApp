# BookListMVCApp

## # Instruction

To run this app...

 - clone repo:

        git clone https://github.com/artysta/BookListRazorWebApp.git
        
 - go to the project directory:

        cd BookListRazorWebApp

 - create database:

        dotnet ef update-database --project ./BookListMVCApp/BookListMVCApp.csproj
 
 - run app:

        dotnet run --project ./BookListMVCApp/BookListMVCApp.csproj

...or just use Visual Studio, but remember to type `update-database` in NuGet Package Manager console to create database.

App should start at `https://localhost:5001/`.

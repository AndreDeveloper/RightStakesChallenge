# RightStakes Challenge

# Get Start
1 - First of all put your sql server connection string in the Default connection field on app.setting.json file
```
"DefaultConnection": "your connection string here"
```
2 - Then you must create data base by executing migrations: 
on visual studio nugget package manager console
```
update-database -v
```
on command prompt
```
dotnet ef database update
```
3 - There we go! just run the project

# Main tecnologies

* Quartz - To Manage Jobs that crawler Apis
* MediatR - To raise and handle notifications
* MemoryCache - To make query faster
* EF Core
* Repository Pattern
* Solid Principes

Did you like? lets take a try!


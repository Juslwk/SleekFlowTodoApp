# SleekFlowTodoApp

## Demo

### Visit https://sleekflowtodo20230119230220.azurewebsites.net/swagger/index.html for demo

#### Create New User through 

`POST /api/User`
```
{
    "UserName": "Justin",
    "Password": "123qwe",
    "Email": "juslwk@gmail.com"
}
```
#### Login and get bearer token

`POST /api/User/BearerToken`
```
{
    "UserName": "Justin2",
    "Password": "123qwe"
}
```
### Set Authorization Bearer Token and set Token from previous step to use these APIS:

#### Get All Todos (of user)

`GET /api/Todo` 
This endpoint implements ODATA for paging and ordering of data, as well as other features
For example
/api/Todo?$select=Id,Name,Description,DueDate,Status,CreationTime&$top=1&$orderby=Id desc&$skip=1
$select parameter will take the Columns Id, Name, Description, DueDate, Status and CreationTime
$top will limit the number of records to 1
$orderby will order by the Id in descending 
$skip will skip 1 record

#### Get a single Todo

`GET /api/Todo/{id}`

#### Create a new Todo

`POST /api/Todo`

#### Update existing Todo

`PUT /api/Todo/{id}`

#### Delete Todo

`DELETE /api/Todo/{id}`


## Explanation

### Technology Stack 
- ASP.NET Core (.NET 7) to handle HTTP requests
- Entity Framework Core to interact with database
- SQL Server for database
- AspNetCore Identity for User Identity
- JWT for Authentication
- OData for Paging and Ordering
- Swashbuckle for Swagger documentation
- XUnit as Testing Framework
- Moq for Mocking Framework

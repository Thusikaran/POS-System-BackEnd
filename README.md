# POS System Backend

## Overview
This repository contains the backend code for the POS System, developed using .NET Core 6.0. The backend provides APIs for managing products, categories, and performing Point of Sale (POS) operations.


## Configure SQL Server

### Create a Database:

Open SQL Server Management Studio (SSMS) or any SQL client.
Connect to your SQL Server instance.
Create a new database for the POS System (e.g., POSSystemDb).

### Update Connection String:

- Open appsettings.json in the project root.
- Update the DefaultConnection string:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=POSSystemDb;User Id=YOUR_USER_ID;Password=YOUR_PASSWORD;"
}
```

## Apply Migrations
``` 
dotnet ef migrations add InitialCreate
```
``` 
 dotnet ef database update
```
## Running the Application
- Open a terminal or command prompt in the project directory.
- Run the application:
```
dotnet run
```
- Access the APIs at http://localhost:5000/api.
  
## API Endpoints
 ### Order Products
- Endpoint: POST /api/POS/orderProducts
- Description: Calculate the total price for the products in the order.
- Request Body:
```
[
  {
    "ProductId": 1,
    "Quantity": 2
  },
  {
    "ProductId": 2,
    "Quantity": 1
  }
]
```
- Response:
```
{
  "TotalPrice": 150.00
}
```









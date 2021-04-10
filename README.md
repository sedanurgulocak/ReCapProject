# ReCapProject : Car Rental System
![PicsArt_03-10-02 23 16](https://user-images.githubusercontent.com/64933639/110552166-e041c580-8147-11eb-8edf-e7f790ca7baf.jpg)

:red_car: This repository includes the backend of the car rental system.

## :tada: Getting Started

The project was developed in C#, in accordance with the multi-layered architecture and SOLID principles. CRUD operations were performed using the Entity Framework. MSSQL Localdb was used for database in the project.
Implementations of JWT; Transaction, Cache, Validation and Performance aspects have been implemented. Fluent Validation support for Validation, 
Autofac support for IoC added.

#### Technologies
- .NET Core
- Asp.NET for Restful Api
- MsSql
- Entity Framework Core
- Autofac
- Fluent Validation

#### Techniques
- Layered Architecture Design Pattern
- AOP
- JWT
- IOC
- Autofac Dependency Resolver


## :books: Layers
N-tier application architecture provides a flexible and reusable application model. For this reason, Layered Architecture Design Pattern was used in the car rental system.

![Layers](https://user-images.githubusercontent.com/64933639/114248291-ff7a7f80-999f-11eb-8813-578c131eefbd.png)


### :orange_book: [Entities Layer](https://github.com/sedanurgulocak/ReCapProject/tree/master/Entities)
In this layer, the main classes to be used in the project are specified, that is, it is where the real objects are specified. <br/>
:open_file_folder: Concrete folder: Each of the classes in the concrete folder corresponds to a table in the database. <br/>
:open_file_folder: DTOs folder: Each of the classes in the DTOs folder contains DTO (Data Transfer Object) classes into which data from different tables are combined. <br/>

![Entities](https://user-images.githubusercontent.com/64933639/114242390-7eb58680-9993-11eb-9c87-1ed5cda98ab7.png)

### :green_book: [Data Access Layer](https://github.com/sedanurgulocak/ReCapProject/tree/master/DataAccess)
In this layer, database connections and database operations are performed. Required configuration for database connection is done here. The task of this layer is to perform database CRUD operations. <br/>
:open_file_folder: Abstract folder: Abstract objects are found <br/>
:open_file_folder: Concrete folder: There are concrete objects for the Entity Framework, the context object, and the concrete objects for InMemory <br/>

![DataAccess](https://user-images.githubusercontent.com/64933639/114242674-f84d7480-9993-11eb-938a-323121c42650.png)

### :blue_book: [Business Layer](https://github.com/sedanurgulocak/ReCapProject/tree/master/Business)
It is the layer where business rules are defined and controlled,  that will take the data taken into the project by Data Access and process it. When a command comes to the program, what actions it should perform and which set of rules it should pass through are defined here. The data from the user first goes to the Business layer, and then processed and transferred to the Data Access layer. Business layer also specifies who will access these data. <br/>
:open_file_folder: Abstract folder: Services have abstract objects <br/>
:open_file_folder: Concrete folder: There are concrete service objects <br/>
:open_file_folder: Constants folder: Class of informative messages as a result of the transaction <br/>
:open_file_folder: BusinessAspects: Security operations management <br/>
:open_file_folder: DependencyResolvers: To create an instance <br/>
:open_file_folder: ValidationRules: Validation rules management <br/>

![Business](https://user-images.githubusercontent.com/64933639/114242943-6003bf80-9994-11eb-8809-5385caf66689.png)

### :closed_book: [Core Layer](https://github.com/sedanurgulocak/ReCapProject/tree/master/Core)
It is a universal layer with common codes. The core layer does not reference other layers, it is independent of the project. Items to be used in the core layer are classified according to other layers and their intended use. <br/>
![Core](https://user-images.githubusercontent.com/64933639/114253563-62c1dd00-99b3-11eb-9c56-4e5d95fbc603.png)

:open_file_folder: Aspects folder:  <br/>
![Core-1](https://user-images.githubusercontent.com/64933639/114253586-779e7080-99b3-11eb-9aa0-f37a9836345a.png)

:open_file_folder: CrossCuttingConcerns folder:  <br/>
![Core-2](https://user-images.githubusercontent.com/64933639/114253613-7ff6ab80-99b3-11eb-95a6-0ccbe40ac1d1.png)

:open_file_folder: DataAccess folder: <br/>
![Core-3](https://user-images.githubusercontent.com/64933639/114253623-87b65000-99b3-11eb-9e69-08f57f5f9b66.png)

:open_file_folder: DependencyResolvers folder: <br/>
![Core-4](https://user-images.githubusercontent.com/64933639/114253624-8edd5e00-99b3-11eb-85f2-e2cf80267f59.png)

:open_file_folder: Entities folder: <br/>
![Core-5](https://user-images.githubusercontent.com/64933639/114253630-969d0280-99b3-11eb-9797-b626a30cabc5.png)

:open_file_folder: Extensions folder: <br/>
![Core-6](https://user-images.githubusercontent.com/64933639/114253635-9d2b7a00-99b3-11eb-87a2-c1e20e0a45a8.png)

:open_file_folder: Utilities folder: <br/>
![Core-7](https://user-images.githubusercontent.com/64933639/114253646-a3b9f180-99b3-11eb-9949-572c08f9e864.png)


### :open_book: [Web API](https://github.com/sedanurgulocak/ReCapProject/tree/master/WebAPI)
It is the part where the services that enable the Front-End part and other platforms to communicate with the program and perform operations are written.

![WebApi](https://user-images.githubusercontent.com/64933639/114243195-d86a8080-9994-11eb-80fa-3b6c3066defb.png)

## :floppy_disk: Database
![Database3](https://user-images.githubusercontent.com/64933639/114242441-8ecd6600-9993-11eb-9a76-6d34eb2ba565.png)



## :package: Prerequisites
```
Autofac v6.1.0
Autofac.Extensions.DependencyInjection v7.1.0
Autofac.Extras.DynamicProxy v6.0.0
FluentValidation v9.5.1
Microsoft.AspNetCore.Authentication.JwtBearer v3.1.12
Microsoft.AspNetCore.Http v2.2.2
Microsoft.EntityFrameworkCore.SqlServer v3.1.1
Microsoft.Extensions.DependencyInjection v5.0.1
Microsoft.IdentityModel.Tokens v6.8.0
NETStandart.Library v2.0.3
Newtonsoft.Json v13.0.1
System.IdentityModel.Tokens.Jwt v6.8.0

```


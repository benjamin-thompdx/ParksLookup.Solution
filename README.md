# _Parks Lookup API_

#### By _**Benjamin Thom**_


## Description

_An ASP.NET API that allows users to create, read, update, and delete state and national parks, categorized by parks and their unique details._


## Setup/Installation Requirements

### 1.  Install .NET Core

#### on macOS:
* [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download a .NET Core SDK from Microsoft Corp.

#### on Windows:
* [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp.

#### Install dotnet script
Enter the command ``dotnet tool install -g dotnet-script`` in Terminal (macOS) or PowerShell (Windows).

### 2. Clone this repository

Enter the following commands in Terminal (macOS) or PowerShell (Windows):
```sh
cd desktop
git clone https://github.com/benjamin-thompdx/ParksLookup.Solution
cd ParksLookup.Solution
```
### 3. Install all necessary packages and make sure the project will build
In your terminal, type the following commands to make sure all necessary packages are included in the project and to launch in your browser:
```sh
cd ParksLookup
dotnet restore
dotnet build
```

### 4. Update the database and tables
Enter the following to update your database and tables for the program:
```sh
dotnet ef database update
```

### 5. Launch the project in your browser
In your terminal, type:
```sh
dotnet watch run
```
Hold ```command``` while clicking the link in your local terminal to your local address, which should be:
```sh
http://127.0.0.1:5000
```

## API Endpoints
_Once you have installed this program, you can use these endpoints on your local host in your browser._

Base URL: ```https://localhost:5000```

### Users

See all users and get user authentication.

#### HTTP Requests
```sh
GET /users/
POST /users/authenticate
```

No additonal parameters for this route!

### Parks

Interact with the data for state and national parks.

#### HTTP Requests
```sh
GET /api/parks
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
```
#### Path Parameters
| Parameter | Type | Default | Description |
| :---: | :---: | :---: | --- |
| management | string | none | Returns matches by a park's management type.
| name | string | none | Returns all parks by name. |
| location | string | none | Returns all parks in specified location. |

#### Example Query
```sh
https://localhost:5000/api/parks/?management=national&name=death+valley&location=death+valley+ca%2Cnv
```

### Details

Interact with the data for park-specific details.

#### HTTP Requests
```sh
GET /api/details
POST /api/details
GET /api/details/{id}
PUT /api/details/{id}
DELETE /api/details/{id}
```

#### Path Parameters
| Parameter | Type | Default | Description |
| :---: | :---: | :---: | --- |
| Description | string | none | Returns park description. |
| Address | string | none | Returns park physical address. |
| Rating | int | none | Returns all parks wth a specific rating value between 1 and 5. |

#### Example Query
```sh
https://localhost:5000/api/details/?description=death+valley+is+the+largest+u.s.+national+park+outside+alaska+at+3.4+million+acres&address=po+box+579+death+valley%2Cca+92328&rating=5
```



## Known Bugs

_No known bugs at this time._

## Support and contact details

_Have a bug or an issue with this application? [Open a new issue](https://github.com/benjamin-thompdx/ParksLookup.Solution/issues) here on GitHub._

## Technologies Used
* _C#_
* _.NET Core 2.2_
* _ASP.NET Core MVC_
* _MySQL 2.2.0_
* _EF Core 2.2.0_
* _ASP.NET Core Identity_
* _Razor 2.2.0_
* _ASP.NET Core JSON Web Token Authentication & Authorization_
* _NSwag 13.3.0_
* _[Postman](postman.com)_

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2020 **_Benjamin Thom_**
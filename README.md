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

## Further Exploration
### JWT Authentication
To view the source code for JWT authentication within the ParksLookup.Solution project directory, navigate to:
 * ```ParksLookup.Solution/ParksLookup/Startup.cs```
      ```
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });
      ```
 * ```ParksLookup.Solution/ParksLookup/Services/UserService.cs```

_Make sure the application is runnning, open Postman, and perform the folowing commands:_

1. Create POST request ```http://localhost:5000/users/authenticate```

2. Within the body of your POST request insert the following: (Note: the body should be set to "raw" and "JSON")
    ```
    {
      "username": "bthom",
      "password": "mypassword"
    }
    ```

3. Press the ```Send``` button

    _Now you should see a ```status: 200 OK``` message and a similar response in the body of your POST request:_
    ```
    {
        "id": 1,
        "firstName": "Benjamin",
        "lastName": "Thom",
        "username": "bthom",
        "password": null,
        "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODY1NTM1NzAsImV4cCI6MTU4NzE1ODM3MCwiaWF0IjoxNTg2NTUzNTcwfQ.O0E71waveE2HncO6b8CQteNTQzkmwM6t5Hnqv45fwmc",
        "details": null
    }
    ```
4. ```Copy``` the token recieved in step 3

      Example token:
      ```eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODY1NTM1NzAsImV4cCI6MTU4NzE1ODM3MCwiaWF0IjoxNTg2NTUzNTcwfQ.O0E71waveE2HncO6b8CQteNTQzkmwM6t5Hnqv45fwmc```

5. Create GET request ```http://localhost:5000/api/parks```
6. Navigate to the "authorization" tab in your GET request,   click the "type" dropdown menu and select "OAuth 2.0", ```paste``` the token from step 4 into the "Access Token" input box, and hit "Send" on the GET request
7. _Now you should see a ```status: 200 OK``` message and a similar response in the body of your GET request:_
    ```
    [
        {
            "parkId": 1,
            "management": "National",
            "name": "Great Basin National Park",
            "location": "Baker, NV",
            "details": []
        },
        {
            "parkId": 2,
            "management": "National",
            "name": "Tule Springs Fossil Beds National Monument",
            "location": "Las Vegas, NV",
            "details": []
        },
        {
            "parkId": 3,
            "management": "State",
            "name": "Sand Harbor",
            "location": "Incline Village, NV",
            "details": []
        },
        {
            "parkId": 4,
            "management": "State",
            "name": "Van Sickle",
            "location": "South Lake Tahoe, CA",
            "details": []
        }
    ]
    ```

### Versioning
To view the source code for Versioning within the ParksLookup.Solution project directory, navigate to:
 * ```ParksLookup.Solution/ParksLookup/Startup.cs```
    ```
    services.AddApiVersioning(config =>
          {
              config.DefaultApiVersion = new ApiVersion(1, 0);
              config.AssumeDefaultVersionWhenUnspecified = true;
              config.ReportApiVersions = true;
          });      
    ```
 _Make sure the application is runnning, open Postman, and perform the folowing commands:_
 
 1. Create GET request ```http://localhost:5000/api/parks``
 2. Press the ```Send``` button

    _Now you should see a ```status: 200 OK``` message_
 3. Navigate to the "Params" tab and you can view the API's current verion in the "api-supported-versions" section


### NSwag
To view the source code for NSwag within the ParksLookup.Solution project directory, navigate to:
 * ```ParksLookup.Solution/ParksLookup/Startup.cs```
 ```
 services.AddSwaggerDocument();
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
* _REST API versioning with ASP.Net Core_
* _[Postman](postman.com)_

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2020 **_Benjamin Thom_**

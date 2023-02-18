# eGames
>
> An online store based on ASP.NET Core MVC

## Features

This web application demonstrates the following features:

- CRUD data operations using EFCore and DbContext
- Authentication and authorization
- Integration with the Zibal payment gateway
- Services and Dependency Injection
- Routing with URL patterns and parameter binding
- Model binding for HTTP requests and form input
- View components for modular and reusable UI components
- Model validation for data input
- Responsive design for optimal viewing on various devices
- And much more...

## Demo

### Home

<div class="picture">
  <img src="https://img001.prntscr.com/file/img001/rlAnvnwWTruYgENfkP5Big.png" alt="Home Picture">
</div>

### Shopping Cart

<div class="picture">
  <img src="https://img001.prntscr.com/file/img001/KAjdHsLLTXO4-p0dgfYMlQ.png" alt="Shopping Cart Picture">
</div>

### Orders

<div class="picture">
  <img src="https://img001.prntscr.com/file/img001/8OtGrKUKQbe_SVK2py0e6w.png" alt="Shopping Cart Picture">
</div>

## Credentials

You can find credentials in [`AppDbInitializer.cs`](https://github.com/AHosseinRnj/eGames/blob/2d0b3a6afddd98cf72e84e9ce0c916d39ab71654/eGames/Data/AppDbInitializer.cs#L185) and change them as you wish

### Admin user

    Username: admin@egames.com
    Password: Admin@123$

### Normal user

    Username: user@egames.com
    Password: User@123$

## Requirements

- .NET 6.0 SDK or later
- MSSQL Server

## Configuration

To use this web application, you'll need to update the connection string in the [`appsettings.json`](https://github.com/AHosseinRnj/eGames/blob/2d0b3a6afddd98cf72e84e9ce0c916d39ab71654/eGames/appsettings.json#L9) file to point to your local or remote database server.

## License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

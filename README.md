# PlayZone MVC Project

PlayZone is a simple web application for managing a list of games, built using ASP.NET Core MVC and Microsoft SQL Server. The app allows users to add, edit, delete, and view game details, including uploading and displaying cover images.
It follows good architectural practices like the Repository Pattern and Unit of Work, making the code clean and easy to maintain.
<h3>Home Page</h3>
<p>
  <img src="https://i.imgur.com/Q525u7Z.png" alt="Home Page Screenshot" width="100%" style="max-width: 800px; border-radius: 10px; margin-bottom: 30px;" />
</p>

<h3>Games page - Details - Create - Edit</h3>

<table>
  <tr>
    <td><img src="https://i.imgur.com/Ta3NBQ4.png" alt="Games Page Screenshot" width="100%" style="border-radius: 10px;" /></td>
    <td><img src="https://i.imgur.com/ZgTaNm6.png" alt="Game Details Screenshot" width="100%" style="border-radius: 10px;" /></td>
  </tr>
  <tr>
    <td><img src="https://i.imgur.com/szHMX58.png" alt="Create Game Screenshot" width="100%" style="border-radius: 10px;" /></td>
    <td><img src="https://i.imgur.com/go5YSYK.png" alt="Edit Game Screenshot" width="100%" style="border-radius: 10px;" /></td>
  </tr>
</table>

## Features

- Add, edit, delete, and view game details using the `GamesController`.
- Display games on the home page using the `HomeController` with detailed view for each game.
- Upload and preview game cover images.
- Uses Microsoft SQL Server for data storage.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- Repository Pattern
- Generic Repository Pattern
- Unit of Work Pattern
- Bootstrap and basic UI styling

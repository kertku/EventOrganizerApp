# Event Organizer App

### Author:Kert Kullerkann

## How To Run

* Clone the project
* Open solution in Visual Studio
* Set .WebApp project as Startup Project and build the project.
* Run the application.
* The EventOrganizerApp uses Sqlite db.
  For testing purposes no external db connection is needed.
* Payment types can be added from page URL/admin/paymenttypes

## Information

### Architecture

* DOMAIN
* SQL – DataBase/Tables
* EF – DbContext/DbSet’s
* DAL – UOW/Repositories

### Other information

- Since the project is mostly CRUD operations, BLL(Business logic layer) or other layers where not created.
- Database model diagram is included. I made two different objects from Individual user and business user.
  But it can also be made by one user table via inheritance.
- Bootstrap is used for CSS
- Since my personal pc uses Ubuntu operation system, the JetBrains Rider IDE was used instead of Visual Studio.

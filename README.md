# BOOK READING EVENT MANAGEMENT SYSTEM GUIDELINES

This is a Asp.Net Web Application (.NET Framework) which serves the purpose of managing book reading events. It has functions like creating an event, editing and deleting events, booking an event, viewing user events, adding comments for events etc.


## STEPS TO CREATE DATABASE

### Microsoft SQL Server

1. On the left side of ms sql server window, you will see Object Explorer.
2. Right click on Databases Folder and choose the option New Database.
3. A window will open. Give the name BookEventManagement to your database and click ok.
4. Click on Databases. You will notice that a new database has been created with the name BookEventManagement.

### Visual Studio

1. Go to solution explorer which is on the right hand side of your Visual Studio Window.
2. In the solution explorer, you will see 5 folders i.e. Presentation,Business Domain, Data, Shared and Tests.
3. Open Data Folder. Open project Nagarro.BookEventManagement.EntityDataModel.
4. You will see a file named BookEventManagement.edmx in this project. This is an XMl file that defines your entity data model.
5. Right-click anywhere in the designer window and choose the option Generate Database from Model. Click on Finish.
6. Now go back to MS SQL Server and check if the tables are created in your database BookEventManagementSystem.
7. Repeat the above steps if any error occurs while creation.

### Database Configuration Settings

1. In the project Nagarro.BookEventManagement.EntityDataModel, you will see a file named App.config. It is located just above your .edmx file.
2. Open this file and copy the data between <connectionStrings> and </connectionStrings> tags i.e.
<add name="BookEventManagementEntities"/>
3. Go to Presentation folder and open the project Nagarro.BookEventManagement. Open Web.config file of this project.
4. In this file also, you will see <connectionStrings> and 
</connectionStrings> tags. 
5. Remove the <add name="BookEventManagementEntities"> tag from this code and paste the newly created <add name="BookEventManagementEntites"/> tag here.

### You are good to go !!!


### STEPS FOR RUNNING THE APPLICATION
1. In the presentation folder, locate Nagarro.BookEventManagement project. Right-click on this project and choose the option Set as StartUp Project.

2. Go to build menu in your visual studio and choose the option Build Solution.

3. Now click on Run Button with the name IIS Express and your application will start running.

### ADMIN VIEW OF APPLICATION

1. Click on LogIn option on the right hand side of the navigation panel of the application.

2. Choose the option Register As a New User.

3. Create a new user with the email id myadmin@bookevents.com.
This is the admin of the application. He/She can edit/delete all events and view private events on the event dashboard. He can also see the users who registered for the individual event by clicking the button View Users of Event available in details Page of the event.

4. Log off and create new users with different email-id's to see the difference between admin view and normal user view.

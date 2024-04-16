# Chinook Razor
## Description:
Chinook Razor is a project that is meant to utilize a database library and showcase different ways of accessing and presenting this data onto both Razor pages and Blazor pages. Each of these projects will be further discussed within the README.md.
This folder contains three separate project folders:
- ChinookLibrary
  - This project folder contains the database library and DBUtility file that will hold all the functions used to collect and store the data
- BlazorChinookWebsite
  - This project folder contains the Blazor Web App and pages code used to showcase the DBUtility functions as a Web App 
- ChinookRazorPages
  - This project folder contains the Razor pages and code used to showcase the DBUtility functions through this language
<br>

### Chinook Library
Before Run:
- In the terminal, run the line "dotnet restore ChinookLibrary.csproj" to rebuild the library
- This is to be used in parallel with either the Blazor Chinook Website or the Chinook Razor Pages
- This project is not to be run solo, but before running either of the other components build the library so that it is up to date and loaded.

The focus of this library is to use a database that stores artists, composers, songs, song price, genres and many other aspects but it is essentially a music database. The DBUtility file is where the code is written to use SQL to search this database and compile lists with specific information, such as lists of songs from a genre or songs from an artist.

<br>

### Blazor Chinook Website
Before Run:
- In the terminal, run the line "dotnet restore BlazorChinookWebsite.csproj" to rebuild the project
- This can only be run once this and the library is rebuilt using their respective terminal lines

The focus of this is the Pages folder within the Components folder. Within those pages there is code written to utilize the functions from DBUtility and to showcase them either as lists generated after a button is pressed, drop down lists, as well as a drop down list that is generated using AI functionality.

<br>

### Chinook Razor Pages
Before Run:
- In the terminal, run the line "dotnet restore ChinookRazorPages.csproj" to rebuild the project
- This an only be run once this and the library is rebuilt using their respective terminal lines

The focus of this is the Index.cshtml in the Pages folder in the Solution directory and the Index.cshtml.cs file in the Index.cshtml folder. The Index.cshtml.cs has the BindProperties that are used as gets and sets in the Index.cshtml file, and that file includes all the different ways of utilizing the same functions that the Blazor Chinook Website uses but all within a single page using Razor instead of Blazor.

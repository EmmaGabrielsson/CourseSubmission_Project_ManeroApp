# CourseSubmission Project - ManeroApp

## Project Overview
The CourseSubmission Project - Manero is a comprehensive e-commerce website developed by our project group. Below, you'll find details about the project and instructions to explore it.

### Requirements
1. **Scrumboard and Project Tool:** Jira was utilized as our project management tool, with a daily updated scrumboard for task management and daily-standup-meetings.
2. **GitHub Repository:** We maintained a public GitHub repository where all team members collaborated. Continuous Integration (CI) was enabled to streamline the development process.
3. **Sprint Deliveries:** We successfully delivered and showcased at least two sprint deliveries, meeting the project requirements.
4. **Data Storage:** All data, including products and user information, is stored in a SQL Server database. Migrations were used to keep the database structure up to date and traceable in Git.
5. **Responsive Design:** Our website is mobile-friendly and have a responsive design that works across various devices, including tablets and larger screens.
6. **Frontend and Backend:** The frontend is written in ASP.NET, while the backend is developed in C#. We used a temporary local SQL Server database file for data storage.
7. **Unit and Integration Tests:** Chosen features and components have associated unit tests or integration tests to ensure functionality and quality.
8. **Code Formatting:** Throughout the project, we maintained uniform code formatting with clear variable naming and structures to ensure code quality and readability, alongside the addition of activity diagrams and sequence diagrams for selected user stories.


## How to Run the Project 
- Ensure you have the necessary development environment set up for ASP.NET and C#.
- Local installation of SQL Server or SQL Server Express.

### Steps to Test the Project
1. **Clone the Repository:** Use the Git clone command to fetch the completed project from the repository.
    ```
    git clone https://github.com/EmmaGabrielsson/CourseSubmission_Project_ManeroApp.git
    ```
3. **Using Visual Studio:** Open the project in Visual Studio for an integrated development environment (IDE) experience.

4. **Install Dependencies (Optional):**
    - The necessary dependencies are typically restored automatically when building the solution in Visual Studio.
    - If needed, you can manually restore the packages by right-clicking the solution in Visual Studio and selecting "Restore NuGet Packages."

5. **Local Database Setup:**
    - Create a local SQL Server database file.
    - Update the connection string in `appsettings.json` to point to your local database. 
      Example:
      ```json
      "ConnectionStrings": {
        "SqlDatabase": "insert_your_own_connectionstring_here"
      }
      ```
      
6. **Migrations and Database Update:**
    - Open Package Manager Console in Visual Studio.
    - Run the following command to apply migrations and update the database:
      ```
      EntityFrameworkCore\Update-Database
      ```

7. **Run the Project Locally:** Build and run the project in Visual Studio to start the application.

**Note:** Ensure you follow any specific instructions provided within the project's documentation or readme files for successful execution.

Thank you for your interest in our project. We hope you enjoy exploring our work!




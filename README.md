# Expense_Tracker
ASP.Net MVC Core Project

The main goal of creating this system is to manage the daily routine transactions and current balance of the user.

## Instructions to run the application
Whenever user enters into the system then they will be redirected to the home page and if user wants to use any other pages like Category or Transaction then they need to login first into our system.

If user first times enters into the system then they need to Register themselves otherwise they just need to login with their Email, Password.

## After The Successful Aunthentication of the User:
User can create Category and able to see all Categories that are added by them.

There are two types of Category: <br/>
  1) Income <br/>
  2) Expense <br/>

### Category
User can select one of the category and fill the details of that Category into the form and that category should be added in the List of Categories.
Income category represent the income of the user and expense category represent the total expenes of the user that are done by them and they can also add transaction details for these two Categories. 

### Transaction
Similarly User can make the Transaction for the currently available categories and fill the details like Amount, Description and Date of the Transaction and user can also be able to edit the details of the transaction and able to perform CRUD operation and transaction amount can be set in the perticular type of Category eg.Income or Expense.

### Dashboard
In the dashboard user can found one dropdown list:<br/>
There are two options : <br/>
 1) Monthy Expenses <br/>
 2) Weekly Expenses <br/>

User can select one of the option and default selected option is Monthly Expenses. <br/>
According to the selected option user can be able to see the Totl Income, Total Expenses and Total Balance Currently having by them.<br/>
User can see these details in the Two chars also that is Pie Chart and Bar Chart.<br/>
In the end of the dashboard Recent Transaction list is shown to the user that are done by them in the last 5 days.



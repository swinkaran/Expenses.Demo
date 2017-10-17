# Expenses.Demo
Sample project for managing employee expenses


DATABASE
========

There is no database attached. 
The application is following code-first approach and the database will be created when running the appliction first time.
To setup the database, before running the application connection string should be specified in Web.config file.
<connectionStrings>
    <add name="ExpenseEntities" connectionString="########3" providerName="System.Data.SqlClient" />
</connectionStrings>

ASSUMPTIONS
===========

Priority is given to the design & architecture of the applicatin, hence the UI of the application is very minimal.

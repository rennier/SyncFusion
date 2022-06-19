﻿namespace TelerikBlazorApp1.Data
{
    // Connection to SQL Server database, used within Data subfolder.
    // You need to set the connection string in appsettings.json and configure Startup.cs yourself.
    // In startup.cs add the following with the connectionstring name from appsettings.json inplace of YOURCONNECTIONNAME.
    //  var sqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("YOURCONNECTIONNAME"));
    //  services.AddSingleton(sqlConnectionConfiguration);
    public class SqlConnectionConfiguration
    {
        public SqlConnectionConfiguration(string value) => Value = value;
        public string Value { get; }
    }
}


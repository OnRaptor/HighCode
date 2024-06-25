using System.Data.Common;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace HighCode.API.Helpers;

public class CustomDatabaseModelFactory(IDatabaseModelFactory databaseModelFactory) : IDatabaseModelFactory
{
    private static readonly List<string> ExcludedTables = new()
    {
        "_01", "_02", "_03", "_04", "_05", "_06", "_07", "_08", "_09", "_10", "_11", "_12", "_13", "_14", "_15", "_16",
        "_17", "_18", "_19", "_20", "_21", "_22"
    };


    public DatabaseModel Create(string connectionString, DatabaseModelFactoryOptions options)
    {
        var databaseModel = databaseModelFactory.Create(connectionString, options);

        RemoveTables(databaseModel);

        return databaseModel;
    }

    public DatabaseModel Create(DbConnection connection, DatabaseModelFactoryOptions options)
    {
        var databaseModel = databaseModelFactory.Create(connection, options);

        RemoveTables(databaseModel);

        return databaseModel;
    }

    private static void RemoveTables(DatabaseModel databaseModel)
    {
        var tablesToBeRemoved = databaseModel.Tables.Where(x => ExcludedTables.Contains(x.Name)).ToList();

        foreach (var tableToRemove in tablesToBeRemoved) databaseModel.Tables.Remove(tableToRemove);
    }
}
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Wizard.Services;

namespace Sample.Reports;

public sealed class ConnectionProviderService : IConnectionProviderService
{
    public SqlDataConnection LoadConnection(string connectionName)
    {
        throw new NotImplementedException();
    }
}

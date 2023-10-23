using DevExpress.DataAccess.Web;
using DevExpress.DataAccess.Wizard.Services;

namespace Sample.Reports;

public sealed class ConnectionProviderFactory : IConnectionProviderFactory
{
    public IConnectionProviderService Create() =>
        new ConnectionProviderService();

}

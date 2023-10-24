using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Sample.Reports
{
    public partial class SampleReport : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly string connection;

        public SampleReport(string connection)
        {
            this.connection = connection;
            InitializeComponent();
            if (DataSource is SqlDataSource sqlDataSource)
            {
                sqlDataSource.ConfigureDataConnection += DataSource_ConfigureDataConnection;
            }
        }

        private void DataSource_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            var connectionParameters = new CustomStringConnectionParameters(this.connection);
            var ds = new SqlDataSource(connectionParameters);
            e.ConnectionParameters = ds.ConnectionParameters;
        }
    }
}

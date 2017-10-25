using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appSSRS.Reports;

namespace appSSRS.Desktop
{
    public partial class frmMain : Form
    {
        private SqlConnection _sqlConnection;

        public frmMain()
        {
            InitializeComponent();

            // Seteamos path por default
            txtPath.Text = Path.Combine(Application.StartupPath, @"..\..\SQL\p6uj9a000l1o.sql");
            Test_LETargetDate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["NorthStar"].ConnectionString;
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (_sqlConnection.State != ConnectionState.Closed)
                _sqlConnection.Close();
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            if (dialogSQL.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialogSQL.FileName;
            }
        }

        private void btnGetTypes_Click(object sender, EventArgs e)
        {
            /// Info about types:
            ///https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings

            if (!string.IsNullOrWhiteSpace(txtPath.Text))
            {
                try
                {
                    btnGetTypes.Enabled = false;
                    OpenConnection();

                    var sqlQuery = File.ReadAllText(txtPath.Text);

                    // Ejecutamos Consulta
                    var sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlCommand.Connection = _sqlConnection;

                    var dt = new DataTable();
                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add(".NET type", typeof(string));
                    dt.Columns.Add("Allows Null", typeof(string));

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    da.FillSchema(ds, SchemaType.Source, "Test");
                    DataTable dt2 = new DataTable();
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        var row = dt.NewRow();
                        //var sqlType = (SqlDbType)Enum.Parse(typeof(SqlDbType), reader.GetDataTypeName(i), true);
                        row[0] = dc.ColumnName;
                        row[1] = dc.DataType;
                        row[2] = dc.AllowDBNull;

                        dt.Rows.Add(row);
                    }

                    dgvReportData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnGetTypes.Enabled = true;
                    CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Ingrese una consulta SQL");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPath.Text))
            {
                try
                {
                    btnGetData.Enabled = false;
                    OpenConnection();

                    var sqlQuery = File.ReadAllText(txtPath.Text);

                    // Ejecutamos Consulta
                    var sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlCommand.Connection = _sqlConnection;

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    da.Fill(ds, "Query");

                    //TestThirdPartyAuthorizationReport(ds);
                    NorthStarTrusteeServicing(ds);                    

                    MessageBox.Show("Query Executed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnGetData.Enabled = true;
                    CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Ingrese una consulta SQL");
            }
        }

        private void NorthStarTrusteeServicing(DataSet ds)
        {
            var report = new NorthStarTrusteeServicingReport();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DateTime? view_illustration_latest_other_illustration_run_date = null;
                DateTime? date_request_sent_to_carrier = null;

                if (dr["view_illustration_latest_other_illustration_run_date"] != DBNull.Value)
                    view_illustration_latest_other_illustration_run_date = Convert.ToDateTime(dr["view_illustration_latest_other_illustration_run_date"]);

                if (dr["date_request_sent_to_carrier"] != DBNull.Value)
                    date_request_sent_to_carrier = Convert.ToDateTime(dr["date_request_sent_to_carrier"]);

                var result = report.MinPayIllustrationRequestOpen(view_illustration_latest_other_illustration_run_date, date_request_sent_to_carrier);
            }
        }

        private void Test_LETargetDate()
        {
            var uwm = new UWMedsAndLEStatusReport2_Meridian();
            var result = uwm.LETargetDate(new DateTime(2016, 12, 08), new DateTime(2005,10,14,07,0,0), new DateTime(2005, 09, 09, 21, 18, 36));
        }


        private void TestThirdPartyAuthorizationReport(DataSet ds)
        {
            var report = new ThirdPartyAuthorizationReport();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DateTime? date_of_death = null;
                DateTime? payoff_date_service = null;
                DateTime? strike_price_paid = null;
                DateTime? confirmed_lapse_date = null;

                if (dr["date_of_death"] != DBNull.Value)
                    date_of_death = Convert.ToDateTime(dr["date_of_death"]);

                if (dr["payoff_date_service"] != DBNull.Value)
                    payoff_date_service = Convert.ToDateTime(dr["payoff_date_service"]);

                if (dr["strike_price_paid"] != DBNull.Value)
                    strike_price_paid = Convert.ToDateTime(dr["strike_price_paid"]);

                if (dr["confirmed_lapse_date"] != DBNull.Value)
                    confirmed_lapse_date = Convert.ToDateTime(dr["confirmed_lapse_date"]);

                var result = report.GroupBy(date_of_death, dr["policies.owner"].ToString(), dr["program #"].ToString(), confirmed_lapse_date,
                                            dr["ltr_22_month_response"].ToString(), dr["note_purchaser"].ToString(), dr["endorsee"].ToString(),
                                            dr["purchaser"].ToString(), dr["view_best_purchaser_offer_accepted.provider"].ToString(),
                                            dr["kbc_decision"].ToString(), dr["status"].ToString(), payoff_date_service,
                                            dr["program"].ToString(), strike_price_paid, dr["view_policy_consolidated.provider"].ToString(),
                                            dr["original_strike_price_check"].ToString(), dr["adj_strike_price_check"].ToString());
            }

        }

        /// <summary>
        /// Obtiene el tipo de dato de .NET equivalente al tipo de dato SQL
        /// </summary>
        /// <param name="type">SqlType de que se desea obtener su equivalente en .NET</param>
        /// <remarks>
        /// Para mas informacion de los tipos de datos, visitar:
        /// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
        /// </remarks>
        /// <returns>El tipo de dato correspondiente en .NET</returns>
        private Type GeNetType(SqlDbType type)
        {
            switch (type)
            {
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                    return typeof(string);

                case SqlDbType.SmallDateTime:
                case SqlDbType.DateTime:
                case SqlDbType.Date:
                case SqlDbType.DateTime2:
                    return typeof(DateTime);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return typeof(decimal);

                case SqlDbType.BigInt:
                    return typeof(Int64);

                case SqlDbType.Bit:
                    return typeof(bool);

                case SqlDbType.Float:
                    return typeof(double);

                case SqlDbType.Int:
                    return typeof(int);

                case SqlDbType.Real:
                    return typeof(Single);

                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);

                case SqlDbType.TinyInt:
                    return typeof(byte);

                case SqlDbType.Variant:
                    return typeof(object);

                case SqlDbType.Time:
                    return typeof(TimeSpan);

                case SqlDbType.DateTimeOffset:
                    return typeof(DateTimeOffset);
                default:
                    return typeof(string);
            }
        }
    }
}

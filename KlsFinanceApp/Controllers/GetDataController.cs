using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

namespace KlsFinanceApp.Controllers
{
    public class GetDataController : Controller
    {
        // GET: GetData
        public ActionResult Index(string q)
        {
            if (!IsNumeric(q.Trim()))
                throw new ArgumentException("Query isn't a number.  Sorry.");

            DataTable table = GetPortfolio(q);
            return View(table);
        }

        private DataTable GetPortfolio(string mv)
        {
            string query = String.Format("SELECT * FROM dbo.v_MarketValue WHERE market_value > {0} ORDER BY portfolio_id ASC, transaction_date DESC", mv);
            
            using (DataTable table = new DataTable())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                adapter.Fill(table);

                return table;
            }
        }

        private bool IsNumeric(string query)
        {
            float numCheck;
            return float.TryParse(query, out numCheck);
        }
    }
}
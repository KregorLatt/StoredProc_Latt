using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoredProc_Latt.Data;
using StoredProc_Latt.Models;
using System.Text;


namespace StoredProc.Controllers
{
    public class TrainController : Controller
    {
        public StoredProc_LattContext _context;
        public IConfiguration _config { get; }

        public TrainController
            (
            StoredProc_LattContext context,
            IConfiguration config
            )
        {
            _context = context;
            _config = config;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Train> SearchResult()
        {
            var result = _context.Train
                .FromSqlRaw<Train>("spSearchTrains")
                .ToList();

            return result;
        }

        [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrains";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Color = sdr["Color"].ToString();
                    details.Brand = sdr["Brand"].ToString();
                    details.Fuel = sdr["Fuel"].ToString();
                    details.Price = Convert.ToInt32(sdr["Price"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        /// <summary>
        /// SearchPageWithoutDynamicSQL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DynamicSQL(string Color, string Brand, string Fuel, int Price)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrains";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (Color != null)
                {
                    SqlParameter param_fn = new SqlParameter("@Color", Color);
                    cmd.Parameters.Add(param_fn);
                }
                if (Brand != null)
                {
                    SqlParameter param_ln = new SqlParameter("@Brand", Brand);
                    cmd.Parameters.Add(param_ln);
                }
                if (Fuel != null)
                {
                    SqlParameter param_g = new SqlParameter("@Fuel", Fuel);
                    cmd.Parameters.Add(param_g);
                }
                if (Price != 0)
                {
                    SqlParameter param_s = new SqlParameter("@Price", Price);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Color = sdr["Color"].ToString();
                    details.Brand = sdr["Brand"].ToString();
                    details.Fuel = sdr["Fuel"].ToString();
                    details.Price = Convert.ToInt32(sdr["Price"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SearchWithDynamics()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrains";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Color = sdr["Color"].ToString();
                    details.Brand = sdr["Brand"].ToString();
                    details.Fuel = sdr["Fuel"].ToString();
                    details.Price = Convert.ToInt32(sdr["Price"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult SearchWithDynamics(string Color, string Brand, string Fuel, int Price)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrains";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                StringBuilder stringBuilder = new StringBuilder("Select * from Trains where 1 = 1");

                if (Color != null)
                {
                    stringBuilder.Append(" AND Color=@Color");
                    SqlParameter param_fn = new SqlParameter("@Color", Color);
                    cmd.Parameters.Add(param_fn);
                }
                if (Brand != null)
                {
                    stringBuilder.Append(" AND Brand=@Brand");
                    SqlParameter param_ln = new SqlParameter("@Brand", Brand);
                    cmd.Parameters.Add(param_ln);
                }
                if (Fuel != null)
                {
                    stringBuilder.Append(" AND Fuel=@Fuel");
                    SqlParameter param_g = new SqlParameter("@Fuel", Fuel);
                    cmd.Parameters.Add(param_g);
                }
                if (Price != 0)
                {
                    stringBuilder.Append(" AND Price=@Price");
                    SqlParameter param_s = new SqlParameter("@Price", Price);
                    cmd.Parameters.Add(param_s);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Color = sdr["Color"].ToString();
                    details.Brand = sdr["Brand"].ToString();
                    details.Fuel = sdr["Fuel"].ToString();
                    details.Price = Convert.ToInt32(sdr["Price"]);
                    model.Add(details);
                }
                return View(model);
            }
        }


        /// <summary>
        /// DynamicSQLInStoredProcedure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DynamicSQLInStoredProcedure()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrainsGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Color = sdr["Color"].ToString();
                    details.Brand = sdr["Brand"].ToString();
                    details.Fuel = sdr["Fuel"].ToString();
                    details.Price = Convert.ToInt32(sdr["Price"]);
                    model.Add(details);
                }
                return View(model);
            }
        }


        /// <summary>
        /// DynamicSQLInStoredProcedure
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DynamicSQLInStoredProcedure(string Color, string Brand, string Fuel, int Price)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchTrainsGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (Color != null)
                {
                    SqlParameter param = new SqlParameter("@Color", Color);
                    cmd.Parameters.Add(param);
                }
                if (Brand != null)
                {
                    SqlParameter param = new SqlParameter("@Brand", Brand);
                    cmd.Parameters.Add(param);
                }
                if (Fuel != null)
                {
                    SqlParameter param = new SqlParameter("@Fuel", Fuel);
                    cmd.Parameters.Add(param);
                }
                if (Price != 0)
                {
                    SqlParameter param = new SqlParameter("@Price", Price);
                    cmd.Parameters.Add(param);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Train> model = new List<Train>();
                while (sdr.Read())
                {
                    var details = new Train();
                    details.Color = sdr["Color"].ToString();
                    details.Brand = sdr["Brand"].ToString();
                    details.Fuel = sdr["Fuel"].ToString();
                    details.Price = Convert.ToInt32(sdr["Price"]);
                    model.Add(details);
                }
                return View(model);
            }
        }
    }
}

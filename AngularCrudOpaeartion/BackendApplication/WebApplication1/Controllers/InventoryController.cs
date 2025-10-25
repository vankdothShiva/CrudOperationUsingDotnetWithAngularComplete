using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        string config = "Data Source=MKRISHNA;Initial Catalog=siva;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


        [HttpPost]
        public ActionResult saveInventory(invertory invertory)
        {
            SqlConnection con = new SqlConnection()
            {
                ConnectionString = config
            };
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "sp_SAveInventoryData",
                CommandType = CommandType.StoredProcedure,
                 Connection = con
            };
            cmd.Parameters.AddWithValue("@ProductId", invertory.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", invertory.ProductName);
            cmd.Parameters.AddWithValue("@AvailableQty", invertory.AvailableQuantity);
            cmd.Parameters.AddWithValue("@ReOrderPoint", invertory.RecordsPoints);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok(new { message = "data Inserted" });
        }

        [HttpGet]
        public ActionResult GetData()
        {
            List<invertory> list = new List<invertory>();
            SqlConnection con = new SqlConnection()
            {
                ConnectionString = config
            };
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "sp_GetData",
                CommandType = CommandType.StoredProcedure,
                Connection = con
            };
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                invertory inv = new invertory();
                inv.ProductId = Convert.ToInt32(sdr["ProductId"]);
                inv.ProductName = sdr["ProductName"].ToString();
                inv.AvailableQuantity = Convert.ToInt32(sdr["AvailableQty"]);
                inv.RecordsPoints = Convert.ToInt32(sdr["ReOrderPoint"]);
                list.Add(inv);
            }
            con.Close();
            return Ok(list);
        }

        [HttpDelete]
        public ActionResult DeleteData(int ProductId)
        {
            SqlConnection con = new SqlConnection()
            {
                ConnectionString = config
            };
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "sp_DeleteData",
                CommandType = CommandType.StoredProcedure,
                Connection = con
            };
            con.Open();
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok(new { message = "data deleted" });
        }


        [HttpPut]
        public ActionResult UpdateData(invertory invertory)
        {
            SqlConnection con = new SqlConnection()
            {
                ConnectionString = config
            };
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "sp_UpadteData",
                CommandType = CommandType.StoredProcedure,
                Connection = con
            };
            cmd.Parameters.AddWithValue("@ProductId", invertory.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", invertory.ProductName);
            cmd.Parameters.AddWithValue("@AvailableQty", invertory.AvailableQuantity);
            cmd.Parameters.AddWithValue("@ReOrderPoint", invertory.RecordsPoints);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Ok("data updated");
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QueryDbWebApi.Model;

namespace QueryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly SqlConnection _connection;

        public VehiclesController(SqlConnection connection)
        {
            _connection = connection;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>>  GetAllVehicles()
        {
            string query = "SELECT * FROM Vehicle";
            await _connection.OpenAsync();
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Vehicle> vehicles = new List<Vehicle>();
            while (reader.Read())
            {
                Vehicle vehicle = new Vehicle();
                vehicle.Id = (int)reader["Id"];
                vehicle.Make = reader["Make"].ToString();
                vehicle.Model = reader["Model"].ToString();
                vehicle.YearMake = reader["YearMake"].ToString();
                vehicles.Add(vehicle);
            }
            return Ok(vehicles);

        }

    }
}

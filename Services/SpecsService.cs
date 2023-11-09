using System.Data.SqlClient;
using CompareBikes.Models;

namespace CompareBikes.Services
{
    public class SpecsService
    {
        public static IEnumerable<Specs> getBikeSpecs(string brand, string model, int year, IConfiguration configuration)
        {
            string sqlCommand = $"SELECT * FROM all_bikes WHERE brand = '{brand}' AND model = '{model}' AND year = {year}";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("ServerConnection"));
            cnn.Open();
            SqlCommand command = new SqlCommand(sqlCommand, cnn);
            SqlDataReader reader = command.ExecuteReader();

            List<Specs> specsList = new List<Specs>();
            while (reader.Read())
            {
                Specs specs = new Specs();
                specs.Id = reader.GetInt32(0);
                specs.Brand = reader.GetString(1);
                specs.Model = reader.GetString(2);
                specs.Year = reader.GetInt32(3);
                specs.Type = reader.GetString(4);
                specs.Rating = reader.GetValue(5) != DBNull.Value ? reader.GetDouble(5) : null;
                specs.Displacement_ccm = reader.GetValue(6) != DBNull.Value ? reader.GetString(6) : null;
                specs.Power_hp =  reader.GetValue(7) != DBNull.Value ? reader.GetDouble(7) : null;
                specs.Torque_nm =  reader.GetValue(8) != DBNull.Value ? reader.GetDouble(8) : null;
                specs.Engine_cylinder =  reader.GetValue(9) != DBNull.Value ? reader.GetString(9) : null;
                specs.Engine_stroke = reader.GetValue(10) != DBNull.Value ? reader.GetString(10) : null;
                specs.Gearbox = reader.GetValue(11) != DBNull.Value ? reader.GetString(11) : null;
                specs.Bore_mm = reader.GetValue(12) != DBNull.Value ? reader.GetDouble(12) : null;
                specs.Stroke_mm = reader.GetValue(13) != DBNull.Value ? reader.GetString(13) : null;
                specs.Fuel_capacity_lts = reader.GetValue(14) != DBNull.Value ? reader.GetDouble(14) : null;
                specs.Fuel_system =  reader.GetValue(15) != DBNull.Value ? reader.GetString(15) : null;
                specs.Fuel_control = reader.GetValue(16) != DBNull.Value ? reader.GetString(16) : null;
                specs.Cooling_system =  reader.GetValue(17) != DBNull.Value ? reader.GetString(17) : null;
                specs.Transmission_type = reader.GetValue(18) != DBNull.Value ? reader.GetString(18) : null;
                specs.Dry_weight_kg = reader.GetValue(19) != DBNull.Value ? reader.GetDouble(19) : null;
                specs.Wheelbase_mm = reader.GetValue(20) != DBNull.Value ? reader.GetInt32(20) : null;
                specs.Seat_height_mm = reader.GetValue(21) != DBNull.Value ? reader.GetInt32(21) : null;
                specs.Front_brakes = reader.GetValue(22) != DBNull.Value ? reader.GetString(22) : null;
                specs.Rear_brakes = reader.GetValue(23) != DBNull.Value ? reader.GetString(23) : null;
                specs.Front_tire = reader.GetValue(24) != DBNull.Value ? reader.GetString(24) : null;
                specs.Rear_tire = reader.GetValue(25) != DBNull.Value ? reader.GetString(25) : null;
                specs.Front_suspension =  reader.GetValue(26) != DBNull.Value ? reader.GetString(26) : null;
                specs.Rear_suspension = reader.GetValue(27) != DBNull.Value ? reader.GetString(27) : null;
                specs.Color_options = reader.GetValue(28) != DBNull.Value ? reader.GetString(28) : null;
                specsList.Add(specs);
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
            return specsList;
        }
    }
}

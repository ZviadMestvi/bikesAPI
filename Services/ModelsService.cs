using System.Data.SqlClient;
using CompareBikes.Models;
using Microsoft.Extensions.Configuration;


namespace CompareBikes.Services
{
    public class ModelsService
    {
        public static readonly string connectionString = "Server=DESKTOP-IN85QMH;Database=bikes;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true;";

        /* Get list of models with brand, year and type filter */
        public static IEnumerable<Model> GetModelsList(string brand, int? year, string? type, IConfiguration configuration)
        {
            string yearInput = year != null ? $"AND year = '{year}'" : "";
            string typeInput = type != null ? $"AND category = '{type}'" : "";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT id, brand, model, year, category FROM all_bikes WHERE brand = '{brand}' {yearInput} {typeInput} ORDER BY model ASC", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while (dataReader.Read())
            {
                Model model = new Model();
                model.Id = dataReader.GetInt32(0);
                model.Brand = dataReader.GetString(1);
                model.Name = dataReader.GetString(2);
                model.Year = dataReader.GetInt16(3);
                model.Type = dataReader.GetString(4);
                modelsList.Add(model);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return modelsList;
        }

        /* Get list of models from specific year range */
        public static IEnumerable<Model> GetModelsListByYear(string brand, string? type, int min, int max, IConfiguration configuration)
        {
            string typeInput = type != null ? $"AND category = '{type}'" : "";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT id, brand, model, year, category FROM all_bikes WHERE brand = '{brand}' {typeInput} AND year BETWEEN {min} AND {max} ORDER BY model ASC", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while (dataReader.Read())
            {
                Model model = new Model();
                model.Id = dataReader.GetInt32(0);
                model.Brand = dataReader.GetString(1);
                model.Name = dataReader.GetString(2);
                model.Year = dataReader.GetInt16(3);
                model.Type = dataReader.GetString(4);
                modelsList.Add(model);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return modelsList;
        }

        /* Get list of models from specific power range */
        public static IEnumerable<Model> GetModelsListByPower(string brand, string? type, int min, int max, IConfiguration configuration)
        {
            string typeInput = type != null ? $"AND category = '{type}'" : "";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT id, brand, model, year, category FROM all_bikes WHERE brand = '{brand}' {typeInput} AND power_hp BETWEEN {min} AND {max} ORDER BY brand ASC", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while (dataReader.Read())
            {
                Model model = new Model();
                model.Id = dataReader.GetInt32(0);
                model.Brand = dataReader.GetString(1);
                model.Name = dataReader.GetString(2);
                model.Year = dataReader.GetInt16(3);
                model.Type = dataReader.GetString(4);
                modelsList.Add(model);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return modelsList;
        }

        /* Get list of models with search query */
        public static IEnumerable<Model> GetSearchResultsList(string value, IConfiguration configuration)
        {
            string trimmedValue = value.Trim();
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT id, brand, model, year, category FROM all_bikes WHERE model LIKE '%{trimmedValue}%' ORDER BY model ASC", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while (dataReader.Read())
            {
                Model model = new Model();
                model.Id = dataReader.GetInt32(0);
                model.Brand = dataReader.GetString(1);
                model.Name = dataReader.GetString(2);
                model.Year = dataReader.GetInt16(3);
                model.Type = dataReader.GetString(4);
                modelsList.Add(model);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return modelsList;
        }

        /* Get list of models of specific brand with search query */
        public static IEnumerable<Model> GetSearchedModelsList(string brand, string value, IConfiguration configuration)
        {
            string trimmedValue = value.Trim();
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT id, brand, model, year, category FROM all_bikes WHERE brand = '{brand}' AND model LIKE '%{trimmedValue}%' ORDER BY model ASC", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while (dataReader.Read())
            {
                Model model = new Model();
                model.Id = dataReader.GetInt32(0);
                model.Brand = dataReader.GetString(1);
                model.Name = dataReader.GetString(2);
                model.Year = dataReader.GetInt16(3);
                model.Type = dataReader.GetString(4);
                modelsList.Add(model);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return modelsList;
        }

        /* Get bike's specifications */
        public static IEnumerable<BikeSpecs> GetBikeSpecsList(string modelName, int year, IConfiguration configuration)
        {
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM all_bikes WHERE model = '{modelName}' AND year = {year}", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<BikeSpecs> bikeSpecs = new List<BikeSpecs>();
            while (dataReader.Read())
            {
                BikeSpecs specs = new BikeSpecs();
                specs.Id = dataReader.GetInt32(0);
                specs.Brand = dataReader.GetString(1);
                specs.Model = dataReader.GetString(2);
                specs.Year = dataReader.GetInt16(3);
                specs.Type = dataReader.GetString(4);
                specs.Rating = dataReader.GetValue(5) != DBNull.Value ? dataReader.GetDouble(5) : null;
                specs.Displacement_ccm = dataReader.GetValue(6) != DBNull.Value ? dataReader.GetString(6) : null;
                specs.Power_hp = dataReader.GetValue(7) != DBNull.Value ? dataReader.GetDouble(7) : null;
                specs.Torque_nm = dataReader.GetValue(8) != DBNull.Value ? dataReader.GetDouble(8) : null;
                specs.Engine_cylinder = dataReader.GetValue(9) != DBNull.Value ? dataReader.GetString(9) : null;
                specs.Engine_stroke = dataReader.GetValue(10) != DBNull.Value ? dataReader.GetString(10) : null;
                specs.Gearbox = dataReader.GetValue(11) != DBNull.Value ? dataReader.GetString(11) : null;
                specs.Bore_mm = dataReader.GetValue(12) != DBNull.Value ? dataReader.GetDouble(12) : null;
                specs.Stroke_mm = dataReader.GetValue(13) != DBNull.Value ? dataReader.GetString(13) : null;
                specs.Fuel_capacity_lts = dataReader.GetValue(14) != DBNull.Value ? dataReader.GetDouble(14) : null;
                specs.Fuel_system = dataReader.GetValue(15) != DBNull.Value ? dataReader.GetString(15) : null;
                specs.Fuel_control = dataReader.GetValue(16) != DBNull.Value ? dataReader.GetString(16) : null;
                specs.Cooling_system = dataReader.GetValue(17) != DBNull.Value ? dataReader.GetString(17) : null;
                specs.Transmission_type = dataReader.GetValue(18) != DBNull.Value ? dataReader.GetString(18) : null;
                specs.Dry_weight_kg = dataReader.GetValue(19) != DBNull.Value ? dataReader.GetDouble(19) : null;
                specs.Wheelbase_mm = dataReader.GetValue(20) != DBNull.Value ? dataReader.GetInt32(20) : null;
                specs.Seat_height_mm = dataReader.GetValue(21) != DBNull.Value ? dataReader.GetInt32(21) : null;
                specs.Front_brakes = dataReader.GetValue(22) != DBNull.Value ? dataReader.GetString(22) : null;
                specs.Rear_brakes = dataReader.GetValue(23) != DBNull.Value ? dataReader.GetString(23) : null;
                specs.Front_tire = dataReader.GetValue(24) != DBNull.Value ? dataReader.GetString(24) : null;
                specs.Rear_tire = dataReader.GetValue(25) != DBNull.Value ? dataReader.GetString(25) : null;
                specs.Front_suspension = dataReader.GetValue(26) != DBNull.Value ? dataReader.GetString(26) : null;
                specs.Rear_suspension = dataReader.GetValue(27) != DBNull.Value ? dataReader.GetString(27) : null;
                specs.Color_options = dataReader.GetValue(28) != DBNull.Value ? dataReader.GetString(28) : null;
                bikeSpecs.Add(specs);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return bikeSpecs;
        }
    }
}

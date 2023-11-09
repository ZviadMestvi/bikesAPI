using System.Data.SqlClient;
using CompareBikes.Models;

namespace CompareBikes.Services
{
    public class ModelsService
    {
        public static IEnumerable<Model> filterModels(string brand, string? category, int? year, int? minYear, int maxYear, IConfiguration configuration)
        {
            string categoryString = category != null ? $"AND category = '{category}'" : "";
            string yearString = year != null && minYear == null ? $"AND year BETWEEN {year} AND {year}" : "";
            string yearRangeString = minYear != null && year == null ? $"AND year BETWEEN {minYear} AND {maxYear}" : ""; 

            string sqlCommand = $"SELECT id, brand, model, year, category FROM all_bikes WHERE brand = '{brand}' {categoryString} {yearString} {yearRangeString}";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("ServerConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand(sqlCommand, cnn);
            SqlDataReader reader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while(reader.Read())
            {
                Model model = new Model();
                model.Id = reader.GetInt32(0);
                model.Brand = reader.GetString(1);
                model.Name = reader.GetString(2);
                model.Year = reader.GetInt32(3);
                model.Type = reader.GetString(4);
                modelsList.Add(model);
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
            return modelsList;
        }

        public static IEnumerable<Model> getModelsBySearchQuery(string query, IConfiguration configuration)
        {
            string sqlCommand = $"SELECT id, brand, model, year, category FROM all_bikes WHERE model LIKE '%{query}%' OR brand LIKE '%{query}%' ORDER BY brand";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("ServerConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand(sqlCommand, cnn);
            SqlDataReader reader = command.ExecuteReader();

            List<Model> modelsList = new List<Model>();
            while (reader.Read())
            {
                Model model = new Model();
                model.Id = reader.GetInt32(0);
                model.Brand = reader.GetString(1);
                model.Name = reader.GetString(2);
                model.Year = reader.GetInt32(3);
                model.Type = reader.GetString(4);
                modelsList.Add(model);
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
            return modelsList;
        }
    }
}



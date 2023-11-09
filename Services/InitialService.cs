using System.Data.SqlClient;
using CompareBikes.Models;

namespace CompareBikes.Services
{
    public class InitialService
    {
        public static List<Brand> getBrandsList(IConfiguration configuration)
        {
            string sqlCommand = "SELECT * FROM brands";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("ServerConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand(sqlCommand, cnn);
            SqlDataReader reader = command.ExecuteReader();

            List<Brand> brandsList = new List<Brand>();
            while (reader.Read())
            {
                Brand brand = new Brand();
                brand.Id = reader.GetInt32(0);
                brand.Name = reader.GetString(1);
                brandsList.Add(brand);
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
            return brandsList;
        }

        public static List<Year> getYearsList(IConfiguration configuration)
        {
            string sqlCommand = "SELECT * FROM years ORDER BY year DESC";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("ServerConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand(sqlCommand, cnn);
            SqlDataReader reader = command.ExecuteReader();

            List<Year> yearsList = new List<Year>();
            while (reader.Read())
            {
                Year year = new Year();
                year.Id = reader.GetInt32(0);
                year.YearNum = reader.GetInt32(1);
                yearsList.Add(year);
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
            return yearsList;
        }

        public static List<Category> getCategoriesList(IConfiguration configuration)
        {
            string sqlCommand = "SELECT * FROM types";

            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("ServerConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand(sqlCommand, cnn);
            SqlDataReader reader = command.ExecuteReader();

            List<Category> categoriesList = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = reader.GetInt32(0);
                category.Name = reader.GetString(1);
                categoriesList.Add(category);
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
            return categoriesList;
        }

        public static IEnumerable<Initial> getResults(IConfiguration configuration)
        {
            var brandsList = getBrandsList(configuration);
            var yearsList = getYearsList(configuration);
            var categoriesList = getCategoriesList(configuration);

            List<Initial> results = new List<Initial>();

            Initial initial = new Initial();
            initial.brandsList = brandsList;
            initial.yearsList = yearsList;
            initial.typesList = categoriesList;
            results.Add(initial);

            return results;
        }
    }
}

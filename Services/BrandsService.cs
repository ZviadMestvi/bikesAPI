using System.Data.SqlClient;
using CompareBikes.Models;

namespace CompareBikes.Services
{
    public class BrandsService
    {
        /* Get list of all brands */
        public static IEnumerable<Brand> GetBrandsList(IConfiguration configuration)
        {
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM brands", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Brand> brandsList = new List<Brand>();
            while (dataReader.Read())
            {
                Brand brand = new Brand();
                brand.Id = dataReader.GetInt32(0);
                brand.Name = dataReader.GetString(1);
                brandsList.Add(brand);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return brandsList;
        }

        /* Get searched brands */
        public static IEnumerable<Brand> GetSearchedBrandsList(string value, IConfiguration configuration)
        {
            string trimmedValue = value.Trim();
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM brands WHERE brand LIKE '%{trimmedValue}%'", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Brand> brandsList = new List<Brand>();
            while (dataReader.Read())
            {
                Brand brand = new Brand();
                brand.Id = dataReader.GetInt32(0);
                brand.Name = dataReader.GetString(1);
                brandsList.Add(brand);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return brandsList;
        }
    }
}

using System.Data.SqlClient;
using CompareBikes.Models;

namespace CompareBikes.Services
{
    public class CategoriesService
    {
        /* Get all categories */
        public static IEnumerable<Category> GetCategoriesList(IConfiguration configuration)
        {
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM types", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Category> categoriesList = new List<Category>();
            while (dataReader.Read())
            {
                Category category = new Category();
                category.Name = dataReader.GetString(0);
                categoriesList.Add(category);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return categoriesList;
        }
    }
}

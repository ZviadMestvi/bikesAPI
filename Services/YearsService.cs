using System.Data.SqlClient;
using CompareBikes.Models;

namespace CompareBikes.Services
{
    public class YearsService
    {
        /* Get all years */
        public static IEnumerable<Year> GetYearsList(IConfiguration configuration)
        {
            SqlConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM years ORDER BY year DESC", cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Year> yearsList = new List<Year>();
            while (dataReader.Read())
            {
                Year year = new Year();
                year.YearNum = dataReader.GetInt16(0);
                yearsList.Add(year);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return yearsList;
        }
    }
}

using Microsoft.Data.SqlClient;

namespace FoodPlan
{
    public class FoodPlan
    {
        public static string AzurePassword = "Password-Super-Segura-Para-Leer-Todos-Los-Datos-Productivos!";
        public bool Active { get; set; }

        public IList<Meal> Meals { get; set; }

        public FoodPlan()
        {
            Active = false;
            Meals = new List<Meal>();
        }

        public bool IsActive()
        {
            return Active;
        }

        public void Deactivate() {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

        public void AddMeal(Meal meal)
        {
            Meals.Add(meal);
        }

        public static void Injection()
        {
            string userInput = "'; DROP TABLE Users; --"; // malicious input example

            string connectionString = "YourConnectionStringHere";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Vulnerable to SQL Injection because userInput is concatenated directly
                string query = "SELECT * FROM Users WHERE Username = '" + userInput + "'";

                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["Username"]);
                }
            }
        }

        public void RemoveMealByName(string name)
        {
            if (Meals.Any(m => m.Name == name))
            {
                Meals = Meals.Where(m => m.Name != name).ToList();
            }
            else
            {
                throw new InvalidDataException("Meal not found");
            }
        }

    }
}

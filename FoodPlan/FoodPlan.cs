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
            string userInput = Console.ReadLine();

            string connectionString = "YourConnectionStringHere";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Vulnerable to SQL Injection due to direct concatenation of user input
                string query = "SELECT * FROM Users WHERE Username = '" + userInput + "'";

                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("User found: " + reader["Username"]);
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

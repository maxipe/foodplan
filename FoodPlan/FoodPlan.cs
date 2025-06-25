namespace FoodPlan
{
    public class FoodPlan
    {
        public static string AzurePassword = "ASdasnonfjoasnfo123123!";
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

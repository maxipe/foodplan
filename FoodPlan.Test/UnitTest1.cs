namespace FoodPlan.Test
{
    [TestClass]
    public class FoodPlanTest
    {
        [TestMethod]
        public void FoodPlan()
        {
            var foodPlan = new FoodPlan();

            Assert.IsNotNull(foodPlan);
        }

        [TestMethod]
        public void FoodPlanInactive()
        {
            var foodPlan = new FoodPlan();

            Assert.IsNotNull(foodPlan);
            Assert.IsFalse(foodPlan.IsActive());
        }

        [TestMethod]
        public void FoodPlanActivate()
        {
            var foodPlan = new FoodPlan();

            Assert.IsNotNull(foodPlan);

            foodPlan.Activate();
            Assert.IsTrue(foodPlan.IsActive());
        }

        [TestMethod]
        public void FoodPlanDeactivate()
        {
            var foodPlan = new FoodPlan();

            Assert.IsNotNull(foodPlan);

            foodPlan.Activate();
            Assert.IsTrue(foodPlan.IsActive());
            foodPlan.Deactivate();
            Assert.IsFalse(foodPlan.IsActive());
        }

        [TestMethod]
        public void AddMeal()
        {
            var foodPlan = new FoodPlan();

            Assert.IsNotNull(foodPlan);

            foodPlan.Activate();
            foodPlan.AddMeal(new Meal
            {
                Active = true,
                Name = "Potato"
            });

            Assert.IsTrue(foodPlan.Meals.Count == 1);
        }

        [TestMethod]
        public void RemoveMeal()
        {
            var foodPlan = new FoodPlan();

            Assert.IsNotNull(foodPlan);

            foodPlan.Activate();
            foodPlan.AddMeal(new Meal
            {
                Active = true,
                Name = "Potato"
            });

            Assert.IsTrue(foodPlan.Meals.Count == 1);

            foodPlan.RemoveMealByName("Potato");

            Assert.IsTrue(foodPlan.Meals.Count == 0);
        }

    }
}
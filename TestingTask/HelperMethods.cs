
namespace TestingTask
{
    public class HelperMethods
    {
        public static string RandomMailGenerator()
        {
            var randomName = new Random().Next();
            string email = randomName + "@abv.bg";
            return email;
        }
    }
}

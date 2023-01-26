namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DriverFactory.Init("chrome");
        }
        [Test]
        public void Test1()
        {
            Amazon amazon=new Amazon();
            amazon.Pages.Home.SearchBar.Text="mouse";
            amazon.Pages.Home.SearchBar.Click();
            Dictionary<string,string> filters=new Dictionary<string,string>();
            filters.Add("price lower than","20");
            filters.Add("price higher or equal to","5");
            filters.Add("free shipping","true");
            List<Item> items=amazon.Pages.Results.GetResultsBy(filters);
            foreach(Item item in items){
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Link);
                Console.WriteLine(item.Price);
                Console.WriteLine();
            }
            Assert.Pass();
        }
    }
}
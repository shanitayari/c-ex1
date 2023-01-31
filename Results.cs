using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Results
    {
        private IWebDriver driver;
        public Results()
        {
            driver=DriverFactory.Drivers["chrome"];
        }
        public List<Item> GetResultsBy(Dictionary<string,string> filters)
        {
            string xPath="//*[@data-component-type='s-search-result'";
            foreach(var filter in filters)
                switch(filter.Key){
                    case "price lower than":
                        xPath+=" and substring-after(.//*[@class='a-offscreen']//.,'$')<"+filter.Value;
                        break;
                    case "price higher or equal to":
                        xPath+=" and substring-after(.//*[@class='a-offscreen']//.,'$')>="+filter.Value;
                        break;
                    case "free shipping":
                        xPath+=" and "+(filter.Value=="true"?"":"not ")+"(.//*[@class='a-color-base a-text-bold']//.='FREE Shipping ')";
                        break;
                }
            xPath+="]";
            var products=driver.FindElements(By.XPath(xPath));
            List<Item> items=new List<Item>();
            foreach(var product in products){
                Item item=new Item();
                item.Title=product.FindElement(By.TagName("h2")).Text;
                item.Link=product.FindElement(By.TagName("a")).GetAttribute("href");
                item.Price=product.FindElement(By.ClassName("a-offscreen")).GetAttribute("textContent");
                items.Add(item);
            }
            return items;
        }
    }
}
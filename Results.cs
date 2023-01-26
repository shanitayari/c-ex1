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
        public List<Item> GetResultsBy(Dictionary<string,string> filters)//get filters dictionary and return list of items that match the filters
        {
            string xPath="//*[@data-component-type='s-search-result'";//create xpath string that get the items that match the filters
            foreach(var filter in filters)
                switch(filter.Key){
                    case "price lower than"://add to xpath filter of price lower than
                        xPath+=" and substring-after(.//*[@class='a-offscreen']//.,'$')<"+filter.Value;
                        break;
                    case "price higher or equal to"://add to xpath filter of price higer than
                        xPath+=" and substring-after(.//*[@class='a-offscreen']//.,'$')>="+filter.Value;
                        break;
                    case "free shipping"://add to xpath filter of free shipping
                        xPath+=filter.Value=="true"?" and .//*[@class='a-color-base a-text-bold']//.='FREE Shipping '":"";
                        break;
                }
            xPath+="]";
            var products=driver.FindElements(By.XPath(xPath));//get the matching elements of items
            List<Item> items=new List<Item>();//create list of items from elements
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
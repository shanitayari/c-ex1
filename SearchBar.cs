using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject2
{
    internal class SearchBar
    {
        private IWebDriver driver;
        public string Text
        {
            get
            {
                var searchTextBox=driver.FindElement(By.Id("twotabsearchtextbox"));
                return searchTextBox.GetAttribute("value");
            }
            set
            {
                var searchTextBox=driver.FindElement(By.Id("twotabsearchtextbox"));
                searchTextBox.Clear();
                searchTextBox.SendKeys(value);
            }
        }
        public SearchBar()
        {
            driver=DriverFactory.Drivers["chrome"];
        }
        public void Click()
        {
            var searchButton=driver.FindElement(By.Id("nav-search-submit-button"));
            searchButton.Click();
        }
    }
}
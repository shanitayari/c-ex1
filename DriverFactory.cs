using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal static class DriverFactory
    {
        private static Dictionary<string,IWebDriver> drivers=new Dictionary<string,IWebDriver>();
        public static Dictionary<string,IWebDriver> Drivers
        { 
            get 
            {
                return drivers;
            }
        }
        public static void Init(string driver)
        {
            switch(driver){
                case "firefox":
                    if(!drivers.ContainsKey(driver))
                        drivers.Add(driver,new FirefoxDriver());
                    break;
                case "edge":
                    if(!drivers.ContainsKey(driver))
                        drivers.Add(driver,new EdgeDriver());
                    break;
                default:
                    if(!drivers.ContainsKey(driver))
                        drivers.Add(driver,new ChromeDriver());
                    break;
            }            
        }
    }
}
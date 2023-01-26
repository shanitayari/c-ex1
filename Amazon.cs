using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Amazon
    {
        private IWebDriver driver;
        private Pages pages;
        public Pages Pages
        {
            get
            {
                if(pages==null)
                    pages=new Pages();
                return pages;
            }
        }
        public Amazon()
        {
            driver=DriverFactory.Drivers["chrome"];
            driver.Url="https://www.amazon.com/?language=en_US";
        }
    }
}
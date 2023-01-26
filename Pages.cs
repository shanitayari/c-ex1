using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Pages
    {
        private Home home;
        public Home Home
        {
            get
            {
                if(home==null)
                    home=new Home();
                return home;
            }
        }
        private Results results;
        public Results Results
        {
            get
            {
                if(results==null)
                    results=new Results();
                return results;
            }
        }
    }
}
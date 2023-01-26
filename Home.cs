using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Home
    {
        private SearchBar searchBar;
        public SearchBar SearchBar
        {
            get
            {
                if(searchBar==null)
                    searchBar=new SearchBar();
                return searchBar;
            }
        }
    }
}
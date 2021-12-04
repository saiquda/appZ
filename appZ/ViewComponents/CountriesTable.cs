using appZ.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.ViewComponents
{
    public class CountriesTable : ViewComponent
    {
        public IViewComponentResult Invoke(List<Country>Countries)
        {
            StringBuilder str= new StringBuilder();
            str.Append(@"<table class=""table"">
    <thead>
        <tr>
            <th>
                
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>");
            foreach (var item in Countries)
            {
                str.Append(item);
            }
            return null;
        }
    }
}

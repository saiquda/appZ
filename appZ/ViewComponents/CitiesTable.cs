using appZ.Models;
using appZ.Models.ViewModelBinding;
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
    public class CitiesTable : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CitiesTableBinding model)
        {
            ViewBag.CurrentId = model.CityId;
            return await Task.FromResult(View(model.Cities));
        }
        //    public IViewComponentResult Invoke(List<City>Cities)
        //    {
        //        StringBuilder str = new StringBuilder();
        //        str.Append(@"<table class=""table"">
        //<thead>
        //    <tr>
        //        <th>
        //            Город
        //        </th>
        //    </tr>
        //</thead>
        //<tbody>");
        //        foreach (var item in Cities)
        //        {
        //            str.Append(String.Format(@"<tr><th><a href = ""Home/Index?Id={0}"">{1}</a></th></tr>", item.SubjectId, item.Name));
        //        }
        //        str.Append(@"</tbody></table>");
        //        return new HtmlContentViewComponentResult(new HtmlString(str.ToString()));
        //    }
    }
}

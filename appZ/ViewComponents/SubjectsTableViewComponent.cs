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
    public class SubjectsTableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Subject> subjects)
        {
            return await Task.FromResult(View(subjects));
        }
        //    public IViewComponentResult Invoke(List<Subject> Subjects)
        //    {
        //        StringBuilder str = new StringBuilder();
        //        str.Append(@"<table class=""table"">
        //<thead>
        //    <tr>
        //        <th>
        //            Субьект
        //        </th>
        //    </tr>
        //</thead>
        //<tbody>");
        //        foreach (var item in Subjects)
        //        {
        //            str.Append(String.Format(@"<tr><th><a href = ""Index?Id={0}"">{1}</a></th></tr>",item.Id,item.Name));
        //        }
        //        str.Append(@"</tbody></table>");
        //        return new HtmlContentViewComponentResult(new HtmlString(str.ToString()));
        //    }
    }
}

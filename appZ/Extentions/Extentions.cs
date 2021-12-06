using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appZ.Extentions
{
    public static class Extentions
    {
        public static List<SelectListItem> ToSelectListItems<TList>(this IEnumerable<TList> list, Func<TList, string> value, Func<TList, string> text)
        {
            var items = new List<SelectListItem>();

            foreach (var item in list)
            {
                items.Add(new SelectListItem() { Value = value(item), Text = text(item) });
            }
            return items;
        }
    }
}

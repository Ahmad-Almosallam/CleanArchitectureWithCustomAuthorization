using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Helpers
{
    public class Enums
    {
        public static SelectList GetEnumSelectList<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            
            List<SelectListItem> items = new List<SelectListItem>(values.Length);

            foreach (var i in values)
            {
                items.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(T), i),
                    Value = ((int)i).ToString()
                });
            }

            return new SelectList(items, "Value", "Text");
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationDemo.Models
{
    public class DropDownLists
    {
        public static SelectList GenderList
        {
            get
            {
                //
                // Don't cache because we don't get the translated element
                // when culture changes.
                //
                //if (_GemderSelectList != null)
                //{
                //    return _GemderSelectList;
                //}

                List<SelectListItem> listItems = new List<SelectListItem>();

                SelectListItem empty = new SelectListItem();
                empty.Value = "";
                empty.Text = "";
                listItems.Add(empty);

                SelectListItem male = new SelectListItem();
                male.Text = GenderType.Male.DisplayName();
                male.Value = GenderType.Male.ToString();
                listItems.Add(male);

                SelectListItem female = new SelectListItem();
                female.Text = GenderType.Female.DisplayName();
                female.Value = GenderType.Female.ToString();
                listItems.Add(female);

                _GemderSelectList = new SelectList(listItems, "Value", "Text");
                return _GemderSelectList;
            }
        }
        private static SelectList _GemderSelectList;
    }
}

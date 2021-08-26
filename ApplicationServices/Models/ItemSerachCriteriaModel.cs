using ApplicationServices.Dtos;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Models
{
    public class ItemSerachCriteriaModel
    {

        public string ItemName { get; set; }

        public int PageIndex { get; set; }

        public PaginatedList<ItemDto> Grid { get; set; }
    }
}

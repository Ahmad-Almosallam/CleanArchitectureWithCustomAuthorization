using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationServices.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required, Display(Name="Name")]
        public string Name { get; set; }
    }
}

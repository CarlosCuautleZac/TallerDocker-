using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstractions
{
    [Table(nameof(User))]
    public class User:GuiEntity
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}

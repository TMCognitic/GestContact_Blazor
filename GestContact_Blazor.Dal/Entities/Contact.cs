using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact_Blazor.Dal.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public string Prenom { get; set; } = default!;
        public DateTime Anniversaire { get; set; }
    }
}

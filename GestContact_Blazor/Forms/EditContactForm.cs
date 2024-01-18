using System.ComponentModel.DataAnnotations;

namespace GestContact_Blazor.Forms
{
    public class EditContactForm
    {
        [Required]
        public string Nom { get; set; } = default!;
        [Required]
        public string Prenom { get; set; } = default!;
        public DateTime Anniversaire { get; set; } = DateTime.Now;     
    }
}

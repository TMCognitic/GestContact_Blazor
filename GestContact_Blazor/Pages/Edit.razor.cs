using Microsoft.AspNetCore.Components;

namespace GestContact_Blazor.Pages
{
    public partial class Edit
    {
        [Inject]
        private IContactRepository Repository { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public int ContactId { get; set; }

        private EditContactForm Form { get; set; } = default!;

        protected override void OnInitialized()
        {
            Contact? contact = Repository.Get(ContactId);

            if (contact is null)
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            Form = new EditContactForm()
            {
                Nom = contact.Nom,
                Prenom = contact.Prenom,
                Anniversaire = contact.Anniversaire
            };
        }

        public void Save()
        {
            Contact contact = new Contact()
            {
                Id = ContactId,
                Nom = Form.Nom,
                Prenom = Form.Prenom,
                Anniversaire = Form.Anniversaire
            };

            Repository.Update(contact);
            NavigationManager.NavigateTo("/");
        }
    }
}

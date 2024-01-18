using Microsoft.AspNetCore.Components;

namespace GestContact_Blazor.Components
{
    public partial class AddContact
    {
        [Inject]
        private IContactRepository Repository { get; set; } = default!;

        [Parameter]
        public EventCallback<Contact> NewContactCreated { get; set; }

        private AddContactForm Form { get; set; } = default!;

        protected override void OnInitialized()
        {
            Form = new AddContactForm();
        }

        public void Save()
        {
            Contact contact = new Contact()
            {
                Nom = Form.Nom,
                Prenom = Form.Prenom,
                Anniversaire = Form.Anniversaire
            };

            Repository.Insert(contact);
            NewContactCreated.InvokeAsync(contact);
            Form = new AddContactForm();
        }
    }
}

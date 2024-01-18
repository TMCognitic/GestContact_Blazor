using GestContact_Blazor.Dal.Repositories;
using Microsoft.AspNetCore.Components;

namespace GestContact_Blazor.Pages
{
    public partial class Home
    {
        [Inject]
        private IContactRepository Repository { get; set; } = default!;

        private List<Contact> Contacts { get; set; } = default!;

        protected override void OnInitialized()
        {
            Contacts = new List<Contact>(Repository.Get());
        }

        private void Delete(Contact contact)
        {
            if(Repository.Delete(contact.Id))
                Contacts.Remove(contact);
        }

        private void NewContactCreated(Contact contact)
        {
            Contacts.Add(contact);
        }
    }
}

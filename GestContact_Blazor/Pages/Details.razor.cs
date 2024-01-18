using Microsoft.AspNetCore.Components;

namespace GestContact_Blazor.Pages
{
    public partial class Details
    {
        [Inject]
        private IContactRepository Repository { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public int ContactId { get; set; }

        private Contact Entity { get; set; } = default!;

        protected override void OnInitialized()
        {
            Contact? contact = Repository.Get(ContactId);

            if (contact is null)
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            Entity = contact; 
        }
    }
}

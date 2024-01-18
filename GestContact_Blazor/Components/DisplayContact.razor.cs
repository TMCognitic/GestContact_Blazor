using Microsoft.AspNetCore.Components;

namespace GestContact_Blazor.Components
{
    public partial class DisplayContact
    {
        [Parameter]
        public Contact Entity { get; set; } = default!;

        [Parameter]
        public EventCallback<Contact> OnDeleteClick { get; set; }

        private void Delete()
        {
            OnDeleteClick.InvokeAsync(Entity);
        }
    }
}

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
namespace BlazorAuto.Model
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "";

        [Parameter]
        public string ConfirmationMessage { get; set; } = "";

        [Parameter]
        public string ButtonYes { get; set; } = "";
        [Parameter]
        public string ButtonNo { get; set; } = "";

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}


using courierSystem.BLL.Services;
using courierSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace courierSystem.PL.Pages
{
    public class addShipmentSuccessModel : PageModel
    {
        public readonly SuccessfulAdditonService _successfulAddition;

        public addShipmentSuccessModel(SuccessfulAdditonService successfulAdditon)
        {
            _successfulAddition = successfulAdditon;
        }
        public FinishAddShipment Finish { get; set; } = new FinishAddShipment();

        public async Task OnGetAsync()
        {
            Finish = new FinishAddShipment();
            Finish.ShipmentDetailsCode = await _successfulAddition.GetTrackingIdAsync();
        }

        public async Task<IActionResult> OnPostFinishAsync() => RedirectToPage("/Main");

    }
}

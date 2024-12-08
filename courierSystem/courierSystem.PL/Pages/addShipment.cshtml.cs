using courierSystem.BLL.Services;
using courierSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace courierSystem.PL.Pages
{
    public class addShipmentModel : PageModel
    {
        private readonly ShipmentService _shipmentService;

        public addShipmentModel(ShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [BindProperty]
        public Shipments shipment { get; set; } = new Shipments();

        public void OnGet()
        {
            shipment = new Shipments();
        }

        public async Task<IActionResult> OnPostAddShipmentAsync()
        {
            if (ModelState.IsValid)
            {
                bool AddShipmentSuccessful = await _shipmentService.AddShipmentAsync(shipment.ReceiverName, shipment.SenderName, shipment.ReceiverPhoneNumber, shipment.SenderPhoneNumber, shipment.OfficeName, shipment.ShipmentDetails, shipment.ShipmentWeight);

                if (AddShipmentSuccessful)
                {
                    return RedirectToPage("/addShipmentSuccess");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid");
                }
            }
            return Page();
        }
    }
}

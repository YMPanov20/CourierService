using courierSystem.BLL.Services;
using courierSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace courierSystem.PL.Pages
{
    public class MainModel : PageModel
    {
        private readonly ShipmentInfoService _shipmentInfoService;

        public MainModel(ShipmentInfoService shipmentInfoService)
        {
            _shipmentInfoService = shipmentInfoService;
        }

        public ShipmentInfo shipmentInfo { get; set; } = new ShipmentInfo();
        [BindProperty]
        public FinishAddShipment ShipmentDetails { get; set; } = new FinishAddShipment();

        public bool SearchResultFound { get; set; } = false;
        public bool SearchResultNotFound { get; set; } = false;
        public void OnGet()
        {
            shipmentInfo = new ShipmentInfo();
        }

        public async Task<IActionResult> OnPostTrackAsync()
        {
            
            if (int.TryParse(ShipmentDetails.ShipmentDetailsCode, out int shipmentId1))
            {
                ShipmentDetails.ShipmentDetailsId = shipmentId1;
                if (ModelState.IsValid)
                {
                    shipmentInfo = await _shipmentInfoService.GetShipmentInfoByTrackingIdAsync(ShipmentDetails.ShipmentDetailsId);
                    if (shipmentInfo.ShipmentId > 0)
                    {
                        SearchResultFound = true;
                    }
                    else
                    {
                        SearchResultNotFound = true;
                    }
                }
            }
            else
            {
                SearchResultNotFound = true;
                // Handle the case where the input is not a valid integer
                ModelState.AddModelError("ShipmentDetails.ShipmentDetailsCode", "Please enter a valid shipment ID");
            }

            return Page();
        }

    }

}

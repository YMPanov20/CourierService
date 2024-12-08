using courierSystem.BLL.Services;
using courierSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace courierSystem.PL.Pages
{
    public class ShipmentRedirectionModel : PageModel
    {
        private readonly ShipmentInfoService _shipmentInfoService;
        public ShipmentRedirectionModel(ShipmentInfoService shipmentInfoService)
        {
            _shipmentInfoService = shipmentInfoService;
        }
        public ShipmentInfo shipmentInfo { get; set; } = new ShipmentInfo();
        [BindProperty]
        public FinishAddShipment ShipmentDetails { get; set; } = new FinishAddShipment();
        public bool SearchResultFound { get; set; } = false;
        public bool SearchResultNotFound { get; set; } = false;

        private string ShipmentDetailsCodeTempDataKey = "ShipmentDetailsCode";
        public void OnGet()
        {
            ShipmentDetails = new FinishAddShipment();
        }

        public async Task<IActionResult> OnPostTrackAsync()
        {
            if (int.TryParse(ShipmentDetails.ShipmentDetailsCode, out int shipmentId))
            {
                ShipmentDetails.ShipmentDetailsId = shipmentId;
                if (ModelState.IsValid)
                {
                    shipmentInfo = await _shipmentInfoService.GetShipmentInfoByTrackingIdAsync(ShipmentDetails.ShipmentDetailsId);
                    if (shipmentInfo.ShipmentId > 0)
                    {
                        SearchResultFound = true;

                        TempData[ShipmentDetailsCodeTempDataKey] = ShipmentDetails.ShipmentDetailsCode;
                    }
                }
            }
            else
            {
                // Handle the case where the input is not a valid integer
                ModelState.AddModelError("ShipmentDetails.ShipmentDetailsCode", "Please enter a valid shipment ID");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateDestinationAsync()
        {
            string shipmentDetailsCode = TempData[ShipmentDetailsCodeTempDataKey] as string;

            if (int.TryParse(shipmentDetailsCode, out int shipmentId1))
            {
                ShipmentDetails.ShipmentDetailsId = shipmentId1;
                if (ModelState.IsValid)
                {
                    await _shipmentInfoService.UpdateShipmentDestinationAsync(ShipmentDetails.ShipmentDetailsId, ShipmentDetails.NewDestinationOfficeName);
                }
            }
            else
            {
                // Handle the case where the input is not a valid integer
                ModelState.AddModelError("ShipmentDetails.ShipmentDetailsCode", "Please enter a valid shipment ID");
            }

            return RedirectToPage("/Main");
        }

    }
}

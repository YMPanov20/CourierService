using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.BLL.Services
{
    public class SuccessfulAdditonService
    {
        private readonly SuccessfulSaveRepository successfulSaveRepository;

        public SuccessfulAdditonService()
        {
            successfulSaveRepository = new SuccessfulSaveRepository();
        }

        public async Task<string> GetTrackingIdAsync()
        {
            string trackingId = await Task.Run(() => successfulSaveRepository.GetLatestTrackingIdAsync());

            return trackingId;
        }
    }
}

using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace courierSystem.BLL.Services
{
    public class AccountService
    {
        private readonly AdminAccountRepository adminAccountRepository;

        public AccountService()
        {
            adminAccountRepository = new AdminAccountRepository();
        }

        public async Task<bool> LogInAsync(string username, string password)
        {
            AdminAccount admin = await adminAccountRepository.GetAdminAccountByUsernameAsync(username);

            return admin != null && admin.Password == password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.DAL.Models
{
    public class AdminAccount
    {
        private int Id;
        private string username;
        private string password;

        public int UserId { get { return Id; } set { Id = value; } }
        public string Username { get { return this.username; } set { this.username = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }

        public AdminAccount()
        {
            UserId = 0;
            Username = "";
            Password = "Not defined";
        }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.User
{
    public  class ProfileForShowDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConvincingReasons { get; set; }
        public string AboutMe { get; set; }
        public string Position { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string InvationLink { get; set; }
    }
}

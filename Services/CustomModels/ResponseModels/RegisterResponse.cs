﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.CustomModels.ResponseModels
{
    public class RegisterResponse
    {
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestIT.Web.ViewModels.Default
{
    [JsonObject(MemberSerialization.OptOut)]
    public class UserViewModel
    {
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordNew { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        #endregion Properties
    }
}

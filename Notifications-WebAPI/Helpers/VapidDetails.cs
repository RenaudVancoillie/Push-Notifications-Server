﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications_WebAPI.Helpers
{
    public class VapidDetails
    {
        public string Subject { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}

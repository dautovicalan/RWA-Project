﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicSite.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public bool IsMain { get; set; }
    }
}
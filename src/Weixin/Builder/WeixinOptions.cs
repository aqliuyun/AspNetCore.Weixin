﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Myvas.AspNetCore.Weixin
{
    public class WeixinOptions
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}

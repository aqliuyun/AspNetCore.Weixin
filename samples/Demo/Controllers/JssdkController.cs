using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Entities;
using Demo.Models;
using AspNetCore.Weixin;
using Microsoft.Extensions.Options;

namespace Demo.Controllers
{
    public class JssdkController : Controller
    {
        private readonly IWeixinAccessToken _weixinAccessToken;
		private readonly IWeixinJsapiTicket _weixinJsapiTicket;
		private readonly WeixinAccessTokenOptions _options;

        public JssdkController(
            IWeixinAccessToken weixinAccessToken,
			IWeixinJsapiTicket weixinJsapiTicket,
            IOptions<WeixinAccessTokenOptions> optionsAccessor)
		{
			_weixinAccessToken = weixinAccessToken ?? throw new ArgumentNullException(nameof(weixinAccessToken));
			_weixinJsapiTicket = weixinJsapiTicket ?? throw new ArgumentNullException(nameof(weixinJsapiTicket));
			_options = optionsAccessor?.Value ?? throw new ArgumentNullException(nameof(optionsAccessor));
        }

        public IActionResult Index()
        {
            var vm = new ShareJweixinViewModel();

            var config = new WeixinJsConfig()
            {
                debug = true,
                appId = _options.AppId
            };
            var jsapiTicket = _weixinJsapiTicket.GetTicket();
            var refererUrl = Request.GetAbsoluteUri();// Url.AbsoluteContent(Url.Action());
            vm.ConfigJson = config.ToJson(jsapiTicket, refererUrl);

            vm.Title = "链接分享测试";
            vm.Url = "http://ruhu.daqianit.com/immigrationevals/create/6e997009-5f9c-4f6b-a455-5167bff830ef";
            vm.Description = "链接分享测试";
            vm.ImgUrl = "http://www.warmwood.com/images/s1.jpg";
            return View(vm);
        }
    }
}
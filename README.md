# AspNetCore.Weixin

## NuGet
https://www.nuget.org/packages/AspNetCore.Weixin/

## Settings
https://mp.weixin.qq.com

- ��ȡAppSecret
- ���ÿ���ģʽ��������վ������https/ssl����ַ����: https://xxx.xxx/wx
- �ڡ���վToken������дһ���ϳ�������ַ�����ΪWebsiteToken
- ��Ҫѡ�񡰼���ģʽ�������汾�ݲ�֧�֣�


## ConfigureServices
```
services.AddScoped<WeixinEventSink>();
var weixinEventSink = services.BuildServiceProvider().GetRequiredService<WeixinEventSink>();
services.AddWeixin(options =>
  {
      options.AppId = _configuration["Weixin:AppId"];
      options.AppSecret = _configuration["Weixin:AppSecret"];
      options.WebsiteToken = _configuration["Weixin:WebsiteToken"];
      options.EncodingAESKey = _configuration["Weixin:EncodingAESKey"];
      options.Events = new WeixinMessageEvents()
      {
          OnTextMessageReceived = ctx => weixinEventSink.OnTextMessageReceived(ctx.Sender, ctx.Args),
          OnLinkMessageReceived = ctx => weixinEventSink.OnLinkMessageReceived(ctx.Sender, ctx.Args),
          OnClickMenuEventReceived = ctx => weixinEventSink.OnClickMenuEventReceived(ctx.Sender, ctx.Args),
          OnImageMessageReceived = ctx => weixinEventSink.OnImageMessageReceived(ctx.Sender, ctx.Args),
          OnLocationEventReceived = ctx => weixinEventSink.OnLocationEventReceived(ctx.Sender, ctx.Args),
          OnLocationMessageReceived = ctx => weixinEventSink.OnLocationMessageReceived(ctx.Sender, ctx.Args),
          OnQrscanEventReceived = ctx => weixinEventSink.OnQrscanEventReceived(ctx.Sender, ctx.Args),
          OnEnterEventReceived = ctx => weixinEventSink.OnEnterEventReceived(ctx.Sender, ctx.Args),
          OnSubscribeEventReceived = ctx => weixinEventSink.OnSubscribeEventReceived(ctx.Sender, ctx.Args),
          OnUnsubscribeEventReceived = ctx => weixinEventSink.OnUnsubscribeEventReceived(ctx.Sender, ctx.Args),
          OnVideoMessageReceived = ctx => weixinEventSink.OnVideoMessageReceived(ctx.Sender, ctx.Args),
          OnShortVideoMessageReceived = ctx => weixinEventSink.OnShortVideoMessageReceived(ctx.Sender, ctx.Args),
          OnViewMenuEventReceived = ctx => weixinEventSink.OnViewMenuEventReceived(ctx.Sender, ctx.Args),
          OnVoiceMessageReceived = ctx => weixinEventSink.OnVoiceMessageReceived(ctx.Sender, ctx.Args)
      };
  });
```

## Configure
```
app.UseWeixinWelcomePage();
```

## Demo
http://weixin.myvas.com

## Branches
- master: ASP.NET Core 2.1(LTS)
- branches:
- tags: create a tag when release to nuget

## Migrate from ASP.NET Core 2.0 to 2.1
https://docs.microsoft.com/en-us/aspnet/core/migration/20_21

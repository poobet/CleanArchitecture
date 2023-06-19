using System;


namespace Application.Common.Core;
public class ApplicationSetting
{
    public string AspNetcoreEnvironment => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
    public string SwaggerPath { get; set; }
    public bool IsAuthenticationForce { get; set; }
    public bool IsDevelopment { get; set; }
    public string SerilogPath { get; set; }
    public OnlineAuthenSetting OnlineAuthen { get; set; }
    public bool EmptyInterfaceLogging { get; set; }
    public CloudAzureClientSetting AzureSetting { get; set; }
}
public class OnlineAuthenSetting
{
    public bool AuthenEnable { get; set; }
    public string AuthenPrefix { get; set; }
}

public class CloudAzureClientSetting
{
    public string Endpoint { get; set; }
    public string ClientId { get; set; }
    public CloudAzureKey Keys { get; set; }
}

public class CloudAzureKey
{
    public string Hvr { get; set; }
}

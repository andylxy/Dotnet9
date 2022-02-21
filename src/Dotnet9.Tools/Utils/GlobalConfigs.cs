﻿namespace Dotnet9.Tools.Utils;

public class GlobalConfigs
{
    private readonly CookieStorage? _cookieStorage;

    public GlobalConfigs()
    {
    }

    public GlobalConfigs(CookieStorage cookieStorage)
    {
        _cookieStorage = cookieStorage;
    }

    public static string LanguageCookieKey { get; set; } = "GlobalConfigs_Language";

    public static string? StaticLanguage { get; set; }

    public string? Language { get; set; }

    public void Initialize(IRequestCookieCollection cookies)
    {
        Language = cookies[LanguageCookieKey];
    }

    public void SaveChanges()
    {
        _cookieStorage?.SetItemAsync(LanguageCookieKey, Language);
    }

    public void Bind(GlobalConfigs globalConfig)
    {
        Language = globalConfig?.Language;
    }
}
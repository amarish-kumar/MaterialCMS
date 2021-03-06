﻿using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using MaterialCMS.Services;
using MaterialCMS.Website;
using MaterialCMS.Website.Optimization;

namespace MaterialCMS.Helpers
{
    public static class OptimisationExtensions
    {
        public static void IncludeScript(this HtmlHelper helper, string url)
        {
            var webPage = helper.ViewDataContainer as WebPageBase;
            var virtualPath = webPage == null ? string.Empty : webPage.VirtualPath;
            MaterialCMSApplication.Get<IResourceBundler>().AddScript(virtualPath, url);
        }

        public static void RenderScripts(this HtmlHelper helper)
        {
            MaterialCMSApplication.Get<IResourceBundler>().GetScripts(helper.ViewContext);
        }

        public static void IncludeCss(this HtmlHelper helper, string url)
        {
            var webPage = helper.ViewDataContainer as WebPageBase;
            var virtualPath = webPage == null ? string.Empty : webPage.VirtualPath;
            MaterialCMSApplication.Get<IResourceBundler>().AddCss(virtualPath, url);
        }

        public static void RenderCss(this HtmlHelper helper)
        {
            MaterialCMSApplication.Get<IResourceBundler>().GetCss(helper.ViewContext);
        }

        public static void AddAppUIScripts(this HtmlHelper html)
        {
            foreach (var script in MaterialCMSApplication.GetAll<IAppScriptList>().SelectMany(appScriptList => appScriptList.UIScripts))
            {
                html.IncludeScript(script);
            }
        }

        public static void AddAppAdminScripts(this HtmlHelper html)
        {
            foreach (var script in MaterialCMSApplication.GetAll<IAppScriptList>().SelectMany(appScriptList => appScriptList.AdminScripts))
            {
                html.IncludeScript(script);
            }
        }

        public static void AddAppUIStylesheets(this HtmlHelper html)
        {
            foreach (var script in MaterialCMSApplication.GetAll<IAppStylesheetList>().SelectMany(appScriptList => appScriptList.UIStylesheets))
            {
                html.IncludeCss(script);
            }
        }

        public static void AddAppAdminStylesheets(this HtmlHelper html)
        {
            foreach (var script in MaterialCMSApplication.GetAll<IAppStylesheetList>().SelectMany(appScriptList => appScriptList.AdminStylesheets))
            {
                html.IncludeCss(script);
            }
        }
    }
}
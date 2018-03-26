using System;
using System.Web;
using System.Web.Optimization;

namespace LearnMore
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            ConfigureIgnoreList(bundles.IgnoreList);

            bundles.UseCdn = true;

            // jquery library bundle
            var jqueryBundle = new ScriptBundle("~/jquery").Include(
                "~/Scripts/cufon-yui.js",
                "~/Scripts/cufon-titillium-600.js",
                "~/Scripts/jquery-1.8.2.min.js",
                "~/Scripts/script.js",
                "~/Scripts/coin-slider.min.js");
            bundles.Add(jqueryBundle);



            // jquery validation library bundle
            var jqueryValBundle = new ScriptBundle("~/jqueryval", "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.10.0/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.js");
            bundles.Add(jqueryValBundle);

            // jquery unobtrusive validation library
            var jqueryUnobtrusiveValBundle = new ScriptBundle("~/jqueryunobtrusiveval", "http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js");
            bundles.Add(jqueryUnobtrusiveValBundle);

            // application script bundle
            var layoutJsBundle = new ScriptBundle("~/js").Include("~/Scripts/app.js");
            bundles.Add(layoutJsBundle);

            // css bundle
            var layoutCssBundle = new StyleBundle("~/Content/themes/simple/css").Include("~/Content/themes/simple/style.css");
            bundles.Add(layoutCssBundle);

            // login page bundles
            var loginCssBundle = new StyleBundle("~/Content/themes/simple/admin").Include("~/Content/themes/simple/admin.css");
            bundles.Add(loginCssBundle);

            // manage page bundles
            var jqueryUiBundle = new ScriptBundle("~/jqueryui", "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.1/jquery-ui.min.js").Include("~/Scripts/jquery-ui.js");
            bundles.Add(jqueryUiBundle);

            var manageCssBundle =
                new StyleBundle("~/Content/grid/bundle").Include(
                                "~/Content/themes/base/jquery.ui.all.css",
                                "~/Content/jqGrid/ui.jqgrid.css");
            bundles.Add(manageCssBundle);

            var managejqueryMin =
                new ScriptBundle("~/Scripts/jquery_min").Include("~/Scripts/jquery.jqGrid-4.4.1/jquery-1.7.2.min.js");
            bundles.Add(managejqueryMin);

            var managejqGridJsBundle =
                new ScriptBundle("~/Scripts/jqGrid").Include(
                "~/Scripts/jquery-ui-1.8.11.min.js",
                "~/Scripts/jquery.jqGrid-4.4.1/i18n/grid.locale-en.js",
                "~/Scripts/jquery.jqGrid-4.4.1/jquery.jqGrid.min.js");
            bundles.Add(managejqGridJsBundle);

            var jqueryUiCssBundle =
            new StyleBundle("~/Content/themes/simple/jqueryuicustom/css/sunny/bundle").Include("~/Content/themes/simple/jqueryuicustom/css/sunny/jquery-ui-1.9.2.custom.css");
            bundles.Add(jqueryUiCssBundle);

            var tinyMceBundle = new ScriptBundle("~/Scripts/tiny_mce/js").Include("~/Scripts/tiny_mce/tiny_mce.js");
            bundles.Add(tinyMceBundle);

            var manageJsBundle = new ScriptBundle("~/manage/js").Include("~/Scripts/jqgrid/js/jquery.jqGrid.js").Include("~/Scripts/jqgrid/js/i18n/grid.locale-en.js").Include("~/Scripts/admin.js");
            bundles.Add(manageJsBundle);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                         "~/Scripts/jquery.unobtrusive-ajax.min.js",
                                         "~/Scripts/jquery.validate.min.js",
                                         "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular/angular.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/style.css",
                "~/Content/css/coin-slider.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // Bootstrap Core CSS
            bundles.Add(new StyleBundle("~/Content/Admin/css/bootstrap").Include(
                "~/Content/Admin/css/bootstrap.min.css",
                "~/Content/Admin/css/bootstrap-theme.min.css",
                "~/Content/Admin/font-awesome/css/font-awesome.min.css"));

            // Admin Custom CSS -->
            bundles.Add(new StyleBundle("~/Content/Admin/css/sb-admin").Include("~/Content/Admin/css/sb-admin.css", "~/Content/Admin/style.css"));

            // Morris Charts CSS
            bundles.Add(new StyleBundle("~/Content/Admin/css/plugins/morris").Include("~/Content/Admin/css/plugins/morris.css"));


            bundles.Add(new ScriptBundle("~/bundles/Admin/js/jquery").Include("~/Content/Admin/js/jquery.js"));


            bundles.Add(new ScriptBundle("~/bundles/Admin/js/bootstrap").Include("~/Content/Admin/js/bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/Admin/js/plugins/morris").Include(
                "~/Content/Admin/js/plugins/morris/raphael.min.js",
                "~/Content/Admin/js/plugins/morris/morris.min.js",
                "~/Content/Admin/js/plugins/morris/morris-data.js"));


        }

        public static void ConfigureIgnoreList(IgnoreList ignoreList)
        {
            if (ignoreList == null) throw new ArgumentNullException("ignoreList");

            ignoreList.Clear(); // Clear the list, then add the new patterns.

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            // ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}
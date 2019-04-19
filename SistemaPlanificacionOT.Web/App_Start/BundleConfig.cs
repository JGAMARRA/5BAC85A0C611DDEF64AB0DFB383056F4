using System.Web.Optimization;

namespace SistemaPlanificacionOT.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/css", "*.min.css"));

            //bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/fonts", "*.eot"));
            //bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/fonts", "*.svg"));
            //bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/fonts", "*.ttf"));
            //bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/fonts", "*.woff"));
            //bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/fonts", "*.otf"));

            //            bundles.Add(new StyleBundle("~/content/smartadmin").Include("~/content/fonts/fontawesome-webfont.eot",
            //                "~/content/fonts/fontawesome-webfont.svg",
            //"~/content/fonts/fontawesome-webfont.ttf",
            //"~/content/fonts/fontawesome-webfont.woff",
            //"~/content/fonts/FontAwesome.otf",
            //"~/content/fonts/glyphicons-halflings-regular.eot",
            //"~/content/fonts/glyphicons-halflings-regular.svg",
            //"~/content/fonts/glyphicons-halflings-regular.ttf",
            //"~/content/fonts/glyphicons-halflings-regular.woff"
            //                ));

            bundles.Add(new ScriptBundle("~/scripts/smartadmin").Include(
                "~/scripts/app.config.js",
                "~/scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/scripts/bootstrap/bootstrap.min.js",
                "~/scripts/notification/SmartNotification.min.js",
                "~/scripts/smartwidgets/jarvis.widget.min.js",
                "~/scripts/plugin/jquery-validate/jquery.validate.min.js",
                "~/scripts/plugin/masked-input/jquery.maskedinput.min.js",
                "~/scripts/plugin/select2/select2.min.js",
                "~/scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                "~/scripts/plugin/fastclick/fastclick.min.js",
                "~/scripts/plugin/superbox/superbox.min.js",
                "~/scripts/plugin/superbox/superboxConsulta.min.js",
                "~/scripts/plugin/file-input/fileinput.min.js",
                "~/scripts/plugin/file-input/locales/es.js",
                  //"~/scripts/plugin/file-input/exif.js",
                "~/scripts/plugin/file-input/locales/es.js",
                "~/scripts/plugin/file-input/exif.js",
                "~/scripts/plugin/jquery-blockui/jquery.blockUI.min.js",
                "~/scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/full-calendar").Include(
                "~/scripts/plugin/moment/moment.min.js",
                "~/scripts/plugin/fullcalendar/jquery.fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/charts").Include(
                "~/scripts/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                "~/scripts/plugin/sparkline/jquery.sparkline.min.js",
                "~/scripts/plugin/morris/morris.min.js",
                "~/scripts/plugin/morris/raphael.min.js",
                "~/scripts/plugin/flot/jquery.flot.cust.min.js",
                "~/scripts/plugin/flot/jquery.flot.resize.min.js",
                "~/scripts/plugin/flot/jquery.flot.time.min.js",
                "~/scripts/plugin/flot/jquery.flot.fillbetween.min.js",
                "~/scripts/plugin/flot/jquery.flot.orderBar.min.js",
                "~/scripts/plugin/flot/jquery.flot.pie.min.js",
                "~/scripts/plugin/flot/jquery.flot.tooltip.min.js",
                "~/scripts/plugin/dygraphs/dygraph-combined.min.js",
                "~/scripts/plugin/chartjs/chart.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/datatables").Include(
                "~/Scripts/plugin/datatables/jquery.dataTables.min.js",
                "~/Scripts/plugin/datatables/dataTables.colVis.min.js",
                "~/Scripts/plugin/datatables/dataTables.tableTools.min.js",
                "~/Scripts/plugin/datatables/dataTables.bootstrap.min.js",
                "~/Scripts/plugin/datatable-responsive/datatables.responsive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/jq-grid").Include(
                "~/scripts/plugin/jqgrid/jquery.jqGrid.min.js",
                "~/scripts/plugin/jqgrid/grid.locale-en.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/forms").Include(
                "~/scripts/plugin/jquery-form/jquery-form.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/smart-chat").Include(
                "~/scripts/smart-chat-ui/smart.chat.ui.min.js",
                "~/scripts/smart-chat-ui/smart.chat.manager.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/vector-map").Include(
                "~/scripts/plugin/vectormap/jquery-jvectormap-1.2.2.min.js",
                "~/scripts/plugin/vectormap/jquery-jvectormap-world-mill-en.js"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
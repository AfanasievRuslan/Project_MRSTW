﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FitPlaneLife.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/lib/js").Include(
                "~/js/easing.min.js",
                "~/js/waypoints.min.js",
                "~/js/owl.carousel.min.js",
                "~/js/counterup.min.js"));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/main.js"));

            bundles.Add(new StyleBundle("~/img").Include(
                "~/img/favicon.ico"));

            bundles.Add(new StyleBundle("~/css").Include(
                "~/css/bootstrap.min.css",
                "~/css/style.css",
                "~/css/admin.css"));

            bundles.Add(new StyleBundle("~/lib/css").Include(
                "~/lib/owlcarousel/assets/owl.carousel.min.css",
                "~/lib/flaticon/font/flaticon.css"));

            bundles.Add(new StyleBundle("~/login/css")
                .Include("~/css/font-awesome.css",
                    "~/css/metisMenu.css",
                    "~/css/animate.css",
                    "~/css/bootstrap.css",
                    "~/css/pe-icon-7-stroke.css",
                    "~/css/helper.css",
                    "~/css/style2.css"));
            bundles.Add(new ScriptBundle("~/login/js")
                .Include("~/js/homer.js"));
        }
    }
}

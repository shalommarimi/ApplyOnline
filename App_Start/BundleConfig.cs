﻿using System.Web.Optimization;

namespace ApplyOnline.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/ng").Include(
            //    "~/Scripts/angolar.min.js",
            //    "~/Scripts/angolar-route.min.js",
            //    "~/Scripts/angolar-cookies.min.js",
            //    "~/Scripts/angolar-sanitize.min.js"
            //    ));

            bundles.Add(new ScriptBundle("~/MyScripts").Include(
                 "~/MyScripts/jquery.waypoints.min.js",
                 "~/MyScripts/waypoints.js"
             ));

            bundles.Add(new ScriptBundle("~/Scripts").Include(
                "~/Scripts/jquery-1.10.2.js",
                 "~/Scripts/jquery-ui.js"

                 ));



            bundles.Add(new StyleBundle("~/Content").Include(
                 "~/Content/bootstrap.min.css",
                 "~/Content/bootstrap-theme.min.css",
                 "~/Content/jquery-ui.css"

                 ));

            bundles.Add(new StyleBundle("~/Css").Include(
                "~/Css/animate.css",
                "~/Css/index.css",
                "~/Css/waypoints.css"

                ));


        }


    }
}
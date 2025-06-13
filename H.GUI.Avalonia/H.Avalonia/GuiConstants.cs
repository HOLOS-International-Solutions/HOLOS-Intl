﻿using H.Core.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Avalonia
{
    public class GuiConstants
    {
        #region Properties

        public static string OpenFileDialogCsvFilterString = "CSV Files (*.csv)|*.csv";

        /// <summary>
        /// Change the path in the app.config file if going to change the filename here.
        /// </summary>
        public static string LogFileName = "HolosOutput.txt";

        public static string DefaultTitleBarTitle = "HOLOS-IE";

        public static string VersionReleaseDateString
        {
            get
            {
                return DateTime.Now.ToString("MMMM dd yyyy");
            }
        }

        public static string VersionNumberString = "Version 1";
        public static string ComponentKey = "component";
        public static string AnimalGroupKey = nameof(AnimalGroup);
        public static string ManagementPeriodKey = nameof(ManagementPeriod);
        public static string DefaultSpaceBetweenLabelAndUnitsInColumnHeader = Environment.NewLine + "" + Environment.NewLine;

        #endregion

        #region Public Methods

        public static string GetVersionString()
        {
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //else
            //{
            //    return VersionNumberString;
            //}
            return "5.0.0";
        }

        #endregion
    }
}

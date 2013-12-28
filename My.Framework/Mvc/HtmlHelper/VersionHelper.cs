using System;
using System.Reflection;

namespace My.Framework.Mvc.HtmlHelper
{
    public static class VersionHelper
    {
        private static readonly Lazy<string> Version = new Lazy<string>(() =>
        {
            try
            {
                System.Version version = Assembly.GetExecutingAssembly().GetName().Version;
                return String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
            catch (Exception)
            {
                return "?.?.?.?";
            };
        });

        /// <summary>
        /// Returns the Current Version from the AssemblyInfo.cs file.
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string CurrentVersion(this System.Web.Mvc.HtmlHelper helper)
        {
            return Version.Value;
        }
    }
}
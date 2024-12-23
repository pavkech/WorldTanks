using UnityEditor.Build.Reporting;
using UnityEditor.Build;
using System.IO;

namespace YG.EditorScr.BuildModify
{
    public class ProcessBuild : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        public int callbackOrder => 0;
        public void OnPreprocessBuild(BuildReport report)
        {
            if (YG2.infoYG.Basic.autoApplySettings)
                InfoYG.Inst().Basic.platform.ApplyProjectSettings();

            string buildPath = report.summary.outputPath;

            if (buildPath != null && buildPath != string.Empty)
            {
                string indexPath = buildPath + "/index.html";
                if (File.Exists(indexPath))
                    File.Delete(indexPath);

                string stylePath = buildPath + "/style.css";
                if (File.Exists(stylePath))
                    File.Delete(stylePath);
            }
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            string pathToBuiltProject = report.summary.outputPath;

            ModifyBuild.ModifyIndex(pathToBuiltProject);
            ArchivingBuild.Archiving(pathToBuiltProject);
            BuildLog.WritingLog(pathToBuiltProject);
        }
    }
}
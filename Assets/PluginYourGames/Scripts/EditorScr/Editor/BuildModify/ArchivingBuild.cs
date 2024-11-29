﻿using System.Linq;
using System.IO;
using System.IO.Compression;

namespace YG.EditorScr.BuildModify
{
    public static class ArchivingBuild
    {
        public static void Archiving(string pathToBuiltProject)
        {
            InfoYG infoYG = YG2.infoYG;

            if (infoYG.Basic.archivingBuild)
            {
                string sign = string.Empty;

                int.TryParse(BuildLog.ReadProperty("Build number"), out int buildNumInt);
                buildNumInt += 1;
                string buildName = buildNumInt.ToString();

                if (buildName != null || buildName != "0")
                {
                    sign = "_b" + buildName;
                }

                string platform = YG2.infoYG.Basic.platform.nameBase;

                if (platform != "YandexGames")
                {
                    platform = new string(platform.Where(char.IsUpper).ToArray());
                    platform = "_" + platform.ToLower();
                    sign += platform;
                }

                sign += ".zip";
                string directory = pathToBuiltProject + sign;

                if (File.Exists(directory))
                {
                    File.Delete(directory);
                }

                ZipFile.CreateFromDirectory(pathToBuiltProject, directory);
            }
        }
    }
}
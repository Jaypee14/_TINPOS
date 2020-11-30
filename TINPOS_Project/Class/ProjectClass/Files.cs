using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.ProjectClass
{
    class Files: Shared
    {
        string projectFolder = @"C:\TINPOS";
        public string txdat_File = @"C:\TINPOS\DAT\Common.dat";

      
        

        private void CreateDir(string subFolder, string fileName)
        {
            string DebugSource = Directory.GetCurrentDirectory();
            string directory = Path.GetDirectoryName(DebugSource);
            string oneUp = Path.GetDirectoryName(directory);
            string CommonSource = oneUp + "\\" + "Class" + "\\" + fileName;

            if (!Directory.Exists(projectFolder))
                Directory.CreateDirectory(projectFolder);

            //Sub Directory
            if (!Directory.Exists(projectFolder + "\\" + subFolder))
                Directory.CreateDirectory(projectFolder + "\\" + subFolder);

            string targetPath = projectFolder + "\\" + subFolder + "\\" + fileName;

            if (File.Exists(targetPath))
                File.Delete(targetPath);
            File.Copy(CommonSource, targetPath);

        }

    }
}

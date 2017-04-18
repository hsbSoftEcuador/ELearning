using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchHsbPhoenixLoaders
{
    public class FilesManager
    {
        static private FilesManager m_Instance = null;

        static public FilesManager Instance
        {
            get { return m_Instance; }
        }

        private FilesManager() { }

        static FilesManager()
        {
            m_Instance = new FilesManager();
        }

        public void SwitchFileName(string strDirPath, string strFileName, string strPostfixToRenameFile, ref FileSwitchResult fsr)
        {
            fsr = FileSwitchResult.Unknown;

            if (String.IsNullOrEmpty(strDirPath)) return;
            if (!Directory.Exists(strDirPath)) return;

            FileInfo[] arFi = new DirectoryInfo(strDirPath).GetFiles(strFileName + "*");
            if (arFi == null) return;
            if (arFi.Length == 0) return;

            string strOldFilePath = "";
            string strNewFilePath = "";

            FileInfo fi = arFi[0];
            
            if (fi == null) return;
            if (!fi.Exists) return;

            strOldFilePath = fi.FullName;

            bool bFileIsRenamed = fi.Name.EndsWith("_");

            if (bFileIsRenamed)
            {
                strNewFilePath = strDirPath + "\\" + strFileName;
                fsr = FileSwitchResult.Enabled;
            }
            else
            {
                strNewFilePath = fi.FullName + strPostfixToRenameFile;
                fsr = FileSwitchResult.Disabled;
            }

            if (File.Exists(strOldFilePath))
            {
                File.Copy(strOldFilePath, strNewFilePath);
                File.Delete(strOldFilePath);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwitchHsbPhoenixLoaders
{
    class PackageContentsXmlManager
    {
        static private PackageContentsXmlManager m_Instance = null;

        private string m_strProgramDataDirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private string m_strPackageContentsInternalDirPath = "Autodesk\\ApplicationPlugins\\hsbOnRevit.bundle";
        private string m_strPackageContentsXmlFileName = "PackageContents.xml";
        private string m_strPostfixToRenamePackageContents = "__";

        public string PackageContentsDirPath
        {
            get
            {
                string strPackageContentsDirPath = m_strProgramDataDirPath;

                if (!strPackageContentsDirPath.EndsWith("\\"))
                    strPackageContentsDirPath += "\\";

                strPackageContentsDirPath += m_strPackageContentsInternalDirPath;

                return strPackageContentsDirPath;
            }
        }

        static public PackageContentsXmlManager Instance
        {
            get { return m_Instance; }
        }

        private PackageContentsXmlManager() { }

        static PackageContentsXmlManager()
        {
            m_Instance = new PackageContentsXmlManager();
        }

        public bool SwitchPackageContents(ref FileSwitchResult fsr, ref string strReturnMsg)
        {
            fsr = FileSwitchResult.Unknown;
            strReturnMsg = "";

            if (!Directory.Exists(PackageContentsDirPath))
            {
                strReturnMsg = "The path: " + PackageContentsDirPath + " does not exist.";
                return false;
            }

            FilesManager.Instance.SwitchFileName(PackageContentsDirPath, m_strPackageContentsXmlFileName, m_strPostfixToRenamePackageContents, ref fsr);

            return true;
        }
    }
}

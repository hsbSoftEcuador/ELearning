using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchHsbPhoenixLoaders
{
    public class AddInsManager
    {
        static private AddInsManager m_Instance = null;

        private string m_strProgramDataDirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private string m_strAddInsInternalDirPath = "Autodesk\\Revit\\Addins";
        private string m_strPhoenixAddInFileName = "Phoenix.addin";
        private string m_strPostfixToRenameAddIn = "__";

        public string AddInsDirPath
        {
            get
            {
                string strAddInsDirPath = m_strProgramDataDirPath;

                if (!strAddInsDirPath.EndsWith("\\"))
                    strAddInsDirPath += "\\";

                strAddInsDirPath += m_strAddInsInternalDirPath;

                return strAddInsDirPath;
            }
        }

        static public AddInsManager Instance
        {
            get { return m_Instance; }
        }

        private AddInsManager() { }

        static AddInsManager()
        {
            m_Instance = new AddInsManager();
        }

        public bool SwitchAddIns(ref AddInSwitchs addInSwitchs, ref string strReturnMsg)
        {
            addInSwitchs = new AddInSwitchs();

            strReturnMsg = "";

            if (!Directory.Exists(AddInsDirPath))
            {
                strReturnMsg = "The path: " + AddInsDirPath + " does not exist.";
                return false;
            }

            //////////////////////////////////////////////////////////////////////////

            string strPhoenixAddInVersionDirPath = "";
            FileSwitchResult fsr = FileSwitchResult.Unknown;

            DirectoryInfo[] arDiVersions = new DirectoryInfo(AddInsDirPath).GetDirectories();

            if (arDiVersions == null)
            {
                strReturnMsg = "There is no Revit versions installed.";
                return false;
            }

            if (arDiVersions.Length == 0)
            {
                strReturnMsg = "There is no any Revit version installed.";
                return false;
            }

            int iVersion = -1;

            foreach(DirectoryInfo diVersion in arDiVersions)
            {
                if (diVersion == null) continue;

                try
                {
                    iVersion = Convert.ToInt16(diVersion.Name);
                }
                catch (Exception)
                {
                    continue;
                }

                strPhoenixAddInVersionDirPath = diVersion.FullName;
                FilesManager.Instance.SwitchFileName(strPhoenixAddInVersionDirPath, m_strPhoenixAddInFileName, m_strPostfixToRenameAddIn, ref fsr);
               
                AddInSwitch addInSwitch = new AddInSwitch(iVersion, fsr);
                addInSwitchs.AddInSwitchInstances.Add(addInSwitch);
            }

            //////////////////////////////////////////////////////////////////////////

            return true;
        }
    }
}

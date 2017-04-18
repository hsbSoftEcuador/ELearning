using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SwitchHsbPhoenixLoaders
{
    class Program
    {
        static private string GetAddInSwitchsResultMsg(AddInSwitchs addInSwitchs)
        {
            if (addInSwitchs == null) return "";

            if (addInSwitchs.AddInSwitchInstances == null) return "";
            if (addInSwitchs.AddInSwitchInstances.Count == 0) return "";

            string strMsg = "";

            foreach(AddInSwitch addInSwitch in addInSwitchs.AddInSwitchInstances)
            {
                if (addInSwitch == null) continue;

                if (!String.IsNullOrEmpty(strMsg))
                    strMsg += "\n";

                strMsg += "- The AddIn for the " + addInSwitch.Version.ToString() + " ";

                if (addInSwitch.FileSwitchResultAssociated == FileSwitchResult.Enabled)
                    strMsg += "is enabled.";
                else if (addInSwitch.FileSwitchResultAssociated == FileSwitchResult.Disabled)
                    strMsg += "is disabled.";
                if (addInSwitch.FileSwitchResultAssociated == FileSwitchResult.Unknown)
                    strMsg += "does not exist.";
            }

            return strMsg;
        }

        static int Main(string[] args)
        {
            string strReturnMsg = "";
            string strMsg = "";

            AddInSwitchs addInSwitchs = new AddInSwitchs();

            if (!AddInsManager.Instance.SwitchAddIns(ref addInSwitchs, ref strReturnMsg))
            {
                strMsg = "The AddIns could not be switched.";
                
                if(!String.IsNullOrEmpty(strReturnMsg))
                    strMsg += "\n\n" + strReturnMsg;

                Console.WriteLine(strMsg);
                Console.ReadKey();

                return 1;
            }

            FileSwitchResult fsrPackageContents = FileSwitchResult.Unknown;

            if (!PackageContentsXmlManager.Instance.SwitchPackageContents(ref fsrPackageContents, ref strReturnMsg))
            {
                strMsg = "This machine only contains the Development version.";

                if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Enabled)
                    strMsg += "\n\n" + "The AddIns were enabled successfully.";
                else if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Disabled)
                    strMsg += "\n\n" + "The AddIns were disabled successfully.";
                else if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Mixed)
                {
                    strMsg += "\n\n" + "Some AddIns are enabled and some are disabled. They were switched. You should check that all are enabled or all are disabled.";
                    strMsg += "\n" + GetAddInSwitchsResultMsg(addInSwitchs);
                }
                else
                    strMsg += "\n\n" + "The state of some AddIns is unknown. You should check that all are enabled or all are disabled.";

                if (!String.IsNullOrEmpty(strReturnMsg))
                    strMsg += "\n\n" + strReturnMsg;

                Console.WriteLine(strMsg);
                Console.ReadKey();

                return 1;
            }

            if (addInSwitchs.IsFileResultEquivalentToAddInsSwitchResult(fsrPackageContents))
            {
                strMsg += "The Development and User versions were ";
                if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Enabled)
                    strMsg += "enabled.";
                else if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Disabled)
                    strMsg += "disabled";
            }
            else if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Enabled)
                strMsg += "The Development version was enabled and the User version was disabled.";
            else if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Disabled)
                strMsg += "The User version was enabled and the Development version was disabled.";
            else if (addInSwitchs.AddInsSwitchResultAssociated == AddInsSwitchResult.Mixed)
            {
                strMsg += "Some AddIns are enabled and some are disabled. They were switched. You should check that all are enabled or all are disabled.";
                strMsg += "\n" + GetAddInSwitchsResultMsg(addInSwitchs);
            }
            else
                strMsg += "The state of some AddIns is unknown. You should check that all are enabled or all are disabled.";

            Console.WriteLine(strMsg);
            Console.ReadKey();

            return 0;
        }
    }
}
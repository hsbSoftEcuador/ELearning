using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchHsbPhoenixLoaders
{
    public class AddInSwitchs
    {
        private List<AddInSwitch> m_lstAddInsSwitchInstances = new List<AddInSwitch>();

        public List<AddInSwitch> AddInSwitchInstances
        {
            get { return m_lstAddInsSwitchInstances; }
        }

        public AddInsSwitchResult AddInsSwitchResultAssociated
        {
            get { return GetAddInsSwitchResult(); }
        }

        public AddInSwitchs() { }

        private void CheckAddInsSwitchResult(FileSwitchResult fsr, ref AddInsSwitchResult addInsSwitchResult)
        {
            if (fsr == FileSwitchResult.Enabled)
            {
                if (addInsSwitchResult == AddInsSwitchResult.Unknown)
                    addInsSwitchResult = AddInsSwitchResult.Enabled;
                else if (addInsSwitchResult != AddInsSwitchResult.Enabled)
                    addInsSwitchResult = AddInsSwitchResult.Mixed;
            }
            else if (fsr == FileSwitchResult.Disabled)
            {
                if (addInsSwitchResult == AddInsSwitchResult.Unknown)
                    addInsSwitchResult = AddInsSwitchResult.Disabled;
                else if (addInsSwitchResult != AddInsSwitchResult.Disabled)
                    addInsSwitchResult = AddInsSwitchResult.Mixed;
            }
        }

        private AddInsSwitchResult GetAddInsSwitchResult()
        {
            if (m_lstAddInsSwitchInstances == null)
                return AddInsSwitchResult.Unknown;
            if (m_lstAddInsSwitchInstances.Count == 0)
                return AddInsSwitchResult.Unknown;

            AddInsSwitchResult addInsSwitchResult = AddInsSwitchResult.Unknown;

            foreach(AddInSwitch addInSwitch in m_lstAddInsSwitchInstances)
            {
                if (addInSwitch == null) continue;

                CheckAddInsSwitchResult(addInSwitch.FileSwitchResultAssociated, ref addInsSwitchResult);
            }

            return addInsSwitchResult;
        }

        public bool IsFileResultEquivalentToAddInsSwitchResult(FileSwitchResult fsr)
        {
            if (AddInsSwitchResultAssociated == AddInsSwitchResult.Enabled)
            {
                if (fsr == FileSwitchResult.Enabled)
                    return true;
            }
            else if(AddInsSwitchResultAssociated == AddInsSwitchResult.Disabled)
            {
                if (fsr == FileSwitchResult.Disabled)
                    return true;
            }

            return false;
        }
    }
}

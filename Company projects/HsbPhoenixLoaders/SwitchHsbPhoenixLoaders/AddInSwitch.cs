using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchHsbPhoenixLoaders
{
    public class AddInSwitch
    {
        private int m_iVersion = -1;
        private FileSwitchResult m_FileSwitchResult = FileSwitchResult.Unknown;

        public int Version
        {
            get { return m_iVersion; }
        }

        public FileSwitchResult FileSwitchResultAssociated
        {
            get { return m_FileSwitchResult; }
        }

        public AddInSwitch(int iVersion, FileSwitchResult fsr)
        {
            this.m_iVersion = iVersion;
            this.m_FileSwitchResult = fsr;
        }
    }
}

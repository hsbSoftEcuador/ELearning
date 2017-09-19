using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.MDI;

namespace DataBankUI
{
    public class RibbonsManager
    {
        static private RibbonsManager m_Instance = null;

        static public RibbonsManager Instance
        {
            get { return m_Instance; }
        }

        private RibbonsManager()
        {
            m_Instance = new RibbonsManager();
        }
        
        public void CreateDialog (DatabankDialogId databankDialogId, MdiContainer addDatabankDialog)
        {
            if (databankDialogId == DatabankDialogId.Fingerprints)
            {
                addDatabankDialog.Children.Add(new MdiChild()
                {
                    Title = "Fingerprints",
                    Resizable = true,
                    MinimizeBox = true,
                    MaximizeBox = true
                });
            }
        }
    }
}

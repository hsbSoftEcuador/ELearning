using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace DataBankUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Initialize();
        }

        private void InitializeCommands()
        {
            CommandBinding cmdBinding = null;

            // Always show the close command and upon execution close the application
            cmdBinding = new CommandBinding(ApplicationCommands.Close);
            cmdBinding.PreviewExecuted += new ExecutedRoutedEventHandler(delegate (object sender, ExecutedRoutedEventArgs e) { this.Close(); e.Handled = true; });
            cmdBinding.CanExecute += new CanExecuteRoutedEventHandler(delegate (object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; });
            cmdBinding.PreviewCanExecute += new CanExecuteRoutedEventHandler(delegate (object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; });
            CommandBindings.Add(cmdBinding);

            // Always show the New command and upon execution create a new window in the MwiWindow control.
            cmdBinding = new CommandBinding(ApplicationCommands.New);
            cmdBinding.PreviewExecuted += new ExecutedRoutedEventHandler(delegate (object sender, ExecutedRoutedEventArgs e) { this.gMwiWindow.CreateNewMwiChild(); e.Handled = true; });
            cmdBinding.CanExecute += new CanExecuteRoutedEventHandler(delegate (object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; });
            cmdBinding.PreviewCanExecute += new CanExecuteRoutedEventHandler(delegate (object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; });
            CommandBindings.Add(cmdBinding);
        }

        private void Initialize()
        {
            InitializeCommands();
        }

        private void btnCreateFingerprintMainWindow_Click(object sender, RoutedEventArgs e)
        {
            //if (addDatabankDialog.Children.Count < 1)
            //{
            //    addDatabankDialog.Children.Add(new WPF.MDI.MdiChild()
            //    {
            //        Title = "Fingerprints",
            //        Resizable = true,
            //        MinimizeBox = true,
            //        MaximizeBox = true
            //    });
            //}
        }

        private void btnCreateFingerprintWindow_Click(object sender, RoutedEventArgs e)
        {           
            //RibbonsManager rebonsManager = RibbonsManager.Instance.CreateDialog();
        }

        private void btnCreateNewLicenses_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLicensesAdministrator_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLicenses_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLicensesMaintenance_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnModulePackageManager_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCostumerOfficePackagesManager_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCostumers_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCostumersPermissionsForProducts_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCostumersFileManager_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLicensesReport_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLicensesMaintenanceReport_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddFingerprintsButton_Click(object sender, RoutedEventArgs e)
        {
            //fix problem of conditions
            if (toolbar.Items.Count < 1)
            {
                Button btnFingerprintsToolbar = new Button();
                btnFingerprintsToolbar.Content = "Fingerprints";
                btnFingerprintsToolbar.Click += btnCreateFingerprintWindow_Click;
                btnAddItemToolbar.Icon = 
                toolbar.Items.Add(btnFingerprintsToolbar);
            }
            else
            {
                MessageBox.Show("This item is already added");
            }
        }

        private void btnAddCreateNewLicensesButton_Click(object sender, RoutedEventArgs e)
        {
            if (toolbar.Items.Count < 1)
            {
                Button btnCreateNewLicensesToolbar = new Button();
                btnCreateNewLicensesToolbar.Content = "Create New Licenses";
                btnCreateNewLicensesToolbar.Click += btnCreateNewLicenses_Click;
                toolbar.Items.Add(btnCreateNewLicensesToolbar);
            }
            else
            {
                MessageBox.Show("This item is already added");
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        void ContextMenu_Closed(object sender, RoutedEventArgs e)
        {
            //isContextMenuOpen = false;
            var contextMenu = sender as ContextMenu;
            if (contextMenu != null)
            {
                contextMenu.RemoveHandler(ContextMenu.ClosedEvent, new RoutedEventHandler(ContextMenu_Closed));

                int iAttachedCount = 0;

                Interlocked.Decrement(ref iAttachedCount);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
                toolbar.Items.Remove(RemoveTest);
        }

        //private void lblFingerprints_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!(sender is Label))
        //    {
        //        return;
        //    }

        //    Label label = sender as Label;
        //    if (label.ContextMenu == null)
        //    {
        //        return;
        //    }

        //    //label.ContextMenu.AddHandler(ContextMenu.ClosedEvent, new RoutedEventHandler(ContextMenu_Closed), true);

        //    //int iAttachedCount = 0;

        //    //Interlocked.Increment(ref iAttachedCount);
        //    // If there is a drop-down assigned to this button, then position and display it 
        //    label.ContextMenu.PlacementTarget = label;
        //    label.ContextMenu.Placement = PlacementMode.Right;
        //    label.ContextMenu.IsOpen = true;
        //    //isContextMenuOpen = true;
        //}

        //private void lblLicensing_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    if (!(sender is Label))
        //    {
        //        return;
        //    }

        //    Label label = sender as Label;
        //    if (label.ContextMenu == null)
        //    {
        //        return;
        //    }

        //    label.ContextMenu.IsOpen = false;
        //}
    }
}
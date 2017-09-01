﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBankUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void customize(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world");
        }

        private void HelloWorld(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world");
        }
    }
}

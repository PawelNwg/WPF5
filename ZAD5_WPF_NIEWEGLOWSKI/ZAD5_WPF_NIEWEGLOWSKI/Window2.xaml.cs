﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZAD5_WPF_NIEWEGLOWSKI
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
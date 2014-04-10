﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for InfolineController.xaml
    /// </summary>
    public partial class InfolineController : UserControl
    {
        public String Title { get { return label.Content.ToString(); } set { label.Content = value; } }

        public String Text { get { return textbox.Text; } set { textbox.Text = value; } }

        public event TextChangedEventHandler TextChanged { add { textbox.TextChanged += value; } remove { textbox.TextChanged -= value; } }

        public bool Sorted { get; set; }

        public bool readOnly { set { textbox.IsReadOnly = value; } }

        public InfolineController()
        {
            InitializeComponent();
        }
    }
}

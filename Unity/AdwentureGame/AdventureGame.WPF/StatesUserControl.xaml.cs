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

namespace AdventureGame.WPF {
  /// <summary>
  /// Interaction logic for UserControl1.xaml
  /// </summary>
  public partial class StatesUserControl : UserControl {
    public StatesUserControl() {
      InitializeComponent();

      this.Loaded += StatesUserControl_Loaded;
    }

    private void StatesUserControl_Loaded(object sender, RoutedEventArgs e) {

      //this.DataContext = new 
    }
  }
}

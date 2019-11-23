//using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.WpfGraphControl;
//using Microsoft.Msagl.WpfGraphControl;
using System;
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
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    ServiceLocator locator;

    public MainWindow() {
      InitializeComponent();

      this.Loaded += MainWindow_Loaded;

    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e) {

      locator = new ServiceLocator();

      this.DataContext = locator.MainViewModel;

      //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
      GraphViewer viewer = new GraphViewer();
      viewer.BindToPanel(dockPanel);
      //dockPanel.Children.Add(viewer);

      Graph graph = new Graph("graph");

      graph.AddEdge("A", "B");
      graph.AddEdge("2", "7");
      graph.AddEdge("10", "11");
      graph.AddEdge("10", "12");
      graph.AddEdge("2", "10");
      graph.AddEdge("8", "10");
      graph.AddEdge("5", "10");
      graph.AddEdge("13", "14");
      graph.AddEdge("13", "15");
      graph.AddEdge("8", "13");
      graph.AddEdge("2", "13");
      graph.AddEdge("5", "13");
      graph.AddEdge("16", "17");
      graph.AddEdge("16", "18");
      graph.AddEdge("16", "18");
      graph.AddEdge("19", "20");
      graph.AddEdge("19", "21");
      graph.AddEdge("17", "19");
      graph.AddEdge("2", "19");
      graph.AddEdge("22", "23");

      graph.Attr.LayerDirection = LayerDirection.TB;
      viewer.Graph = graph; // throws exception
    }
  }
}

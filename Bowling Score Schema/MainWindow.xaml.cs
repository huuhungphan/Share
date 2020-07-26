using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Bowling_Score_Schema
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    private ObservableCollection<ScoreView> scoreViews = new ObservableCollection<ScoreView>();
    public IEnumerable ScoreViews => scoreViews;
    public event PropertyChangedEventHandler PropertyChanged;

    public MainWindow()
    {
      InitializeComponent();
      DataContext = this;
    }

    private void OnPropertyChanged(string property)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    async private void On_Add_Bowler(object sender, RoutedEventArgs e)
    {
      var scoreView = await CreateBowler.GetAndPost(scoreViews, StatusBar);
      OnPropertyChanged(nameof(ScoreViews));
    }

    private void On_Clear(object sender, RoutedEventArgs e)
    {
      scoreViews.Clear();
      OnPropertyChanged(nameof(ScoreViews));
      StatusBar.Text = "Cleared.";
    }
  }
}

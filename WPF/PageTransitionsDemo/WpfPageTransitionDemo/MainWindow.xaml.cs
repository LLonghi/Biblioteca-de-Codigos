using System;
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
using System.Windows.Media.Animation;
using System.Threading.Tasks;
using System.Threading;
using WpfPageTransitions;

namespace WpfPageTransitionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<UserControl> pages = new Stack<UserControl>();

        public MainWindow()
        {
            InitializeComponent();

            pageTransitionControl.TransitionType = PageTransitionType.Fade;

            pageTransitionControl.ShowPage(xN);
        }

        Home xN = new Home();
        NewPage newPage = new NewPage();

        UserControl1 x = new UserControl1();
        int last = 0;
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (last == 0)
            {
                pageTransitionControl.ShowPage(newPage);
                last = 1;
            }
            else
            {
                pageTransitionControl.ShowPage(x);
                last = 0;
            }
        }

        private void cmbTransitionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageTransitionControl.TransitionType = (PageTransitionType)Enum.Parse(typeof(PageTransitionType), cmbTransitionTypes.SelectedItem.ToString(), true);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            pageTransitionControl.TransitionType = PageTransitionType.Fade;

            pageTransitionControl.ShowPage(xN);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {

            pageTransitionControl.TransitionType = PageTransitionType.SlideAndFade;
            pageTransitionControl.ShowPage(x);
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            pageTransitionControl.TransitionType = PageTransitionType.SlideAndFade;
            pageTransitionControl.ShowPage(newPage);
        }
    }
}

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

namespace HPCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int hitDieInt;
        private int percentageInt;
        private int currentLevelInt;
        private int conModInt;
        private int favoredHPInt;
        private int totalHPInt;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {
            hitDieInt = getValue(hitDie);
            percentageInt = getPercent(percent);
            currentLevelInt = getValue(currentLevel);
            conModInt = getValue(conMod);
            favoredHPInt = getValue(favoredHP);
            totalHPInt = (currentLevelInt * conModInt) + favoredHPInt + hitDieInt
                         + (percentageInt * hitDieInt * (currentLevelInt - 1)) / 100;
            totalHP.Text = totalHPInt.ToString();
        }

        private int getValue(TextBox text)
        {
            int result;
            if (!int.TryParse(text.Text, out result))
            {
                result = 0;
            }
            text.Text = result.ToString();
            return result;
        }

        private int getPercent(TextBox text)
        {
            decimal percent;
            if (!decimal.TryParse(text.Text, out percent))
            {
                percent = 0;
            }
            else
            {
                if (percent < 1)
                {
                    percent *= 100;
                }
            }
            int result = (int)percent;
            text.Text = result.ToString();
            return result;
        }
    }
}

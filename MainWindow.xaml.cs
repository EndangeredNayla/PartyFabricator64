using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PartyFabricator64
{
    public partial class MainWindow : Window
    {
        int mp = 1;
        Player p1 = new Player(0);
        Player p2 = new Player(1);
        Player p3 = new Player(2);
        Player p4 = new Player(3);

        public MainWindow()
        {
            InitializeComponent();

            radMP1.IsChecked = true;
            radMP3.IsEnabled = false;

            cbxBoard.SelectedIndex = 0;

            cbxP1.SelectedIndex = 0;
            cbxP2.SelectedIndex = 1;
            cbxP3.SelectedIndex = 2;
            cbxP4.SelectedIndex = 3;

            txtSFirst.Text = "0";
            txtSSecond.Text = "0";
            txtSThird.Text = "0";
            txtSFourth.Text = "0";

            txtCFirst.Text = "0";
            txtCSecond.Text = "0";
            txtCThird.Text = "0";
            txtCFourth.Text = "0";
        }

        private void updateChar(object sender, SelectionChangedEventArgs e)
        {
            p1.setPlayer(cbxP1.SelectedIndex, mp == 3);
            p2.setPlayer(cbxP2.SelectedIndex, mp == 3);
            p3.setPlayer(cbxP3.SelectedIndex, mp == 3);
            p4.setPlayer(cbxP4.SelectedIndex, mp == 3);

            ImageBuilder.saveFile(ImageBuilder.makeResult(mp, cbxBoard.SelectedIndex, p1, p2, p3, p4));
        }

        private void radMP1_Checked(object sender, RoutedEventArgs e)
        {
            mp = 1;

            for (int i = cbxBoard.Items.Count; i > 0; i--) cbxBoard.Items.RemoveAt(i - 1);
            cbxBoard.Items.Add("DK's Jungle Adventure");
            cbxBoard.Items.Add("Peach's Birthday Cake");
            cbxBoard.Items.Add("Yoshi's Tropical Island");
            cbxBoard.Items.Add("Wario's Battle Canyon");
            cbxBoard.Items.Add("Luigi's Engine Room");
            cbxBoard.Items.Add("Mario's Rainbow Castle");
            cbxBoard.Items.Add("Bowser's Magma Mountain");
            cbxBoard.Items.Add("Eternal Star");
            cbxBoard.SelectedIndex = 0;

            if (cbxP1.Items.Count > 6)
            {
                if (cbxP1.SelectedIndex > 5) cbxP1.SelectedIndex = 0;
                for (int i = cbxP1.Items.Count; i > 6; i--)
                {
                    cbxP1.Items.RemoveAt(i - 1);
                }
            }

            if (cbxP2.Items.Count > 6)
            {
                if (cbxP2.SelectedIndex > 5) cbxP2.SelectedIndex = 0;
                for (int i = cbxP2.Items.Count; i > 6; i--)
                {
                    cbxP2.Items.RemoveAt(i - 1);
                }
            }

            if (cbxP3.Items.Count > 6)
            {
                if (cbxP3.SelectedIndex > 5) cbxP3.SelectedIndex = 0;
                for (int i = cbxP3.Items.Count; i > 6; i--)
                {
                    cbxP3.Items.RemoveAt(i - 1);
                }
            }

            if (cbxP4.Items.Count > 6)
            {
                if (cbxP4.SelectedIndex > 5) cbxP4.SelectedIndex = 0;
                for (int i = cbxP4.Items.Count; i > 6; i--)
                {
                    cbxP4.Items.RemoveAt(i - 1);
                }
            }
            ImageBuilder.saveFile(ImageBuilder.makeResult(mp, cbxBoard.SelectedIndex, p1, p2, p3, p4));
        }

        private void radMP2_Checked(object sender, RoutedEventArgs e)
        {
            mp = 2;

            for (int i = cbxBoard.Items.Count; i > 0; i--) cbxBoard.Items.RemoveAt(i - 1);
            cbxBoard.Items.Add("Pirate Land");
            cbxBoard.Items.Add("Western Land");
            cbxBoard.Items.Add("Space Land");
            cbxBoard.Items.Add("Mystery Land");
            cbxBoard.Items.Add("Horror Land");
            cbxBoard.Items.Add("Bowser Land");
            cbxBoard.SelectedIndex = 0;

            if (cbxP1.Items.Count > 6)
            {
                if (cbxP1.SelectedIndex > 5) cbxP1.SelectedIndex = 0;
                for (int i = cbxP1.Items.Count; i > 6; i--)
                {
                    cbxP1.Items.RemoveAt(i - 1);
                }
            }

            if (cbxP2.Items.Count > 6)
            {
                if (cbxP2.SelectedIndex > 5) cbxP2.SelectedIndex = 0;
                for (int i = cbxP2.Items.Count; i > 6; i--)
                {
                    cbxP2.Items.RemoveAt(i - 1);
                }
            }

            if (cbxP3.Items.Count > 6)
            {
                if (cbxP3.SelectedIndex > 5) cbxP3.SelectedIndex = 0;
                for (int i = cbxP3.Items.Count; i > 6; i--)
                {
                    cbxP3.Items.RemoveAt(i - 1);
                }
            }

            if (cbxP4.Items.Count > 6)
            {
                if (cbxP4.SelectedIndex > 5) cbxP4.SelectedIndex = 0;
                for (int i = cbxP4.Items.Count; i > 6; i--)
                {
                    cbxP4.Items.RemoveAt(i - 1);
                }
            }
            ImageBuilder.saveFile(ImageBuilder.makeResult(mp, cbxBoard.SelectedIndex, p1, p2, p3, p4));
        }

        private void radMP3_Checked(object sender, RoutedEventArgs e)
        {
            mp = 3;

            for (int i = cbxBoard.Items.Count; i > 0; i--) cbxBoard.Items.RemoveAt(i - 1);
            cbxBoard.Items.Add("Chilly Waters");
            cbxBoard.Items.Add("Deep Bloober Sea");
            cbxBoard.Items.Add("Spiny Desert");
            cbxBoard.Items.Add("Woody Woods");
            cbxBoard.Items.Add("Creepy Cavern");
            cbxBoard.Items.Add("Waluigi's Island");
            cbxBoard.SelectedIndex = 0;

            cbxP1.Items.Add("Daisy");
            cbxP1.Items.Add("Waluigi");
            cbxP2.Items.Add("Daisy");
            cbxP2.Items.Add("Waluigi");
            cbxP3.Items.Add("Daisy");
            cbxP3.Items.Add("Waluigi");
            cbxP4.Items.Add("Daisy");
            cbxP4.Items.Add("Waluigi");

            ImageBuilder.saveFile(ImageBuilder.makeResult(mp, cbxBoard.SelectedIndex, p1, p2, p3, p4));
        }

        private void balanceUpdate(object sender, TextChangedEventArgs e)
        {
            p1.setStars(parseStars(txtSFirst.Text));
            p2.setStars(parseStars(txtSSecond.Text));
            p3.setStars(parseStars(txtSThird.Text));
            p4.setStars(parseStars(txtSFourth.Text));

            p1.setCoins(parseCoins(txtCFirst.Text));
            p2.setCoins(parseCoins(txtCSecond.Text));
            p3.setCoins(parseCoins(txtCThird.Text));
            p4.setCoins(parseCoins(txtCFourth.Text));

            ImageBuilder.saveFile(ImageBuilder.makeResult(mp, cbxBoard.SelectedIndex, p1, p2, p3, p4));
        }

        private int parseStars(string str)
        {
            int numS;
            int.TryParse(str, out numS);

            if (numS > 99) numS = 99;
            else if (numS < 0) numS = 0;
            return numS;

        }

        private int parseCoins(string str)
        {
            int numC;
            int.TryParse(str, out numC);

            if (numC > 999) numC = 999;
            else if (numC < 0) numC = 0;
            return numC;
        }

        private void cbxBoard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImageBuilder.saveFile(ImageBuilder.makeResult(mp, cbxBoard.SelectedIndex, p1, p2, p3, p4));
        }
    }
}
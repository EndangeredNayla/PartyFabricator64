using PartyFabricator64.Properties;
using System;
using System.Configuration;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PartyFabricator64
{
    public partial class MainWindow : Window
    {
        Settings config = Properties.Settings.Default;
        bool ready = false;
        bool switching = false;
        int mp = 1;
        Player p1 = new Player(0);
        Player p2 = new Player(1);
        Player p3 = new Player(2);
        Player p4 = new Player(3);

        //Constructor, sets all of the ticks and boxes to their default values
        public MainWindow()
        {
            InitializeComponent();

            switch ((int)config["game"])
            {
                case 1:
                    radMP1.IsChecked = true;
                    mp = 1;
                    break;
                case 2:
                    radMP2.IsChecked = true;
                    mp = 2;
                    break;
                case 3:
                    radMP3.IsChecked = true;
                    break;
                default:
                    radMP1.IsChecked = true;
                    mp = 3;
                    break;
            }

            cbxBoard.SelectedIndex = (int)config["board"];

            cbxP1.SelectedIndex = (int)config["p1p"];
            cbxP2.SelectedIndex = (int)config["p2p"];
            cbxP3.SelectedIndex = (int)config["p3p"];
            cbxP4.SelectedIndex = (int)config["p4p"];

            txtSFirst.Text = (string)config["p1s"];
            txtSSecond.Text = (string)config["p2s"];
            txtSThird.Text = (string)config["p3s"];
            txtSFourth.Text = (string)config["p4s"];

            txtCFirst.Text = (string)config["p1c"];
            txtCSecond.Text = (string)config["p2c"];
            txtCThird.Text = (string)config["p3c"];
            txtCFourth.Text = (string)config["p4c"];

            ready = true;

            update();
        }


        /*
         * Run whenever a character combo box is changed. 
         * - Will update all player variable values, images in the application, and the results image itself.
         */
        private void updateChar(object sender, SelectionChangedEventArgs e)
        {
            p1.setPlayer(cbxP1.SelectedIndex, mp == 3);
            p2.setPlayer(cbxP2.SelectedIndex, mp == 3);
            p3.setPlayer(cbxP3.SelectedIndex, mp == 3);
            p4.setPlayer(cbxP4.SelectedIndex, mp == 3);

            update();
        }

        /*
         * Runs whenever the game radio button at the top is changed to MP1.
         * - Changes the list of available boards and adjusts character select accordingly.
         */
        private void radMP1_Checked(object sender, RoutedEventArgs e)
        {
            mp = 1;
            switching = true;

            for (int i = cbxBoard.Items.Count; i > 1; i--) cbxBoard.Items.RemoveAt(i - 1);
            cbxBoard.Items[0] = "DK's Jungle Adventure";
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

            switching = false;
            update();
        }


        /*
         * Runs whenever the game radio button at the top is changed to MP2.
         * - Changes the list of available boards and adjusts character select accordingly.
         */
        private void radMP2_Checked(object sender, RoutedEventArgs e)
        {
            mp = 2;
            switching = true;

            for (int i = cbxBoard.Items.Count; i > 1; i--) cbxBoard.Items.RemoveAt(i - 1);
            cbxBoard.Items[0] = "Pirate Land";
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

            switching = false;
            update();
        }


        /*
         * Runs whenever the game radio button at the top is changed to MP3.
         * - Changes the list of available boards and adds the MP3-exclusive characters to the list.
         */
        private void radMP3_Checked(object sender, RoutedEventArgs e)
        {
            mp = 3;
            switching = true;

            for (int i = cbxBoard.Items.Count; i > 1; i--) cbxBoard.Items.RemoveAt(i - 1);
            cbxBoard.Items[0] = "Chilly Waters";
            cbxBoard.Items.Add("Deep Bloober Sea");
            cbxBoard.Items.Add("Spiny Desert");
            cbxBoard.Items.Add("Woody Woods");
            cbxBoard.Items.Add("Creepy Cavern");
            cbxBoard.Items.Add("Waluigi's Island");
            cbxBoard.Items.Add("Custom Board");
            cbxBoard.SelectedIndex = 0;

            cbxP1.Items.Add("Daisy");
            cbxP1.Items.Add("Waluigi");
            cbxP2.Items.Add("Daisy");
            cbxP2.Items.Add("Waluigi");
            cbxP3.Items.Add("Daisy");
            cbxP3.Items.Add("Waluigi");
            cbxP4.Items.Add("Daisy");
            cbxP4.Items.Add("Waluigi");

            switching = false;
            update();
        }


        /*
         * Runs whenever any of the coin or star balance text boxes are updated.
         * - Updates the player variables with proper coin and star count, saves the results image.
         */
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

            update(true);
        }

        /*
         * Runs whenever the board is changed.
         * - Updates results image.
         */
        private void cbxBoard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update(true);
        }

        /*
         * Helper used to try to convert the value in the text boxes to a star count.
         * If it cannot be done, the value will default to 0.
         */
        private int parseStars(string str)
        {
            int numS;
            int.TryParse(str, out numS);

            if (numS > 99) numS = 99;
            else if (numS < 0) numS = 0;
            return numS;

        }

        /*
         * Helper used to try to convert the value in the text boxes to a coin count.
         * If it cannot be done, the value will default to 0.
         */
        private int parseCoins(string str)
        {
            int numC;
            int.TryParse(str, out numC);

            if (numC > 999) numC = 999;
            else if (numC < 0) numC = 0;
            return numC;
        }

        /*
         * Updates the images in software and writes to the results.png file.
         */
        private void update()
        {
            update(false);
        }

        private void update(bool skipUi)
        {
            if (!ready) return;
            if (switching) return;
            if (!skipUi)
            {
                if (mp != 1)
                {
                    imgFirst.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p1.getPlayer()}.png", UriKind.Relative));
                    imgSecond.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p2.getPlayer()}.png", UriKind.Relative));
                    imgThird.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p3.getPlayer()}.png", UriKind.Relative));
                    imgFourth.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p4.getPlayer()}.png", UriKind.Relative));
                } else {
                    imgFirst.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p1.getPlayer()}w.png", UriKind.Relative));
                    imgSecond.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p2.getPlayer()}n.png", UriKind.Relative));
                    imgThird.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p3.getPlayer()}n.png", UriKind.Relative));
                    imgFourth.Source = new BitmapImage(new Uri($@"assets/mp{mp}/characters/{p4.getPlayer()}l.png", UriKind.Relative));
                }
            }
            Player[] match = new Player[4];
            match[0] = p1;
            match[1] = p2;
            match[2] = p3;
            match[3] = p4;

            ImageBuilder.saveFile(mp, cbxBoard.SelectedIndex, match);
            updateSettings();
        }

        private void updateSettings()
        {
            config["game"] = mp;
            config["board"] = cbxBoard.SelectedIndex;

            config["p1p"] = p1.getPlayer();
            config["p1s"] = p1.getStars().ToString();
            config["p1c"] = p1.getCoins().ToString();

            config["p2p"] = p2.getPlayer();
            config["p2s"] = p2.getStars().ToString();
            config["p2c"] = p2.getCoins().ToString();

            config["p3p"] = p3.getPlayer();
            config["p3s"] = p3.getStars().ToString();
            config["p3c"] = p3.getCoins().ToString();

            config["p4p"] = p4.getPlayer();
            config["p4s"] = p4.getStars().ToString();
            config["p4c"] = p4.getCoins().ToString();

            config.Save();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace PartyFabricator64
{
    static class ImageBuilder
    {
        /*
         * Creates the results image.
         * 'mp' => The Mario Party game being replicated (1-3), used for file names.
         * 'board' => The index of the board combo box, used for file names.
         * 'p1' => The first player.
         * 'p2' => The second player.
         * 'p3' => The third player.
         * 'p4' => The fourth player.
         */
        public static Image makeResult(int mp, int board, Player p1, Player p2, Player p3, Player p4)
        {
            if (mp < 1 || mp > 3) mp = 1; //Sets the value of 'mp' to 1 in case it is invalid.

            if (board < 0 || board > 7) board = 0; //Sets the value of 'board' to 0 in case it is invalid.

            Image first; //Initializes player portraits first, as their appearance is universal across games.
            Image second;
            Image third;
            Image fourth;

            if (mp == 1) //Decides whether or not to use the Mario Party 1 exclusive winning / losing portraits.
            {
                first = Image.FromFile($@"assets/mp{mp}/characters/{p1.getPlayer()}w.png");
                second = Image.FromFile($@"assets/mp{mp}/characters/{p2.getPlayer()}n.png");
                third = Image.FromFile($@"assets/mp{mp}/characters/{p3.getPlayer()}n.png");
                fourth = Image.FromFile($@"assets/mp{mp}/characters/{p4.getPlayer()}l.png");
            }
            else
            {
                first = Image.FromFile($@"assets/mp{mp}/characters/{p1.getPlayer()}.png");
                second = Image.FromFile($@"assets/mp{mp}/characters/{p2.getPlayer()}.png");
                third = Image.FromFile($@"assets/mp{mp}/characters/{p3.getPlayer()}.png");
                fourth = Image.FromFile($@"assets/mp{mp}/characters/{p4.getPlayer()}.png");
            }

            Image result = new Bitmap(319, 237); //Initializes final results image.

            //IMAGE COMPOSITING FOR MARIO PARTY 1 AND 2
            if (mp == 1 || mp == 2) // These games have similar enough leaderboards to combine them into 1 section.
            {
                Image bg = Image.FromFile($@"assets/mp{mp}/boards/{board}.png");
                Image overlay = Image.FromFile($@"assets/mp{mp}/overlay.png");

                using (Graphics gr = Graphics.FromImage(result))
                {
                    gr.DrawImage(bg, 0, 0, bg.Width, bg.Height);
                    gr.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);

                    gr.DrawImage(first, 94, 53);
                    gr.DrawImage(second, 94, 93);
                    gr.DrawImage(third, 94, 133);
                    gr.DrawImage(fourth, 94, 173);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p1.getStars(), false)}.png"), 166, 65);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p1.getStars(), false)}.png"), 181, 65);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p2.getStars(), false)}.png"), 166, 105);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p2.getStars(), false)}.png"), 181, 105);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p3.getStars(), false)}.png"), 166, 145);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p3.getStars(), false)}.png"), 181, 145);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p4.getStars(), false)}.png"), 166, 185);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p4.getStars(), false)}.png"), 181, 185);


                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p1.getCoins(), false)}.png"), getCoinPos(0, p1.getCoins()), 65);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p1.getCoins(), false)}.png"), getCoinPos(1, p1.getCoins()), 65);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p1.getCoins(), false)}.png"), getCoinPos(2, p1.getCoins()), 65);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p2.getCoins(), false)}.png"), getCoinPos(0, p2.getCoins()), 105);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p2.getCoins(), false)}.png"), getCoinPos(1, p2.getCoins()), 105);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p2.getCoins(), false)}.png"), getCoinPos(2, p2.getCoins()), 105);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p3.getCoins(), false)}.png"), getCoinPos(0, p3.getCoins()), 145);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p3.getCoins(), false)}.png"), getCoinPos(1, p3.getCoins()), 145);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p3.getCoins(), false)}.png"), getCoinPos(2, p3.getCoins()), 145);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p4.getCoins(), false)}.png"), getCoinPos(0, p4.getCoins()), 185);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p4.getCoins(), false)}.png"), getCoinPos(1, p4.getCoins()), 185);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p4.getCoins(), false)}.png"), getCoinPos(2, p4.getCoins()), 185);
                }
            } else { //If the Mario Party game specified isn't 1 or 2...

                Image bg = Image.FromFile($@"assets/mp{mp}/background.png");
                Image overlay = Image.FromFile($@"assets/mp{mp}/boards/{board}.png");

                using (Graphics gr = Graphics.FromImage(result))
                {
                    gr.DrawImage(bg, 0, 0, bg.Width, bg.Height);
                    gr.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);

                    gr.DrawImage(first, 95, 53);
                    gr.DrawImage(second, 95, 93);
                    gr.DrawImage(third, 95, 133);
                    gr.DrawImage(fourth, 95, 173);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p1.getStars(), true)}.png"), 171, 64);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p1.getStars(), true)}.png"), 187, 64);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p2.getStars(), true)}.png"), 171, 104);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p2.getStars(), true)}.png"), 187, 104);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p3.getStars(), true)}.png"), 171, 144);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p3.getStars(), true)}.png"), 187, 144);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, p4.getStars(), true)}.png"), 171, 184);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, p4.getStars(), true)}.png"), 187, 184);


                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p1.getCoins(), true)}.png"), getCoinPos3(0, p1.getCoins()), 64);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p1.getCoins(), true)}.png"), getCoinPos3(1, p1.getCoins()), 64);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p1.getCoins(), true)}.png"), getCoinPos3(2, p1.getCoins()), 64);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p2.getCoins(), true)}.png"), getCoinPos3(0, p2.getCoins()), 104);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p2.getCoins(), true)}.png"), getCoinPos3(1, p2.getCoins()), 104);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p2.getCoins(), true)}.png"), getCoinPos3(2, p2.getCoins()), 104);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p3.getCoins(), true)}.png"), getCoinPos3(0, p3.getCoins()), 144);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p3.getCoins(), true)}.png"), getCoinPos3(1, p3.getCoins()), 144);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p3.getCoins(), true)}.png"), getCoinPos3(2, p3.getCoins()), 144);

                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(0, p4.getCoins(), true)}.png"), getCoinPos3(0, p4.getCoins()), 184);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(1, p4.getCoins(), true)}.png"), getCoinPos3(1, p4.getCoins()), 184);
                    gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(2, p4.getCoins(), true)}.png"), getCoinPos3(2, p4.getCoins()), 184);
                }
            }
            return result;
        }

        public static void saveFile(Image img)
        {
            img.Save(@"./results.png");
        }

        /*
         * Returns an integer to represent the appropriate x-coordinate for a character using its place value.
         * 'pl' => Place value, should be 0-2 and account for numbers 0-999.
         * 'amt' => Amount, should be the total number of coins the player has.
         */
        private static int getCoinPos(int pl, int amt)
        {
            if (pl == 0) return 242;
            if (pl == 1) return 257;

            if (amt < 10) return 265; //In cases the total amount is less than 10, the x-coordinate is slightly offset.
            else return 272;
        }

        /*
         * Does the same thing as getCoinPos() but is for MP3. I didn't account for the fact that it would work differently.
         */
        private static int getCoinPos3(int pl, int amt)
        {
            if (pl == 0) return 245;
            if (pl == 1) return 261;

            if (amt < 10) return 261;
            else return 277;
        }

        /*
         * Returns a string to represent the appropriate character given the amount of coins and the place value.
         * 'pl' => Place value, should be 0-2 and account for numbers 0-999.
         * 'amt' => Amount, should be the total number of coins the player has.
         */
        private static string getCoinChar(int pl, int amt, bool mp3)
        {
            string chara;

            if (amt < 0 || amt > 999) amt = 0; //Should never naturally occur, safety check to avoid errors.

            if (pl == 0)
            {
                if (Math.Truncate((Double)amt / 100) != 0) chara = Math.Truncate((Double)amt / 100).ToString();
                else {
                    if (mp3) chara = "xs";
                    else chara = "x";
                }
            }
            else if (pl == 1)
            {
                if (Math.Truncate(((Double)amt % 100) / 10) != 0) chara = Math.Truncate(((Double)amt % 100) / 10).ToString();
                else if (amt > 10) chara = "0";
                else chara = "tr"; //Represents a transparent character, used when less than 3 characters are appropriate.
            }
            else chara = (amt % 10).ToString();

            return chara;
        }

        /*
         *  Returns a string to represent the appropriate character given the amount of stars and the place value.
         *  'pl' => Place value, should be 0-1 and account for numbers 0-99.
         *  'amt' => Amount, should be the total number of stars the player has.
         */
        private static string getStarChar(int pl, int amt, bool mp3)
        {
            string chara;

            if (amt < 0 || amt > 99) amt = 0; //Should never naturally occur, safety check to avoid errors.

            if (pl == 0)
            {
                if (Math.Truncate((Double)amt / 10) != 0) chara = Math.Truncate((Double)amt / 10).ToString();
                else {
                    if (mp3) chara = "xs";
                    else chara = "x";
                }
            }
            else if (pl == 1)
            {
                if (Math.Truncate((Double)amt % 10) != 0) chara = Math.Truncate((Double)amt % 10).ToString();
                else chara = "0";
            }
            else chara = "0";

            return chara; 
        }
    }
}

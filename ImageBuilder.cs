using System;
using System.Drawing;

namespace PartyFabricator64
{
    static class ImageBuilder
    {
        public static Image makeResult(int mp, int board, Player[] match)
        {

            //Universal canvas.
            Image result = new Bitmap(319, 237);
            Graphics gr = Graphics.FromImage(result);

            Image bg;
            Image overlay;

            /*
             * Determines which Mario Party game the leaderboard is taken from.
             */
            switch (mp)
            {
                //Mario Party 1 & 2
                case 1:
                case 2:

                    bg = Image.FromFile($@"assets/mp{mp}/boards/{board}.png");
                    overlay = Image.FromFile($@"assets/mp{mp}/overlay.png");

                    gr.DrawImage(bg, 0, 0, bg.Width, bg.Height);
                    gr.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);

                    /*
                     * Compositing for each player in the match, player number indicated by i.
                     */
                    for (int i = 0; i < match.Length; i++)
                    {
                        Image portrait;

                        // Unique Mario Party 1 win and loss portraits.
                        if (mp == 1)
                        {
                            switch (i)
                            {
                                case 0:
                                    portrait = Image.FromFile($@"assets/mp{mp}/characters/{match[i].getPlayer()}w.png");
                                    break;
                                case 3:
                                    portrait = Image.FromFile($@"assets/mp{mp}/characters/{match[i].getPlayer()}l.png");
                                    break;
                                default:
                                    portrait = Image.FromFile($@"assets/mp{mp}/characters/{match[i].getPlayer()}n.png");
                                    break;
                            }
                        } else {
                            portrait = Image.FromFile($@"assets/mp{mp}/characters/{match[i].getPlayer()}.png");
                        }

                        //Draws player portrait
                        gr.DrawImage(portrait, 94, 53 + (i * 40), portrait.Width, portrait.Height);

                        //Draws star count
                        gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, match[i].getStars(), false)}.png"), 166, 65 + (i * 40));
                        gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, match[i].getStars(), false)}.png"), 182, 65 + (i * 40));

                        //Draws coin count
                        for(int j = 0; j < 3; j++)
                            gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(j, match[i].getCoins(), false)}.png"), getCoinPos(j, match[i].getCoins()), 65 + (i * 40));
                    }

                    //Draws first and second place numbers
                    gr.DrawImage(Image.FromFile($@"assets/type/1p.png"), 30, 57);
                    gr.DrawImage(Image.FromFile($@"assets/type/2p.png"), 30, 97);


                    //Determines if there is a tie for second place (between 2nd and 3rd)
                    if (match[2].getStars() == match[1].getStars() && match[2].getCoins() == match[1].getCoins())
                    {
                        gr.DrawImage(Image.FromFile($@"assets/type/2p.png"), 30, 137);
                        //Determines if that tie is also shared for fourth place
                        if (match[3].getStars() == match[2].getStars() && match[3].getCoins() == match[2].getCoins()) gr.DrawImage(Image.FromFile($@"assets/type/2p.png"), 30, 177);
                        else gr.DrawImage(Image.FromFile($@"assets/type/4p.png"), 30, 177);
                    } else {

                        //Composites 3rd place image
                        gr.DrawImage(Image.FromFile($@"assets/type/3p.png"), 30, 137);

                        //Determines if third place is last
                        if(match[3].getStars() == match[2].getStars() && match[3].getCoins() == match[2].getCoins()) gr.DrawImage(Image.FromFile($@"assets/type/3p.png"), 30, 177);
                        else gr.DrawImage(Image.FromFile($@"assets/type/4p.png"), 30, 177);

                    }

                    return result;

                /*
                 * Mario Party 3 leaderboard code.
                 */
                case 3:

                    bg = Image.FromFile($@"assets/mp{mp}/background.png");
                    overlay = Image.FromFile($@"assets/mp{mp}/boards/{board}.png");

                    gr.DrawImage(bg, 0, 0, bg.Width, bg.Height);
                    gr.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);

                    for (int i = 0; i < match.Length; i++)
                    {
                        //Draws player portrait
                        gr.DrawImage(Image.FromFile($@"assets/mp{mp}/characters/{match[i].getPlayer()}.png"), 95, 53 + (i * 40));

                        //Draws star count
                        gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(0, match[i].getStars(), true)}.png"), 171, 64 + (i * 40));
                        gr.DrawImage(Image.FromFile($@"assets/type/{getStarChar(1, match[i].getStars(), true)}.png"), 187, 64 + (i * 40));

                        //Draws coin count
                        for (int j = 0; j < 3; j++)
                            gr.DrawImage(Image.FromFile($@"assets/type/{getCoinChar(j, match[i].getCoins(), true)}.png"), getCoinPos3(j, match[i].getCoins()), 64 + (i * 40));
                    }

                    return result;

                default:
                    throw new Exception("Mario Party game is not 1, 2, or 3. Something is horribly wrong.");
            }
        }

        public static void saveFile(int mp, int board, Player[] match)
        {
            makeResult(mp, board, match).Save(@"./results.png");
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
                else
                {
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
                else
                {
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

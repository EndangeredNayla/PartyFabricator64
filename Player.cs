namespace PartyFabricator64
{
    class Player
    {
        int p = 0;
        int s = 0;
        int c = 0;

        public Player(int character)
        {
            setPlayer(character, false);
        }

        public int getPlayer()
        {
            return p;
        }

        public void setPlayer(int character, bool mp3)
        {
            if (mp3 && character < 8 && character > -1) p = character;
            else if (!mp3 && character < 6 && character > -1) p = character;
            else p = 0;

        }

        public int getStars()
        {
            return s;
        }

        public void setStars(int stars)
        {
            if (stars > -1 && stars < 100) s = stars;
            else s = 0;
        }

        public int getCoins()
        {
            return c;
        }

        public void setCoins(int coins)
        {
            if (coins > -1 && coins < 1000) c = coins;
            else c = 0;
        }
    }
}

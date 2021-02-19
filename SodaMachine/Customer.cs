using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //Member Variables (Has A)
        public Wallet Wallet;
        public Backpack Backpack;

        //Constructor (Spawner)
        public Customer()
        {
            Wallet = new Wallet();
            Backpack = new Backpack();
        }
        //Member Methods (Can Do)

        //This method will be the main logic for a customer to retrieve coins form their wallet.
        //Takes in the selected can for price reference
        //Will need to get user input for coins they would like to add.
        //When all is said and done this method will return a list of coin objects that the customer will use a payment for their soda.
        public List<Coin> GatherCoinsFromWallet(Can selectedCan)
        {
            List<Coin> coins = new List<Coin>();
            while (true)
            {
                string validSelection = UserInterface.CoinSelection(selectedCan, Wallet.Coins);
                if (validSelection == "done")
                {
                    return coins;
                }
                Coin coinName = GetCoinFromWallet(validSelection);
                coins.Add(coinName);
                
            }

           
        }
        //Returns a coin object from the wallet based on the name passed into it.
        //Returns null if no coin can be found
        public Coin GetCoinFromWallet(string coinName)
        {
            foreach (Coin coin in Wallet.Coins)
            {
                if (coin.Name == coinName)
                {
                    Wallet.Coins.Remove(coin);
                    return coin;
                }

            }
            return null;
        }
        //Takes in a list of coin objects to add into the customers wallet.
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickel = new Nickel();
            Penny penny = new Penny();

            for (int i = 0; i < 10; i++)
            {
                Wallet.Coins.Add(quarter);
            }
            for (int i = 0; i < 23; i++)
            {
                Wallet.Coins.Add(dime);
            }
            for (int i = 0; i < 172; i++)
            {
                Wallet.Coins.Add(nickel);
            }
            for (int i = 0; i < 19; i++)
            {
                Wallet.Coins.Add(penny);
            }
        }
        //Takes in a can object to add to the customers backpack.
        public void AddCanToBackpack(Can purchasedCan)
        {
            Backpack.cans.Add(purchasedCan);
        }
    }
}

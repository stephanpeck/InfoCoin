using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using EllipticCurve;

namespace InfoCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            PrivateKey key1 = new PrivateKey();
            PublicKey wallet1 = key1.publicKey();

            PrivateKey key2 = new PrivateKey();
            PublicKey wallet2 = key2.publicKey();
            
            //parameters are difficulty and reward for mining
            Blockchain infocoin = new Blockchain(3, 100);


            Console.WriteLine("Start the Miner.");
            infocoin.MinePendingTransactions(wallet1);
            Console.WriteLine("\n Balance of wallet1 is $:" + infocoin.GetBalanceOfWallet(wallet1).ToString());




            //OLD Leftover
            //infocoin.AddBlock(new Block(1, DateTime.Now.ToString("yyyyMMddHHmmssffff"), "amount: 50"));
            //infocoin.AddBlock(new Block(2, DateTime.Now.ToString("yyyyMMddHHmmssffff"), "amount: 200"));



            Transaction tx1 = new Transaction(wallet1, wallet2, 10);
            tx1.SignTransaction(key1);
            infocoin.addPendingTransaction(tx1);
            Console.WriteLine("Start the Miner.");
            infocoin.MinePendingTransactions(wallet2);
            Console.WriteLine("\n Balance of wallet1 is $:" + infocoin.GetBalanceOfWallet(wallet1).ToString());
            Console.WriteLine("\n Balance of wallet2 is $:" + infocoin.GetBalanceOfWallet(wallet2).ToString());



            string blockJSON = JsonConvert.SerializeObject(infocoin, Formatting.Indented);

            Console.WriteLine(blockJSON);


            //infocoin.GetLatestBlock().PreviousHash = "12345";


            if (infocoin.IsChainValid())
            {
                Console.WriteLine("Blockchain is Valid!");
            }
            else
            {
                Console.WriteLine("Blockchain is NOT Valid!");
            }

        }
    }

    

    
}

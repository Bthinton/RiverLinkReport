using FileHelpers;
using RiverLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLink.FileWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var engine1 = new FileHelperEngine<Transaction>();
            engine1.HeaderText = engine1.GetFileHeader();

            List<Transaction> Transaction = new List<Transaction>();

            engine1.WriteFile("Transactions.Txt", Transaction);


            var engine2 = new FileHelperEngine<Vehicle>();
            engine2.HeaderText = engine2.GetFileHeader();

            List<Vehicle> Vehicle = new List<Vehicle>();

            engine2.WriteFile("Vehicles.Txt", Vehicle);


            var engine3 = new FileHelperEngine<Transponder>();
            engine3.HeaderText = engine3.GetFileHeader();

            List<Transponder> Transponder = new List<Transponder>();

            engine3.WriteFile("Transponders.Txt", Transponder);        
        }
    }
}
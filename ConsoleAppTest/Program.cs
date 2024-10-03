using SimulateurRobotJouet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exemple d'utilisation avec des commandes en dur

            string[] commandes = {

"PLACE 0,0,NORD",

"DÉPLACER",

"RAPPORT"

};

            var traitementCommande = new TraitementCommande();

            traitementCommande.TraiterCommandes(commandes);
        }
    }
}

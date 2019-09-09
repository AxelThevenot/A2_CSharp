using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Bef_TD5
{
    class Program
    {
        static void Main(string[] args)
        {

            CompteBancaire compte1 = new CompteBancaire("test", 123);
            CompteBancaire compte2 = new CompteBancaire("coucou", 15520);
            CompteBancaire compte3 = new CompteBancaire("hello", 1286533);

            Console.WriteLine(compte1.ToString());
            Console.WriteLine("Après trois tentives de retirer plus que nécessaire,");
            compte1.Debiter(300000);
            compte1.Debiter(3000000);
            compte1.Debiter(3000000);
            Console.WriteLine(compte1.ToString());
            Console.WriteLine("Après avoir recrédité :");
            compte1.Crediter(1800000);
            Console.WriteLine(compte1.ToString());
            Console.WriteLine("nombre de client bloqué(s) : " + CompteBancaire.NombreClientBloque() + " sur " + CompteBancaire.NombreClient());
            compte2.Debiter(300000); compte2.Debiter(300000); compte2.Debiter(300000); compte2.Debiter(300000);
            compte1.Debiter(300000); compte1.Debiter(300000); compte1.Debiter(300000);
            Console.WriteLine("nombre de client bloqué(s) : " + CompteBancaire.NombreClientBloque() + " sur " + CompteBancaire.NombreClient());


            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD3
{
    class Program
    {
        /// <summary>
        /// Initialise un tableau selon une taille des des valeurs maximum et minimum
        /// </summary>
        /// <param name="taille"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        static int[] InitialiserTableau(int taille, int minimum, int maximum)
        {
            Random random = new Random();
            int[] tableau = new int[taille];
            for (int i = 0; i < tableau.Length; i++)
            {
                tableau[i] = random.Next(minimum, maximum + 1);
            }
            return tableau;
        }
        /// <summary>
        /// Afficher un tableau
        /// </summary>
        /// <param name="tableau"></param>
        static void AfficherTableau(int[] tableau)
        {
            if (tableau != null)
            {
                Console.Write("| ");
                for (int i = 0; i < tableau.Length; i++)
                {
                    Console.Write(tableau[i] + " | ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Tri par sélection
        /// </summary>
        static void Exercice1()
        {
            //On demande à l'utilisateur de rentrer les propriétés du tableau qu'il souhaite
            int taille = -1;
            while (taille < 1)
            {
                Console.WriteLine("Choisir une taille strictement positive de tableau à trier par sélection");
                taille = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum et le maximum pour remplir le tableau aléatoirement");
            Console.WriteLine("minimum :");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("maximum :");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[] tableau = InitialiserTableau(taille, minimum, maximum);

            //On lance l'Exercice
            Console.Clear();
            Console.WriteLine("Tableau non trié : ");
            AfficherTableau(tableau);
            Console.WriteLine("Tableau trié :");
            TriParSelection(tableau);
            AfficherTableau(tableau);
        }
        /// <summary>
        /// Permute 2 valeurs dans un tableau
        /// </summary>
        /// <param name="tableau"></param>
        /// <param name="no1"></param>
        /// <param name="no2"></param>
        static void Permuter(int[] tableau, int no1, int no2)
        {
            int z = tableau[no1];
            tableau[no1] = tableau[no2];
            tableau[no2] = z;
        }
        /// <summary>
        /// Effectue un tri par sélection dans un tableau
        /// </summary>
        /// <param name="tableau"></param>
        static void TriParSelection(int[] tableau)
        {  /* Inefficace : temps quadratique
            * Sur place ; instable
            * Complexité :  - Pire des cas = O(n²)
            *               - Moyenne = O(n²)
            *               - Meilleur des cas = O(n²) 
            * Utilité : Aucune */

            if (tableau != null)
            {
                int max = 0;
                int i = 0;
                int longueur = tableau.Length;

                while (longueur > 0)
                {
                    max = 0;

                    //Sélection du maximum parmis les valeurs non triées
                    for (i = 1; i < longueur; i++)
                    {
                        if (tableau[i] > tableau[max]) max = i;
                    }

                    //On le mets en dernière position parmis les valeurs comparées
                    //Cette position sera définitive car triée
                    Permuter(tableau, max, (longueur - 1));

                    //On recommence jusqu'à finir le tri du tableau
                    longueur--;
                }
            }
        }

        /// <summary>
        /// Tri par insertion
        /// </summary>
        static void Exercice2()
        {
            //On demande à l'utilisateur de rentrer les propriétés du tableau qu'il souhaite
            int taille = -1;
            while (taille < 1)
            {
                Console.WriteLine("Choisir une taille strictement positive de tableau à trier par insertion");
                taille = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum et le maximum pour remplir le tableau aléatoirement");
            Console.WriteLine("minimum :");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("maximum :");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[] tableau = InitialiserTableau(taille, minimum, maximum);

            //On lance l'Exercice
            Console.Clear();
            Console.WriteLine("Tableau non trié : ");
            AfficherTableau(tableau);
            Console.WriteLine("Tableau trié :");
            TriParInsertion(tableau);
            AfficherTableau(tableau);
        }
        /// <summary>
        /// Effectue le tri par insertion dans un tableau
        /// </summary>
        /// <param name="tableau"></param>
        static void TriParInsertion(int[] tableau)
        {  /* Sur place ; stable
            * Complexité :  - Pire des cas = O(n²)
            *               - Moyenne = O(n²)
            *               - Meilleur des cas = O(n) 
            * Utilité : Pédagogique*/

            if (tableau != null)
            {
                int k = 0;
                for (int i = 1; i < tableau.Length; i++)
                {
                    k = i;
                    // On compare la valeur k à sa voisine inférieure...
                    while (k > 0 && tableau[k] < tableau[k - 1])
                    {
                        // ...On permute si elle est inférieure...
                        Permuter(tableau, k, k - 1);
                        // ... Jusqu'à tomber sur une valeur supérieure
                        k--;
                    }
                    // On recommence l'opération en se déplacant le long du tableau 
                }
            }
        }


        /// <summary>
        /// Tri fusion
        /// </summary>
        static void Exercice3()
        {
            //On demande à l'utilisateur de rentrer les propriétés du tableau qu'il souhaite
            int taille = -1;
            while (taille < 1)
            {
                Console.WriteLine("Choisir une taille strictement positive de tableau à trier par fusion");
                taille = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum et le maximum pour remplir le tableau aléatoirement");
            Console.WriteLine("minimum :");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("maximum :");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[] tableau = InitialiserTableau(taille, minimum, maximum);

            // On lance l'Exercice
            Console.Clear();
            Console.WriteLine("Tableau non trié : ");
            AfficherTableau(tableau);
            Console.WriteLine("Tableau trié :");
            TriFusion(tableau, 0, tableau.Length - 1);
            AfficherTableau(tableau);
        }
        /// <summary>
        /// fusionne deux tableaux
        /// </summary>
        /// <param name="tableau"></param>
        /// <param name="début"></param>
        /// <param name="fin"></param>
        /// <param name="milieu"></param>
        static void Fusion(int[] tableau, int début, int fin, int milieu)
        {
            {
                int[] bancDeTouche = (int[])tableau.Clone();
                int index1 = début; //indice dans la première moitié du bancDeTouche
                int index2 = milieu + 1; // indice dans la deuxième moitié du bancDeTouche
                int casesTriees = début; //indice dans le tableau

                while (index1 <= milieu && index2 <= fin)
                {
                    //quelle est la plus petite tête de liste?
                    if (bancDeTouche[index1] <= bancDeTouche[index2])
                    {
                        tableau[casesTriees] = bancDeTouche[index1];
                        index1++;
                    }
                    else
                    {
                        tableau[casesTriees] = bancDeTouche[index2];
                        index2++;
                    }
                    casesTriees++;
                }
                if (casesTriees <= fin)
                {
                    while (index1 <= milieu)  // le reste de la première moitié s'il y a 
                    {
                        tableau[casesTriees] = bancDeTouche[index1];
                        index1++;
                        casesTriees++;
                    }
                    while (index2 <= fin) // le reste de la deuxième moitié s'il y a 
                    {
                        tableau[casesTriees] = bancDeTouche[index2];
                        index2++;
                        casesTriees++;
                    }
                }
            }
        }
        /// <summary>
        /// Effectue le tri fusion
        /// </summary>
        /// <param name="tableau"></param>
        /// <param name="début"></param>
        /// <param name="fin"></param>
        static void TriFusion(int[] tableau, int début, int fin)
        {
            if (tableau != null)
            {
                int[] bancDeTouche = new int[tableau.Length];//On utilise un banc de touche pour manipuler et trier le tableau 
                int milieu = (début + fin) / 2;
                if (fin - début > 1)//#DiviserPourMieuxRegner tkt même pas frère !
                {
                    TriFusion(tableau, début, milieu);
                    TriFusion(tableau, milieu + 1, fin);
                }
                Fusion(tableau, début, fin, milieu);//Puis on fusionne
            }
        }

        /// <summary>
        /// Simple menu comme dans chaque TD
        /// </summary>
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu : Tapez un numéro pour choisir l'Exercice désiré\n");
            Console.WriteLine("Exercice 1 : Tri par sélection");
            Console.WriteLine("Exercice 2 : Tri par insertion");
            Console.WriteLine("Exercice 3 : Tri fusion\n");
            Console.WriteLine("Echap pour quitter");

            bool quitter = false;
            while (!quitter)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Exercice1();
                }
                if (cki.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Exercice2();
                }
                if (cki.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Exercice3();
                }
                if (cki.Key == ConsoleKey.Escape)
                {
                    quitter = true;
                }
            }
        }


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int[] tableau = InitialiserTableau(40, 0, 9);
            for (;;)
            {
                tableau = InitialiserTableau(52, 0, 9);
                AfficherTableau(tableau);
                TriFusion(tableau, 0, tableau.Length - 1);
                AfficherTableau(tableau);
                /*for (int i = 0; i < 10000000; i += 2)
                {
                    i--;
                }*/
            }


            /*bool quitter = false;
            while (!quitter)
            {
                Menu();
                Console.WriteLine("\n\nEchap pour quitter");
                Console.WriteLine("Enter pour revenir au menu");
                ConsoleKeyInfo cki = Console.ReadKey();
                while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.Enter)
                {
                    cki = Console.ReadKey();
                }
                if (cki.Key == ConsoleKey.Escape)
                {
                    quitter = true;
                }
            }*/
        }
    }
}

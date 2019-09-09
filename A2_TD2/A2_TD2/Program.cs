using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD2
{
    class Program
    {
        /// <summary>
        /// Créer un tableau avec les nombres entiers strictement positifs et pairs
        /// </summary>
        private static void Exercice1()
        {
            int nombre = -1;
            while (nombre < 1)
            {
                Console.WriteLine("Choisir une dimension de tableau strictement positive");
                nombre = Convert.ToInt32(Console.ReadLine());
            }
            AfficherTableau(IntilialiserTableauPair(nombre));
        }
        /// <summary>
        /// Initialise un tableau avec les nombres entiers strictement positifs et pairs
        /// </summary>
        private static int[] IntilialiserTableauPair(int nombre)
        {
            int[] tableau = null;
            if (nombre > 0)
            {
                tableau = new int[nombre];
                for (int i = 0; i < nombre; i++)
                {
                    tableau[i] = (i + 1) * 2;
                }
            }
            return tableau;
        }
        /// <summary>
        /// Affiche un tableau d'entiers
        /// </summary>
        /// <param name="tableau"></param>
        /// 
        private static void AfficherTableau(int[] tableau)
        {
            if (tableau != null)
            {
                for (int i = 0; i < tableau.Length; i++)
                {
                    Console.Write("| " + tableau[i] + " ");
                }
                Console.WriteLine("|");
            }
        }


        /// <summary>
        /// Ajouter deux matrices
        /// </summary>
        static void Exercice2()
        {

            // Demande initialisation matrice n° 1

            int nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice n° 1");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            int nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice n° 1");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice1 = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);

            // Demande initialisation matrice n° 2

            nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice n° 2");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice n° 2");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice2 = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);
            AfficherMatrice(matrice1);
            Console.WriteLine();
            AfficherMatrice(matrice2);
            Console.WriteLine();
            AfficherMatrice(AdditionneurMatrices(matrice1, matrice2));
            Console.WriteLine();
        }
        /// <summary>
        /// Affiche une matrice
        /// </summary>
        /// <param name="matrice"></param>
        static void AfficherMatrice(int[,] matrice)
        {
            if (matrice == null)
            {
                Console.WriteLine("Matrice null");
            }
            else
            {
                if (matrice.GetLength(0) == 0 && matrice.GetLength(1) == 0)
                {
                    Console.WriteLine("La matrice est vide");
                }
                else
                {
                    int maximum = 0;
                    int minimum = 32767;
                    int indexEspaceMax = 0;
                    int indexEspaceMin = 0;
                    for (int i = 0; i < matrice.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrice.GetLength(1); j++)
                        {
                            if (matrice[i, j] > maximum)
                            {
                                maximum = matrice[i, j];
                            }
                            if (matrice[i, j] < minimum)
                            {
                                minimum = matrice[i, j];
                            }
                        }
                    }
                    for (int i = 0; i < matrice.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrice.GetLength(1); j++)
                        {
                            while (maximum > 9)
                            {
                                maximum = maximum / 10;
                                indexEspaceMax++;
                            }
                            while (maximum > 9)
                            {
                                minimum = minimum / 10;
                                indexEspaceMin++;
                            }
                        }
                    }
                    for (int i = 0; i < (indexEspaceMax - indexEspaceMin + 4) * matrice.GetLength(1) + 1; i++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                    for (int i = 0; i < matrice.GetLength(0); i++)
                    {
                        Console.Write("| ");
                        for (int j = 0; j < matrice.GetLength(1); j++)
                        {
                            int nombreEspace = indexEspaceMax - indexEspaceMin;
                            int z = matrice[i, j];
                            while (z > 9)
                            {
                                z = z / 10;
                                nombreEspace--;
                            }
                            for (int k = 0; k < nombreEspace; k++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write(matrice[i, j] + " | ");
                        }
                        Console.Write("\n");
                    }
                    for (int i = 0; i < (indexEspaceMax - indexEspaceMin + 4) * matrice.GetLength(1) + 1; i++)
                    {
                        Console.Write("-");
                    }
                }
            }
        }
        /// <summary>
        /// Créer une matrice strictement avec des nombres aléatoire entre le minimum et le maximum inclus
        /// </summary>
        /// <param name="nombreLignes"></param>
        /// <param name="nombreColonnes"></param>
        /// <returns></returns>
        static int[,] CreerMatrice(int nombreLignes, int nombreColonnes, int minimum, int maximum)
        {
            Random random = new Random();
            int[,] matrice = new int[nombreLignes, nombreColonnes];
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    matrice[i, j] = random.Next(minimum, maximum + 1);
                }
            }
            return matrice;
        }
        /// <summary>
        /// Additione deux matrices
        /// </summary>
        /// <param name="matrice1"></param>
        /// <param name="matrice2"></param>
        /// <returns></returns>
        static int[,] AdditionneurMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] addition = null;
            if (matrice1 == null && matrice2 == null)
            {

            }
            else
            {
                if (matrice1.GetLength(0) == 0 && matrice1.GetLength(1) == 0 && matrice2.GetLength(0) == 0 && matrice2.GetLength(1) == 0)
                {
                    addition = new int[0, 0];
                }
                else
                {
                    if (matrice1.GetLength(0) != matrice2.GetLength(0) || matrice1.GetLength(1) != matrice2.GetLength(1))
                    {
                        Console.WriteLine("Les matrices ne sont pas compatibles pour une addition matricielle");
                    }
                    else
                    {
                        addition = new int[matrice1.GetLength(0), matrice1.GetLength(1)];
                        for (int i = 0; i < matrice1.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrice1.GetLength(1); j++)
                            {
                                addition[i, j] = matrice1[i, j] + matrice2[i, j];
                            }
                        }
                    }
                }
            }
            return addition;
        }

        /// <summary>
        /// Multiplication d'une matrice avec un vecteur
        /// </summary>
        static void Exercice3()
        {
            // Demande initialisation matrice 

            int nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            int nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);

            // Demande initialisation vecteur

            nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour le tableau n° 1");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            maximum = Convert.ToInt32(Console.ReadLine());
            int[] vecteur = IntilialiserTableauPair(nombreLignes);
            AfficherTableau(AjoutMatriceVecteur(matrice, vecteur));
        }
        /// <summary>
        /// Multiplication Matrice Vecteur
        /// </summary>
        /// <param name="matrice"></param>
        /// <param name="vecteur"></param>
        /// <returns></returns>
        static int[] AjoutMatriceVecteur(int[,] matrice, int[] vecteur)
        {
            int[] ajout = null;
            if (vecteur != null && matrice != null)
            {
                if (matrice.GetLength(1) == vecteur.Length)
                {
                    ajout = new int[matrice.GetLength(0)];
                    {
                        for (int i = 0; i < matrice.GetLength(0); i++)
                        {
                            ajout[i] = 0;
                            for (int j = 0; j < matrice.GetLength(1); j++)
                            {
                                ajout[i] += matrice[i, j] + vecteur[j];
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("La matrice et le vecteur ne sont pas compatibles");
                }
            }
            else
            {
                Console.WriteLine("Matrice ou vecteur null");
            }
            return ajout;
        }

        /// <summary>
        /// Multiplication de deux matrices
        /// </summary>
        static void Exercice4()
        {
            // Demande initialisation matrice n° 1

            int nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice n° 1");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            int nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice n° 1");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice1 = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);

            // Demande initialisation matrice n° 2

            nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice n° 2");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice n° 2");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice2 = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);
            AfficherMatrice(matrice1);
            Console.WriteLine();
            AfficherMatrice(matrice2);
            Console.WriteLine();
            AfficherMatrice(AdditionneurMatrices(matrice1, matrice2));
            Console.WriteLine();
        }
        /// <summary>
        /// Renvoie le produit de deux matrices
        /// </summary>
        /// <param name="matrice1"></param>
        /// <param name="matrice2"></param>
        /// <returns></returns>
        static int[,] MultiplieurMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] multiple = null;
            if (matrice1 == null || matrice2 == null)
            {
                Console.WriteLine("les matrices sont null");
            }
            else
            {
                if (matrice1.GetLength(1) != matrice2.GetLength(0))
                {
                    Console.WriteLine("Les matrices ne sont pas compatibles pour une multiplication matricielle");
                }
                else
                {
                    int somme = 0;
                    multiple = new int[matrice1.GetLength(0), matrice2.GetLength(1)];
                    for (int i = 0; i < matrice1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrice2.GetLength(1); j++)
                        {
                            somme = 0;
                            for (int k = 0; k < matrice1.GetLength(1); k++)
                            {
                                somme += matrice1[i, k] * matrice2[k, j];
                            }
                            multiple[i, j] = somme;
                        }
                    }
                }
            }

            return multiple;
        }


        /// <summary>
        /// Carré magique
        /// </summary>
        static void Exercice5()
        {
            // Demande initialisation matrice

            int nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            int nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice1 = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);
            if (CarréMagique(matrice1))
            {
                Console.WriteLine("C'est un carré magique");
            }
            else
            {
                Console.WriteLine("Ce n'est pas un carré magique");
            }
        }
        /// <summary>
        /// Teste Carré magique
        /// </summary>
        /// <param name="args"></param>
        static bool CarréMagique(int[,] matrice)
        {
            bool magique = false;
            if (matrice != null)
            {
                magique = true;
                int somme = 0;
                int test = 0;
                for (int i = 0; i < matrice.GetLength(0); i++)
                {
                    somme += matrice[i, 0];
                }
                for (int i = 1; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        test += matrice[i, j];
                    }
                    if (test != somme)
                    {
                        magique = false;
                    }
                    test = 0;
                }
                somme = 0;
                for (int i = 1; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        test += matrice[j, i];
                    }
                    if (test != somme)
                    {
                        magique = false;
                    }
                }
            }
            return magique;
        }

        /// <summary>
        /// Point Col
        /// </summary>
        static void Exercice6()
        {
            // Demande initialisation matrice

            int nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            int nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            PointCol(CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum));
        }
        /// <summary>
        /// Recherche les points cols d'une matrice carré
        /// </summary>
        /// <param name="args"></param>
        static void PointCol(int[,] matrice)
        {
            if (matrice != null && matrice.GetLength(0) == matrice.GetLength(1))
            {
                int minLigne = 0;
                bool max = true;
                for (int i = 0; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        if (matrice[i, minLigne] > matrice[i, j])
                        {
                            j = minLigne;
                        }
                        max = true;
                        for (int k = 0; k < matrice.GetLength(0); k++)
                        {
                            if (matrice[k, minLigne] < matrice[i, minLigne])
                            {
                                max = false;
                            }
                        }
                        if (max)
                        {
                            Console.WriteLine("Point col = " + matrice[i, minLigne] + " en [" + i + " ," + j + " ]");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Pas de point col");
            }
        }

        /// <summary>
        /// Décalage Matrice
        /// </summary>
        static void Exercice7()
        {
            // Demande initialisation matrice

            int nombreLignes = -1;
            while (nombreLignes < 1)
            {
                Console.WriteLine("Choisir un nombre de ligne strictement positif pour la matrice");
                nombreLignes = Convert.ToInt32(Console.ReadLine());
            }
            int nombreColonnes = -1;
            while (nombreColonnes < 1)
            {
                Console.WriteLine("Choisir un nombre de colonne strictement positif pour la matrice");
                nombreColonnes = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice1 = CreerMatrice(nombreLignes, nombreColonnes, minimum, maximum);
            AfficherMatrice(matrice1);
            AfficherMatrice(DecaleNombreElements(matrice1, 1));
        }

        /// <summary>
        /// renvoie la matrice avec un décalage
        /// </summary>
        /// <param name="matrice"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        static int[,] DecaleNombreElements(int[,] matrice, int nombre)
        {
            if (matrice != null)
            {
                int stock = 0;
                {
                    for (int count = 0; count < nombre % matrice.Length; count++)
                    {
                        stock = matrice[0, 0];
                        for (int i = 0; i < matrice.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrice.GetLength(1); j++)
                            {
                                if (j != matrice.GetLength(1) - 1)
                                {
                                    matrice[i, j] = matrice[i, j + 1];
                                }
                                else
                                {
                                    matrice[i, j] = matrice[(i + 1) % matrice.GetLength(0), 0];
                                }
                            }
                        }
                        matrice[matrice.GetLength(0) - 1, matrice.GetLength(1) - 1] = stock;
                    }
                }
            }
            return matrice;
        }


        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu : Tapez un numéro pour choisir l'Exercice désiré\n");
            Console.WriteLine("Exercice 1 : Créer un tableau avec les nombres entiers strictement positifs et pairs");
            Console.WriteLine("Exercice 2 : Ajouter deux matrices");
            Console.WriteLine("Exercice 3 : produit matrice vecteur");
            Console.WriteLine("Exercice 4 : Produit de deux matrices");
            Console.WriteLine("Exercice 5 : Carré magique");
            Console.WriteLine("Exercice 6 : Point Col");
            Console.WriteLine("Exercice 7 : Décalage valeurs d'une matrice\n");
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
                if (cki.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Exercice4();
                }
                if (cki.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    Exercice5();
                }
                if (cki.Key == ConsoleKey.NumPad6)
                {
                    Console.Clear();
                    Exercice6();
                }
                if (cki.Key == ConsoleKey.NumPad7)
                {
                    Console.Clear();
                    Exercice7();
                }
                if (cki.Key == ConsoleKey.Escape)
                {
                    quitter = true;
                }
            }
        }
        

        static void Main(string[] args)
        {
            bool quitter = false;
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
            }
        }
    }
}

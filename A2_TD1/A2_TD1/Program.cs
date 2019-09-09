using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD1
{
    public class TD1
    {

        public static double SqRoot(int nombre)
        {
            double sqrt = Math.Sqrt(nombre);
            return sqrt;
        }
        /// <summary>
        /// Exercice 1 : Dessiner une matrice ou une diagonale
        /// </summary>
        static void Exercice1()
        {
            Console.WriteLine("Vous avez sélectionné l'Exercice 1 : Dessiner une Matrice ou une Diagonale");
            Console.WriteLine("Entrez \"M\" pour dessiner une matrice");
            Console.WriteLine("Entrez \"D\" pour dessiner une Diagonale");
            char choix = 'X';
            char symbole = 'X';
            int dimension = -1;
            while (choix != 'M' && choix != 'D')
            {
                choix = Convert.ToChar(Console.ReadLine());
            }
            if (choix == 'M')
            {
                Console.WriteLine("Choisir un caractère :");
                symbole = Convert.ToChar(Console.ReadLine());
                while (dimension <= 0)
                {
                    Console.WriteLine("Choisir une dimension de matrice strictement positive");
                    dimension = Convert.ToInt32(Console.ReadLine());
                }
                DessineMoiUneMatrice(symbole, dimension);
            }
            else
            {
                char direction = 'X';
                Console.WriteLine("Choisir un caractère :");
                symbole = Convert.ToChar(Console.ReadLine());
                while (dimension < 1)
                {
                    Console.WriteLine("Choisir une dimension de matrice strictement positive");
                    dimension = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Choisir \"D\" pour dessiner une diagonale descendante et \"M\" pour une diagonale montante");
                while (direction != 'M' && direction != 'D')
                {
                    direction = Convert.ToChar(Console.ReadLine());
                }
                DessineMoiUneDiagonale(symbole, dimension, direction);
            }
            Console.WriteLine("Echap pour quitter l'Exercice");

        }

        /// <summary>
        /// Dessine une un matrice selon une dimension et un unique symbole
        /// </summary>
        /// <param name="symbole"></param>
        /// <param name="dimension"></param>
        static void DessineMoiUneMatrice(char symbole, int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(symbole);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Dessine une un matrice selon une dimension composée avec des "X" et selon un symbole choisi 
        /// sur une diagonale selon une direction montate "M" ou descenante "D"
        /// </summary>
        /// <param name="symbole"></param>
        /// <param name="dimension"></param>
        /// <param name="direction"></param>
        static void DessineMoiUneDiagonale(char symbole, int dimension, char direction)
        {

            if (direction == 'D')
            {
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (i == j)
                        {
                            Console.Write(symbole);
                        }
                        else
                        {
                            Console.Write('X');
                        }

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (i == dimension - j - 1)
                        {
                            Console.Write(symbole);
                        }
                        else
                        {
                            Console.Write('X');
                        }

                    }
                    Console.WriteLine();
                }
            }




        }

        /// <summary>
        /// Exercice 2 : Sablier
        /// </summary>
        static void Exercice2()
        {
            int hauteur = 0;
            Console.WriteLine("Vous avez sélectionné l'Exercice 2 : Sablier");
            while (hauteur < 1)
            {
                Console.WriteLine("Choisir une hauteur de sablier strictement positive");
                hauteur = Convert.ToInt32(Console.ReadLine());
            }
            Sablier(hauteur);
            Console.WriteLine("Echap pour quitter l'Exercice");
        }

        /// <summary>
        /// Construit un sablier avec des "X" d'une hauteur choisie
        /// </summary>
        /// <param name="hauteur"></param>
        static void Sablier(int hauteur)
        {
            // On commence par construire la moitié haute du sablier
            for (int i = 0; i < hauteur / 2; i++)
            {
                if (2 * i != hauteur) // Pour régler le probème des hauteur paires
                {
                    //On met le nombre d'espace nécessaire qui augmente de 1 à chaque ligne
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(' ');
                    }
                    //Puis le nombre de X nécessaire qui diminue de 2 à chaque ligne
                    for (int j = 0; j < hauteur - 2 * i; j++)
                    {
                        Console.Write('X');
                    }
                    Console.WriteLine();
                }
            }
            // Puis on contruit la moitié basse du sablier
            for (int i = hauteur / 2; i >= 0; i--)
            {
                if (2 * i != hauteur) // Pour régler le probème des hauteur paires
                {
                    //On met le nombre d'espace nécessaire qui diminue de 1 à chaque ligne
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(' ');
                    }
                    //Puis le nombre de X nécessaire qui augmente de 2 à chaque ligne
                    for (int j = 0; j < hauteur - 2 * i; j++)
                    {
                        Console.Write('X');
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Exercice 3 : Table de Multiplication
        /// </summary>
        static void Exercice3()
        {
            int dimension = 0;
            Console.WriteLine("Vous avez sélectionné l'Exercice 3 : Table de Multiplication");
            while (dimension < 1)
            {
                Console.WriteLine("Choisir une dimension de matrice strictement positive");
                dimension = Convert.ToInt32(Console.ReadLine());
            }
            Matrice(dimension);
            Console.WriteLine("Echap pour quitter l'Exercice");

        }

        /// <summary>
        /// Affiche les tables de mutlitplication jusqu'à un nombre choisi
        /// </summary>
        /// <param name="dimension"></param>
        static void Matrice(int dimension)
        {
            /* Pour afficher les tables proprement  
               on compte le nombre de caractère qu'occupe le plus grand nombre
               pour avoir un affichage aligné comme s'il y avait des cases invisbles */

            short nombreCaractèreMax = NombreDeCaratère(dimension * dimension);
            for (int i = 1; i <= dimension; i++)
            {
                Console.WriteLine();
                for (int j = 1; j <= dimension; j++)
                {
                    for (int nbEspace = nombreCaractèreMax - NombreDeCaratère(i * j); nbEspace >= 0; nbEspace--)
                    {
                        Console.Write(' ');
                    }
                    Console.Write(i * j);
                }
            }
        }

        /// <summary>
        /// Compte le nombre de caractère d'un nombre choisi
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        static short NombreDeCaratère(int nombre)
        {
            short count = 0;
            while (Math.Abs(nombre) > 9)
            {
                nombre /= 10;
                count++;
            }
            if (nombre < 0)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Exercice 4 : Remplir, afficher et trouver le minimum d'un tableau
        /// </summary>
        static void Exercice4()
        {
            int longueur = -1;
            Console.WriteLine("Vous avez sélectionné l'Exercice 4 : Remplir, afficher et trouver le minimum d'un tableau");
            while (longueur < 1)
            {
                Console.WriteLine("Choisir une longueur de tableau strictement positive");
                longueur = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Le tableau sera rempli aléatoirement considérant un minimum et un maximum :");
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[] tableau = RemplirUnTableau(longueur, minimum, maximum);
            AfficherTableau(tableau);
            int minimumDuTableau = MinimumDeTableau(tableau);
            Console.WriteLine("Le minimum du tableau est " + tableau[minimumDuTableau] + " à la case " + (minimumDuTableau + 1));
            Console.WriteLine("Echap pour quitter l'Exercice");
        }

        /// <summary>
        /// Remplit un tableau, selon une longueur choisie, de nombre situés entre un minimum
        /// et un maximum choisi
        /// </summary>
        /// <param name="longueur"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        static int[] RemplirUnTableau(int longueur, int minimum, int maximum)
        {
            Random random = new Random();
            int[] tableau = new int[longueur];
            for (int i = 0; i < longueur; i++)
            {
                tableau[i] = random.Next(minimum, maximum + 1);
            }
            return tableau;
        }

        /// <summary>
        /// Affiche un tableau
        /// </summary>
        /// <param name="tableau"></param>
        static void AfficherTableau(int[] tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.Write(" | " + tableau[i]);
            }
            Console.WriteLine(" |");
        }

        /// <summary>
        /// Renvoie la situation du plus petit nombre du tableau
        /// </summary>
        /// <param name="tableau"></param>
        /// <returns></returns>
        static int MinimumDeTableau(int[] tableau)
        {
            int minimum = 0;
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] < tableau[minimum])
                {
                    minimum = i;
                }
            }
            return minimum;
        }


        /// <summary>
        /// Exercice 5 : Inverser une chaine de caractères
        /// </summary>
        static void Exercice5()
        {
            Console.WriteLine("Vous avez sélectionné l'Exercice 5 : Inverser une chaine de caractères");
            Console.WriteLine("Rentrez une chaine de caractères");
            string chaine = Convert.ToString(Console.ReadLine());
            Console.WriteLine(Inverse(chaine));
            Console.WriteLine("Echap pour quitter l'Exercice");


        }

        /// <summary>
        /// Inverse une chaîne de caratcère
        /// </summary>
        /// <param name="chaine"></param>
        /// <returns></returns>
        /// 
        static string Inverse(string chaine)
        {
            string inverse = null;
            for (int i = chaine.Length - 1; i >= 0; i--)
            {
                inverse += chaine[i];
            }
            return inverse;
        }

        /// <summary>
        /// Exercice 6 : Compter le nombre d'appratition d'un mot dans une phrase
        /// </summary>
        static void Exercice6()
        {
            Console.WriteLine("Vous avez sélectionné l'Exercice 6 : Compter le nombre d'appratition d'un mot dans une phrase");
            Console.WriteLine("Saisir le mot à compter");
            string mot = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Saisir la phrase");
            string phrase = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Le mot " + mot + " apparaît " + NombreApparition(mot, phrase) + " fois dans la phrase");
            Console.WriteLine("Echap pour quitter l'Exercice");


        }

        /// <summary>
        /// Retourne le nombre d'apparition d'un mot dans une phrase
        /// </summary>
        /// <param name="mot"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        static int NombreApparition(string mot, string phrase)
        {
            int count = 0;
            bool isHere = false;
            // On se déplace caractère par caractère dans la phrase
            for (int i = 0; i <= phrase.Length - mot.Length; i++)
            {
                isHere = true;
                // On compare le mot avec la suite de caractère partant de i dans la phrase
                for (int j = 0; j < mot.Length; j++)
                {
                    if (mot[j] != phrase[i + j])
                    {
                        isHere = false;
                        break;
                    }
                }
                if (isHere)
                {
                    count++;
                    isHere = false;
                }
            }
            return count;
        }


        /// <summary>
        /// Exercice 7 : Additionner deux matrices
        /// </summary>
        static void Exercice7()
        {
            Console.WriteLine("Vous avez sélectionné l'Exercice 7 : Additionner deux matrices");

            //Initialisation de la première matrice

            int hauteur = -1;
            int largeur = -1;
            while (hauteur < 1)
            {
                Console.WriteLine("Choisir la hauteur de la première matrice strictement positive");
                hauteur = Convert.ToInt32(Console.ReadLine());
            }
            while (largeur < 1)
            {
                Console.WriteLine("Choisir la largeur de la première matrice strictement positive");
                largeur = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("La matrice sera remplie aléatoirement considérant un minimum et un maximum :");
            Console.WriteLine("Choisir le minimum");
            int minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            int maximum = Convert.ToInt32(Console.ReadLine());
            int[,] matrice1 = CréerMatrice(hauteur, largeur, minimum, maximum);

            //Initialisation de la deuxième matrice

            Console.Clear();
            hauteur = -1;
            largeur = -1;
            while (hauteur < 1)
            {
                Console.WriteLine("Choisir la hauteur de la deuxième matrice strictement positive");
                hauteur = Convert.ToInt32(Console.ReadLine());
            }
            while (largeur < 1)
            {
                Console.WriteLine("Choisir la largeur de la deuxième matrice strictement positive");
                largeur = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("La matrice sera remplie aléatoirement considérant un minimum et un maximum :");
            Console.WriteLine("Choisir le minimum");
            minimum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisir le Maximum");
            maximum = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            int[,] matrice2 = CréerMatrice(hauteur, largeur, minimum, maximum);
            Console.WriteLine("L'addition des deux matrices :");
            AfficherMatrice(AdditionnerMatrices(matrice1, matrice2));
            Console.WriteLine("Echap pour quitter l'Exercice");





        }

        /// <summary>
        /// Créer une matrice selon des dimensions choisies avec des nombres situés entre un minimum et un maximum choisi
        /// </summary>
        /// <param name="hauteur"></param>
        /// <param name="largeur"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        static int[,] CréerMatrice(int hauteur, int largeur, int minimum, int maximum)
        {
            int[,] matrice = new int[hauteur, largeur];
            Random random = new Random();
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    matrice[i, j] = random.Next(minimum, maximum + 1);
                }
            }
            return matrice;
        }

        /// <summary>
        /// Additionne deux matrices
        /// </summary>
        /// <param name="matrice1"></param>
        /// <param name="matrice2"></param>
        /// <returns></returns>
        static int[,] AdditionnerMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] matrice = null;
            if (matrice1 != null && matrice2 != null && matrice1.GetLength(0) == matrice2.GetLength(0) && matrice1.GetLength(1) == matrice2.GetLength(1))
            {
                matrice = new int[matrice1.GetLength(0), matrice1.GetLength(1)];
                for (int i = 0; i < matrice1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice1.GetLength(1); j++)
                    {
                        matrice[i, j] = matrice1[i, j] + matrice2[i, j];
                    }
                }
            }
            else
            {
                Console.WriteLine("Impossible d'additionner les deux matrices");
            }
            return matrice;
        }

        /// <summary>
        /// Affiche une matrice
        /// </summary>
        /// <param name="matrice"></param>
        static void AfficherMatrice(int[,] matrice)
        {
            short nombreCaractèreMax = NombreDeCaratère(MaximumMatrice(matrice));
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write('|');
                    for (int nbEspace = nombreCaractèreMax - NombreDeCaratère(matrice[i, j]); nbEspace > 0; nbEspace--)
                    {
                        Console.Write(' ');
                    }


                    Console.Write(matrice[i, j]);
                }
                Console.Write('|');
            }
        }

        /// <summary>
        /// Retourne la valeur de la norme maximum des composants du tableau
        /// </summary>
        /// <param name="matrice"></param>
        /// <returns></returns>
        static int MaximumMatrice(int[,] matrice)
        {
            int maximum = matrice[0, 0];
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    if (Math.Abs(matrice[i, j]) > Math.Abs(maximum))
                    {
                        maximum = matrice[i, j];
                    }
                }
            }
            return maximum;
        }

        /// <summary>
        /// Affiche le menu des différents exercices du TD
        /// </summary>
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu : Tapez un numéro pour choisir l'Exercice désiré\n");
            Console.WriteLine("Exercice 1 : Dessiner une Matrice ou une Diagonale");
            Console.WriteLine("Exercice 2 : Sablier");
            Console.WriteLine("Exercice 3 : Table de Multiplication");
            Console.WriteLine("Exercice 4 : Remplir, afficher et trouver le minimum d'un tableau");
            Console.WriteLine("Exercice 5 : Inverser une chaine de caractères");
            Console.WriteLine("Exercice 6 : Compter le nombre d'appratition d'un mot dans une phrase");
            Console.WriteLine("Exercice 7 : Additionner deux matrices\n");
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

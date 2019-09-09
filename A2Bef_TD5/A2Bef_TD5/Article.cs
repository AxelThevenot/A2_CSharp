using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Bef_TD5
{
    class Article
    {
        public long Reference { get; private set; }
        public string Intitule { get; private set; }
        public float PrixHT { get; private set; }
        public int QuantiteEnStock { get; private set; }



        public Article(long reference, string intitule, float prixHT, int qtStock)
        {
            this.Reference = reference;
            this.Intitule = intitule;
            this.PrixHT = prixHT;
            this.QuantiteEnStock = qtStock;
        }

        public Article(long reference, string intitule, float prixHT)
        {
            this.Reference = reference;
            this.Intitule = intitule;
            this.PrixHT = prixHT;
        }


        public void Approvisionner(int nombreUnites)
        {
            this.QuantiteEnStock += nombreUnites;
        }

        public bool Vendre(int nombreUnites)
        {
            bool vendu = false;
            if (nombreUnites <= this.QuantiteEnStock)
            {
                this.QuantiteEnStock -= nombreUnites;
                vendu = true;
            }
            return vendu;

        }

        public float PrixTTC(float pourcentageDeTaxe)
        {
            return this.PrixHT * pourcentageDeTaxe;
        }
        public float PrixTTC()
        {
            //Par défaut on place un taxe à 19,6%
            return (float)(this.PrixHT * 1.196);
        }

        public override string ToString()
        {
            return "Reference : " + this.Reference.ToString() + "\nIntitulé : " + this.Intitule + "\nPrixHT : " + this.PrixHT.ToString();
        }

        public bool Equals(Article autre)
        {
            bool eq = false;
            if (this.Reference == autre.Reference)
            {
                eq = !eq;
            }
            return eq;
        }
    }
}

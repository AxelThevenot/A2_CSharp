using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Bef_TD5
{
    class CompteBancaire
    {
        public bool Flag { get; private set; }
        public string NomClient { get; private set; }
        public decimal Montant { get; private set; }
        public int Tentative { get; private set; }

        static int nombreClient = 0;
        static int nombreClientBloque = 0;

        public CompteBancaire(string nom, decimal montant)
        {
            this.Flag = false;
            this.NomClient = nom;
            this.Montant = montant;
            this.Tentative = 0;
            nombreClient++;
        }
        public CompteBancaire(string nom)
        {
            this.Flag = false;
            this.NomClient = nom;
            this.Montant = 0;
            this.Tentative = 0;
            nombreClient++;
        }

        public void Crediter(int credit)
        {
            this.Montant += credit;
            this.Tentative = 0;
            if (this.Flag)
            {
                this.Flag = false;
                nombreClientBloque--;
            }
        }


        public bool Debiter(int debit)
        {
            if (this.Flag)
            {
                return false;
            }
            else if (this.Montant < debit)
            {
                if (this.Tentative >= 2)
                {
                    this.Tentative = 0;
                    this.Flag = true;
                    nombreClientBloque++;
                }
                else
                {
                    this.Tentative++;
                }
                return false;
            }
            else
            {
                this.Montant -= debit;
                this.Tentative = 0;
                return true;
            }
        }

        public override string ToString()
        {
            return "\nnom : " + this.NomClient + "\nmontant : " + this.Montant.ToString() + "\nflag : " + this.Flag.ToString() + "\ntentative : " + this.Tentative.ToString() + "\n";
        }

        public static int NombreClient()
        {
            return nombreClient;
        }
        public static int NombreClientBloque()
        {
            return nombreClientBloque;
        }


    }
}

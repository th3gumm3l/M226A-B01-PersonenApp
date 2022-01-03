using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonenAppV2.MitProperties
{
    public class Person
    {
        
    //Klassenvariablen (alle Objekte der Klasse teilen sich diese)
        private const double MINSALAER = 0;
        private const double MAXSALAER = 99999.95;
        private const int MINENTRYYEAR = 1975;
        private static int sAnzahlPersonen = 0;
        
    //Memebervariablen (jedes Objekt hat seine eigene Variable)
        private int m_PersNr = 0;
        private int m_Eintrittsjahr = 0;
        private double m_Salaer = 0.00;
        private double m_Pensum = 0.00;
        
    //Konstruktoren
        public Person() {
            PersNr = ++sAnzahlPersonen;
            Anrede = "Frau";
            Name = "Neue Person";
            Vorname = "";
            Plz = "6000";
            Ort = "Luzern";
            Eintrittsjahr = DateTime.Now.Year;
            Salaer = 5000.00;
            Pensum = 100.00;
        }
        public Person(string anrede, string name, string vornname) {
            PersNr = ++sAnzahlPersonen;
            Anrede = anrede;
            Name = name;
            Vorname = vornname;
        }
        public Person(string name, string vornname, int eintrittsjahr) {
            PersNr = ++sAnzahlPersonen;
            Name = name;
            Vorname = vornname;
            Eintrittsjahr = eintrittsjahr;
        }
    
    //Membermethoden (gehören zum Objekt und verwenden jeweils die eigenen Membervariablen)
        public int PersNr {
            get { return m_PersNr; }
            private set { m_PersNr = value; }
        }
        
    //Es ginge auch mit Lambda Ausdrücken:
        //public int PersNr {
        //    get => m_PersNr; 
        //    private set => m_PersNr = value; 
        //}

        public string Anrede { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public int Eintrittsjahr
        {
            get { return m_Eintrittsjahr; }
            set {
                if (value < MINENTRYYEAR) {
                    value = MINENTRYYEAR;
                    MessageBox.Show("Der Minimalwert des Eintrittsjahres wurde unterschritten",
                                    "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (value > DateTime.Now.Year) {
                    value = DateTime.Now.Year;
                    MessageBox.Show("Das Eintrittsjahr kann das aktuelle Jahr nicht überschreiten",
                                    "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                m_Eintrittsjahr = value;
            }
        }
        public double Salaer
        {
            get { return m_Salaer; }
            set {
                if (value < MINSALAER) {
                    value = MINSALAER;
                    MessageBox.Show("Der Minimalwert des Salärs wurde unterschritten", "Eingabefehler",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (value > MAXSALAER) {
                    value = MAXSALAER;
                    MessageBox.Show("Der Maximalwert des Salärs wurde überschritten", "Eingabefehler",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                m_Salaer = value;
            }
        }
        public double Pensum { get; set; }

        public double calculateLohn() {
            return m_Salaer / 100 * m_Pensum;
        }

        public static double calculateLohn(double lohn, double pensum) {
            return lohn / 100 * pensum;
        }
    }
}

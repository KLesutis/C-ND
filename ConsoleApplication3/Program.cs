
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication3
{
    public class Program
    {

        //Kadangi Random clase kazkodem grazina statinius duomenys, tai radau toki sprendima internte
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        static void Main(string[] args)
        {
            Stopwatch sw;
            for (int c = 10; c <= 100000; c *= 10)
            {
                sw = Stopwatch.StartNew();
                List<Student> students = new List<Student>();

                string outputV = "";
                string outputK = "";
                for (int j = 0; j < c; j++)
                {
                    students.Add(new Program().GenerateStudent(j));

                }
                students.Sort((x, y) => x.Final.CompareTo(y.Final));

                string[] header = new string[4];
                header[0] = "Vardas";
                header[1] = "Pavarde";
                header[2] = "Galutinis / Vid";
                header[3] = "Kategorija";

                outputK += PrintRow(header);
                outputK += PrintLine();
                outputV += PrintRow(header);
                outputV += PrintLine();

                for (int i = 0; i < students.Count; i++)
                {
                    string[] row = new string[3];

                    row[0] = students[i].Fname;
                    row[1] = students[i].Lname;
                    row[2] = students[i].Final.ToString();
                    if (students[i].Final >= 5.0)
                    {
                        outputK += PrintRow(row);
                    }
                    else
                    {
                        outputV += PrintRow(row);
                    }



                }
                Console.WriteLine("Įvyko precesas per: " + sw.ElapsedMilliseconds + " ms , su " + c +" duomenimis");
                sw.Stop();
                string path = "Z:/CS_output";
                File.WriteAllText(Path.Combine(path, "Kresult" + c + ".txt"), outputK);
                File.WriteAllText(Path.Combine(path, "Vresult" + c + ".txt"), outputV);
            }



        }
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }


        Student SetStudent()
        {
            Console.WriteLine("Iveskite ND skaiciu");
            int n = Convert.ToInt32(Console.ReadLine());
            double[] nd = new double[n];
            Console.WriteLine("Iveskite egz rezultata");

            double egz = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite ND rezultatus");

            Console.WriteLine("Ar sudeliot ND asitiktinai? T/N");
            if (Console.ReadLine().ToLower() == "n")
            {
                for (int i = 0; i < n; i++)
                {
                    nd[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    nd[i] = RandomNumber(1, 10); ;
                }
            }

            Console.WriteLine("Iveskite varda");

            string fname = (Console.ReadLine());
            Console.WriteLine("Iveskite pavarde");

            string lname = (Console.ReadLine());

            return new Student(n, nd, egz, fname, lname, GetFinalAvg(nd, egz));
        }
        public Student GenerateStudent(int number)
        {
            int n = 5;
            double[] nd = new double[n];
            double egz = RandomNumber(1, 10);

            for (int i = 0; i < n; i++)
            {

                nd[i] = RandomNumber(1, 10);
            }


            string fname = "Vardas" + number;

            string lname = "Pavarde" + number;

            double final = 0;
            for (int i = 0; i < n; i++)
            {
                final += nd[i];
            }
            final /= n;
            final *= 0.3;
            final += 0.7 * egz;


            return new Student(n, nd, egz, fname, lname, final);
        }
        public double GetFinalAvg(double[] rez, double egz)
        {
            double final = 0;
            for (int i = 0; i < rez.Length; i++)
            {
                final += rez[i];
            }
            final /= (double)rez.Length;
            final *= 0.3;
            final += 0.7 * (double)egz;
            return final;
        }
        public static double GetFinalMedian(double[] nd, double egz)
        {

            double[] sortedPNumbers = (double[])nd.Clone();
            Array.Sort(sortedPNumbers);

            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            median *= 0.3;
            median += 0.7 * (double)egz;
            return median;
        }

        static string PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            return (row + "\n");
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        static string PrintLine()
        {
            return (new string('-', tableWidth) + "\n");
        }
        static int tableWidth = 77;

    }

    public class Student
    {
        private int nNd;
        private double[] nd;
        private double egz;
        private string fname;
        private string lname;
        private double final;

        public Student(int nNd, double[] nd, double egz, string fname, string lname, double final)
        {
            this.nNd = nNd;
            this.nd = nd;
            this.egz = egz;
            this.fname = fname;
            this.lname = lname;
            this.final = final;
        }

        public int NNd
        {
            get
            {
                return nNd;
            }

            set
            {
                nNd = value;
            }
        }
        public double Final
        {
            get
            {
                return final;
            }

            set
            {
                final = value;
            }
        }

        public double[] Nd
        {
            get
            {
                return nd;
            }

            set
            {
                nd = value;
            }
        }

        public double Egz
        {
            get
            {
                return egz;
            }

            set
            {
                egz = value;
            }
        }

        public string Fname
        {
            get
            {
                return fname;
            }

            set
            {
                fname = value;
            }
        }

        public string Lname
        {
            get
            {
                return lname;
            }

            set
            {
                lname = value;
            }
        }
    }
}


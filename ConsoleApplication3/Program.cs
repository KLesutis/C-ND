﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            /*Console.WriteLine("Iveskite studentu duomenys, kai noresi baigti iveskite +");
            while(true) {
                Console.WriteLine("Iveskite studento duomenys");

                students.Add(SetStudentFromConsole());
                Console.WriteLine("Ar norite baigti? 't' = Taip");

                if (Console.ReadLine().ToLower() == "t") {
                    break;
                }
            }*/

            string[] lines = System.IO.File.ReadAllLines("students.txt");
            Boolean first = true;
            foreach (string line in lines)
            {
                if(first) {
                    first = false;
                    continue;
                }
                string[] data = line.Split(' ');
                double[] nd = new double[5];
                double egz = 0;
                try {
                    nd[0] = Double.Parse(data[2]);
                    nd[1] = Double.Parse(data[3]);
                    nd[2] = Double.Parse(data[4]);
                    nd[3] = Double.Parse(data[5]);
                    nd[4] = Double.Parse(data[6]);
                    egz = Double.Parse(data[7]);
                } catch(Exception e) {
                    Console.WriteLine("Bandoma simbolį konvertuotį į skaičių.");
                }


                students.Add(new Student(5,nd, egz,data[0], data[1]));
                
            }

            string[] header = new string[4];
            header[0] = "Vardas";
            header[1] = "Pavarde";
            header[2] = "Galutinis / Vid";
            header[3] = "Galutinis / Med";

            PrintRow(header);
            PrintLine();

            for (int i = 0; i < students.Count; i++)
            {
                string[] row = new string[4];

                row[0] = students[i].Fname;
                row[1] = students[i].Lname;
                try {
                    row[2] = GetFinalAvg(students[i].Nd, students[i].Egz).ToString();
                    row[3] = GetFinalMedian(students[i].Nd, students[i].Egz).ToString();
                } catch (Exception e) {
                    Console.WriteLine("Paduoti blogi duomenys į galutį rezultato metodą.");
                    System.Environment.Exit(1);
                }

                PrintRow(row);

            }

            


        }



        static Student SetStudentFromConsole()
        {
            Console.WriteLine("Iveskite ND skaiciu");
            int n = 0;
            try {
                n = Convert.ToInt32(Console.ReadLine());
            } catch(Exception e) {
                Console.WriteLine("Bandoma konvertuotį simbo į skaičių.");
                System.Environment.Exit(1);
            }
            double[] nd = new double[n];
            Console.WriteLine("Iveskite egz rezultata");

            double egz = 0;
            try{
                egz = Convert.ToInt32(Console.ReadLine());
            }catch (Exception e) {
                Console.WriteLine("Bandoma konvertuotį simbo į skaičių.");
                System.Environment.Exit(1);
            }
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
                    nd[i] = new Random().Next(10);
                }
            }

            Console.WriteLine("Iveskite varda");

            string fname = (Console.ReadLine());
            Console.WriteLine("Iveskite pavarde");

            string lname = (Console.ReadLine());

            return new Student(n, nd, egz, fname, lname);
        }

        static double GetFinalAvg(double[] rez, double egz) {
            double final = 0;
            for (int i = 0; i < rez.Length; i++) {
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

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
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
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        static int tableWidth = 77;

    }

    
}
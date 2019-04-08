using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Student
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

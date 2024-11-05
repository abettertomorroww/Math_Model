using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathModel
{
    class MathModel
    {
        public readonly double[] C = new double[5] { 1.02, 0.93, 0.386, 3.28, 0.084 };
        public readonly double R = 1.9865;
        public readonly double[] E = new double[5] { 16000, 14000, 15000, 10000, 15000 };

        /// <summary>
        /// количество сырья
        /// </summary>
        public double[] x1 = new double[11];
        /// <summary>
        /// количество промежуточного вещества
        /// </summary>
        public double[] x2 = new double[11];
        /// <summary>
        /// количество окончатьельного вещества
        /// </summary>
        public double[] x3 = new double[11];

        public double[] Z = new double[11];
        /// <summary>
        /// Время
        /// </summary>
        public double[] T = new double[11] { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1};
        /// <summary>
        /// Температура
        /// </summary>
        public double U = 700;
        public double[] K = new double[10];

        public double A_coefficient;
        public double B_coefficient;
        public double C_coefficient;

        public void Calculated() 
        {
            K = Return_calculated_k(C, E, R, U);

            A_coefficient = K[6] / (K[7] * K[8]);
            B_coefficient = K[6] / (K[7] * K[9]);
            C_coefficient = K[6] / (K[8] * K[9]);

            for (int i = 0; i < T.Length; i++)
            {
                Z[i] = (A_coefficient * Math.Exp(-K[5] * T[i])) - B_coefficient + (C_coefficient * Math.Exp(-K[3] * T[i]));

                x1[i] = Math.Exp(-K[5] * T[i]);

                x2[i] = (K[0] / (K[3] - K[5])) * (Math.Exp(-K[5] * T[i]) - Math.Exp(-K[3] * T[i]));

                x3[i] = ((K[3] * K[0]) / (K[3] - K[5])) *
                    ((Math.Exp(-K[5] * T[i]) / (K[4] - K[5])) - (Math.Exp(-K[3] * T[i]) / (K[4] - K[3]))) +
                    (K[3] * K[0] / ((K[4] - K[5]) * (K[4] - K[3]))) *
                    (Math.Exp(-K[4] * T[i]));
            }            
        }
        

        double[] Return_calculated_k(double[] c, double[] e, double r, double u)
        {
            double[] k = new double[10];

            for (int i = 0; i < C.Length; i++)
                k[i] = c[i] * Math.Exp(e[i] / r * (0.0015197568 - (1 / u)));

            k[5] = k[0] + k[1] + k[2];
            k[6] = k[3] * k[0];
            k[7] = k[3] - k[5];
            k[8] = k[4] - k[5];
            k[9] = k[4] - k[3];

            return k;
        }


    }
}

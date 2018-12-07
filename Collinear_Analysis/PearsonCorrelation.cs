using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collinear_Analysis
{
    public sealed class PearsonCorrelation
    {
        public static double GetSimilarityScore(double[,] p, double[,] q)
        {
            int Width = p.GetLength(0);
            int Height = p.GetLength(1);

            if (Width != q.GetLength(0) || Height != q.GetLength(1))
            {
                throw new ArgumentException("Input vectors must be of the same dimension.");
            }

            double pSum = 0, qSum = 0, pSumSq = 0, qSumSq = 0, productSum = 0;
            double pValue, qValue;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    pValue = p[y, x];
                    qValue = q[y, x];

                    pSum += pValue;
                    qSum += qValue;
                    pSumSq += pValue * pValue;
                    qSumSq += qValue * qValue;
                    productSum += pValue * qValue;
                }
            }

            double numerator = productSum - ((pSum * qSum) / (double)Height);
            double denominator = Math.Sqrt((pSumSq - (pSum * pSum) / (double)Height) * (qSumSq - (qSum * qSum) / (double)Height));

            return (denominator == 0) ? 0 : numerator / denominator;
        }
    }
}

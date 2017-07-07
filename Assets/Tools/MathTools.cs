using System;
using UnityEngine;

    public static class MathTools
    {

        public static float Distance(Vector3 pFrom, Vector3 pTo)
        {
            return (pTo - pFrom).magnitude;
        }

        public static float DistanceSquared(Vector3 pFrom, Vector3 pTo)
        {
            return (pTo - pFrom).sqrMagnitude;
        }

        public static Vector3 Direction(Vector3 pFrom, Vector3 pTo)
        {
            return (pTo - pFrom).normalized;
        }

        public static Vector3 Vector3Clamp(Vector3 pValue, Vector3 pMinValue, Vector3 pMaxValue)
        {
            return new Vector3(Mathf.Clamp(pValue.x, pMinValue.x, pMaxValue.x), Mathf.Clamp(pValue.y, pMinValue.y, pMaxValue.y), Mathf.Clamp(pValue.z, pMinValue.z, pMaxValue.z));
        }

        public static double Clamp(double pValue, double pMin, double pMax)
        {
            return (pValue < pMin ? pMin : pValue > pMax ? pMax : pValue);
        }

        public static double ClampMin(double pValue, double pMin)
        {
            return (pValue < pMin ? pMin : pValue);
        }

        public static double ClampMax(double pValue, double pMax)
        {
            return (pValue > pMax ? pMax : pValue);
        }

        /// <summary>
        /// When the value goes beyond max it will wrap around to the min value and vice versa when it goes under the min value.
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pMin"></param>
        /// <param name="pMax"></param>
        /// <returns></returns>
        public static int Wrap(int pValue, int pMin, int pMax)
        {
            if (pValue < pMin)
                pValue = pMax;
            else if (pValue > pMax)
                pValue = pMin;

            return pValue;
        }

        public static int DigitCount(int pValue)
        {
            return pValue != 0 ? Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(pValue))) + 1 : 0;
        }

        /// <summary>
        /// Test if pValue1 is within pValue2 +- pTolerance.
        /// </summary>
        /// <param name="pValue1"></param>
        /// <param name="pValue2"></param>
        /// <param name="pTolerance"></param>
        /// <returns></returns>
        public static bool Approximately(float pValue1, float pValue2, float pTolerance)
        {
            return pValue1 >= pValue2 - pTolerance && pValue1 <= pValue2 + pTolerance;
        }

        public static bool Approximately(Vector3 pValue1, Vector3 pValue2, Vector3 pTolerance)
        {
            return Approximately(pValue1.x, pValue2.x, pTolerance.x)
                && Approximately(pValue1.y, pValue2.y, pTolerance.y)
                && Approximately(pValue1.z, pValue2.z, pTolerance.z);
        }

        /// <summary>
        /// Generates a number in the range [0,pCount] with the value specified in pValue
        /// occuring more often specified in the pWeight parameter.
        /// </summary>
        /// <param name="pCount">Highest value to generate (Exclusive). If <= 1 zero will be returned.</param>
        /// <param name="pValue">The value to occur more often</param>
        /// <param name="pWeight">How often the pValue should occur in percentage (between 0 and 1)</param>
        /// <returns></returns>
        public static int WeightedRandom(int pCount, int pValue, float pWeight)
        {
            float r = UnityEngine.Random.value;

            if (pCount <= 1)
            {
                return 0;
            }
            else if (r <= pWeight)
            {
                return pValue;
            }
            else
            {
                int[] arr = new int[pCount - 1];
                for (int i = 0, neg = 0; i < arr.Length + 1; i++)
                {
                    if (i == pValue)
                    {
                        neg++;
                        continue;
                    }

                    arr[i - neg] = i;
                }

                int index = UnityEngine.Random.Range(0, arr.Length);
                return arr[index];
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;

    public static class EnumTools
    {
        public static IEnumerable<TEnum> Get<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        public static bool HasValue<TEnum>(string pValue)
        {
            foreach (var enumVal in Enum.GetValues(typeof(TEnum)))
            {
                if (enumVal.ToString() == pValue)
                    return true;
            }

            return false;
        }

        public static TEnum AddWrap<TEnum>(TEnum pEnum, int pValue)
        {
            TEnum[] values = Enum.GetValues(pEnum.GetType()) as TEnum[];

            int val = Convert.ToInt32(pEnum) + pValue;
            if (val >= values.Length)
            {
                val -= values.Length;
            }

            pEnum = values[val];
            return pEnum;
        }

        public static bool TryParse<TEnum>(string pValue, out TEnum pOut)
        {
            pOut = default(TEnum);

            if (string.IsNullOrEmpty(pValue) || !HasValue<TEnum>(pValue))
                return false;

            pOut = (TEnum)Enum.Parse(typeof(TEnum), pValue);
            return true;
        }

        public static bool TryParse<TEnum>(int pValue, out TEnum pOut)
        {
            pOut = default(TEnum);

            foreach (var enumVal in Enum.GetValues(typeof(TEnum)))
            {
                if ((int)enumVal == pValue)
                {
                    pOut = (TEnum)enumVal;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Generate a random enum of enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEnum"></param>
        /// <returns></returns>
        public static T EnumRandomizer<T>()
        {
            int[] enumInts = (int[])Enum.GetValues(typeof(T));
            int rEnumInt = UnityEngine.Random.Range(0, enumInts.Length);
            for (int i = 0; i < enumInts.Length; i++)
            {

                if (i == rEnumInt)
                {
                    T res;
                    TryParse(i, out res);
                    return res;
                }
            }

            return default(T);
        }
    }




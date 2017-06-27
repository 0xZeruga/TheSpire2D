using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Xml.Serialization;
using UnityEngine;
using Assets.Scripts.Tools;

namespace Assets.Scripts.InGameTime
{
    public enum SeasonType
    {
        WINTER = 1,
        SPRING = 2,
        SUMMER = 3,
        AUTUMN = 4
    }

    [Serializable, XmlType("GameTime")]
    public class GameTime : IEquatable<GameTime>, IFormattable//, IFileData
    {
        private static readonly GameTimeData m_Data = new GameTimeData();

        private static readonly double SECONDS_PER_MINUTE;
        private static readonly double SECONDS_PER_HOUR;
        private static readonly double SECONDS_PER_DAY;
        private static readonly double SECONDS_PER_SEASON;
        private static readonly double SECONDS_PER_YEAR;

        private static readonly double SEASONS_PER_YEAR;
        private static readonly double DAYS_PER_SEASON;
        private static readonly double HOURS_PER_DAY;
        private static readonly double MINUTES_PER_HOUR;

        private static readonly double TIMESPAN_RATIO;

        public static readonly GameTime Zero = new GameTime(0d);
        public static readonly GameTime Min = new GameTime(double.MinValue);
        public static readonly GameTime Max = new GameTime(double.MaxValue);

        private double m_Time = 0d;

        [XmlAttribute("Time")]
        public double Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }

        /// <summary>
        /// Bigass potatoload of methods, operators and wtf else
        /// </summary>
        public int Second
        {
            get { return (int)(m_Time - ((int)TotalMinutes * SECONDS_PER_MINUTE)); }
        }

        public int Minute
        {
            get { return (int)((m_Time - ((int)TotalHours * SECONDS_PER_HOUR)) / SECONDS_PER_MINUTE); }
        }

        public int Hour
        {
            get { return (int)((m_Time - ((int)TotalDays * SECONDS_PER_DAY)) / SECONDS_PER_HOUR); }
        }

        public int Day
        {
            get { return (int)((m_Time - ((int)TotalSeasons * SECONDS_PER_SEASON)) / SECONDS_PER_DAY) + 1; }
        }

        public int Season
        {
            get { return (int)((m_Time - ((int)TotalYears * SECONDS_PER_YEAR)) / SECONDS_PER_SEASON) + 1; }
        }

        public string SeasonName
        {
            get
            {
                SeasonType season;
                if (!EnumTools.TryParse(Season, out season))
                {
                    Debug.Log("Could not parse enum");
                }

                return season.ToString();
            }
        }

        public int Year
        {
            get { return (int)(m_Time / SECONDS_PER_YEAR) + 1; }
        }

        public double TotalSeconds
        {
            get { return m_Time; }
        }

        public double TotalMinutes
        {
            get { return m_Time / SECONDS_PER_MINUTE; }
        }

        public double TotalHours
        {
            get { return m_Time / SECONDS_PER_HOUR; }
        }

        public double TotalDays
        {
            get { return m_Time / SECONDS_PER_DAY; }
        }

        public double TotalSeasons
        {
            get { return m_Time / SECONDS_PER_SEASON; }
        }

        public double TotalYears
        {
            get { return m_Time / SECONDS_PER_YEAR; }
        }

        public int CompareSecond(GameTime pTime)
        {
            int ret;
            return ((ret = CompareMinute(pTime)) != 0 ? ret : (Second - pTime.Second));
        }

        public int CompareMinute(GameTime pTime)
        {
            int ret;
            return ((ret = CompareHour(pTime)) != 0 ? ret : (Minute - pTime.Minute));
        }

        public int CompareHour(GameTime pTime)
        {
            int ret;
            return ((ret = CompareDay(pTime)) != 0 ? ret : (Hour - pTime.Hour));
        }

        public int CompareDay(GameTime pTime)
        {
            int ret;
            return ((ret = CompareSeason(pTime)) != 0 ? ret : (Day - pTime.Day));
        }

        public int CompareSeason(GameTime pTime)
        {
            int ret;
            return ((ret = CompareYear(pTime)) != 0 ? ret : (Season - pTime.Season));
        }

        public int CompareYear(GameTime pTime)
        {
            return Year - pTime.Year;
        }

        public int CompareToSecond(GameTime pA, GameTime pB)
        {
            int ret;
            return ((ret = CompareToMinute(pA, pB)) != 0 ? ret : (pA.Second - pB.Second));
        }

        public int CompareToMinute(GameTime pA, GameTime pB)
        {
            int ret;
            return ((ret = CompareToHour(pA, pB)) != 0 ? ret : (pA.Minute - pB.Minute));
        }

        public int CompareToHour(GameTime pA, GameTime pB)
        {
            int ret;
            return ((ret = CompareToDay(pA, pB)) != 0 ? ret : (pA.Hour - pB.Hour));
        }

        public int CompareToDay(GameTime pA, GameTime pB)
        {
            int ret;
            return ((ret = CompareToSeason(pA, pB)) != 0 ? ret : (pA.Day - pB.Day));
        }

        public int CompareToSeason(GameTime pA, GameTime pB)
        {
            int ret;
            return ((ret = CompareToYear(pA, pB)) != 0 ? ret : (pA.Season - pB.Season));
        }

        public static int CompareToYear(GameTime pA, GameTime pB)
        {
            return pA.Year - pB.Year;
        }

        public void AttachSeconds(double pValue)
        {
            m_Time += pValue;
        }

        public void AttachMinutes(double pValue)
        {
            m_Time += pValue * SECONDS_PER_MINUTE;
        }

        public void AttachHours(double pValue)
        {
            m_Time += pValue * SECONDS_PER_HOUR;
        }

        public void AttachDays(double pValue)
        {
            m_Time += pValue * SECONDS_PER_DAY;
        }

        public void AttachSeasons(double pValue)
        {
            m_Time += pValue * SECONDS_PER_SEASON;
        }

        public void AttachYears(double pValue)
        {
            m_Time += pValue * SECONDS_PER_YEAR;
        }

        public void Attach(GameTime pValue)
        {
            m_Time += pValue.m_Time;
        }

        public void Attach(TimeSpan pValue)
        {
            m_Time += RawFromTimespan(pValue);
        }

        public void DetachSeconds(double pValue)
        {
            m_Time -= pValue;
        }

        public void DetachMinutes(double pValue)
        {
            m_Time -= pValue * SECONDS_PER_MINUTE;
        }

        public void DetachHours(double pValue)
        {
            m_Time -= pValue * SECONDS_PER_HOUR;
        }

        public void DetachDays(double pValue)
        {
            m_Time -= pValue * SECONDS_PER_DAY;
        }

        public void DetachSeasons(double pValue)
        {
            m_Time -= pValue * SECONDS_PER_SEASON;
        }

        public void DetachYears(double pValue)
        {
            m_Time -= pValue * SECONDS_PER_YEAR;
        }

        public void Detach(GameTime pValue)
        {
            m_Time -= pValue.m_Time;
        }

        public void Detach(TimeSpan pValue)
        {
            m_Time -= RawFromTimespan(pValue);
        }

        public GameTime AddSeconds(double pValue)
        {
            return new GameTime(m_Time + pValue);
        }

        public GameTime AddMinutes(double pValue)
        {
            return new GameTime(m_Time + (pValue * SECONDS_PER_MINUTE));
        }

        public GameTime AddHours(double pValue)
        {
            return new GameTime(m_Time + (pValue * SECONDS_PER_HOUR));
        }

        public GameTime AddDays(double pValue)
        {
            return new GameTime(m_Time + (pValue * SECONDS_PER_DAY));
        }

        public GameTime AddSeasons(double pValue)
        {
            return new GameTime(m_Time + (pValue * SECONDS_PER_SEASON));
        }

        public GameTime AddYears(double pValue)
        {
            return new GameTime(m_Time + (pValue * SECONDS_PER_YEAR));
        }

        public static GameTime Add(GameTime pA, GameTime pB)
        {
            return pA + pB;
        }

        public static GameTime Add(GameTime pA, TimeSpan pB)
        {
            return pA + pB;
        }

        public static GameTime Add(GameTime pA, double pB)
        {
            return pA + pB;
        }

        public GameTime SubtractSeconds(double pValue)
        {
            return new GameTime(m_Time - pValue);
        }

        public GameTime SubtractMinutes(double pValue)
        {
            return new GameTime(m_Time - (pValue * SECONDS_PER_MINUTE));
        }

        public GameTime SubtractHours(double pValue)
        {
            return new GameTime(m_Time - (pValue * SECONDS_PER_HOUR));
        }

        public GameTime SubtractDays(double pValue)
        {
            return new GameTime(m_Time - (pValue * SECONDS_PER_DAY));
        }

        public GameTime SubtractSeasons(double pValue)
        {
            return new GameTime(m_Time - (pValue * SECONDS_PER_SEASON));
        }

        public GameTime SubtractYears(double pValue)
        {
            return new GameTime(m_Time - (pValue * SECONDS_PER_YEAR));
        }

        public static GameTime Subtract(GameTime pA, GameTime pB)
        {
            return pA - pB;
        }

        public static GameTime Subtract(GameTime pA, TimeSpan pB)
        {
            return pA - pB;
        }

        public static GameTime Subtract(GameTime pA, double pB)
        {
            return pA - pB;
        }

        public GameTime Date
        {
            get { return new GameTime(Year, Season, Day); }
        }

        public static bool IsNullOrZero(GameTime pThis)
        {
            return ReferenceEquals(pThis, null) || pThis.m_Time == 0d;
        }

        public GameTime TimeOfDay
        {
            get { return new GameTime(1, 1, 1, Hour, Minute, Second); }
        }

        public static bool operator !(GameTime pThis)
        {
            return (!ReferenceEquals(pThis, null) && pThis.m_Time == 0d);
        }

        public static bool operator ==(GameTime pThis, GameTime pOther)
        {
            bool LHSNull = ReferenceEquals(pThis, null);
            bool RHSNull = ReferenceEquals(pOther, null);
            if (LHSNull || RHSNull)
            {
                return LHSNull && RHSNull;
            }

            return pThis.m_Time == pOther.m_Time;
        }

        public static bool operator ==(GameTime pThis, TimeSpan pOther)
        {
            if (ReferenceEquals(pThis, null))
                return false;

            return pThis.m_Time == RawFromTimespan(pOther);
        }

        public static bool operator ==(GameTime pThis, double pOther)
        {
            if (ReferenceEquals(pThis, null))
                return false;

            return pThis.m_Time == pOther;
        }

        public static bool operator !=(GameTime pThis, GameTime pOther)
        {
            bool LHSNull = ReferenceEquals(pThis, null);
            bool RHSNull = ReferenceEquals(pOther, null);
            if (LHSNull || RHSNull)
            {
                return !(LHSNull && RHSNull);
            }

            return pThis.m_Time != pOther.m_Time;
        }

        public static bool operator !=(GameTime pThis, TimeSpan pOther)
        {
            if (ReferenceEquals(pThis, null))
                return true;

            return pThis.m_Time != RawFromTimespan(pOther);
        }

        public static bool operator !=(GameTime pThis, double pOther)
        {
            if (ReferenceEquals(pThis, null))
                return true;

            return pThis.m_Time != pOther;
        }

        public static bool operator <(GameTime pThis, GameTime pOther)
        {
            return pThis.m_Time < pOther.m_Time;
        }

        public static bool operator <(GameTime pThis, TimeSpan pOther)
        {
            return pThis.m_Time < RawFromTimespan(pOther);
        }

        public static bool operator <(GameTime pThis, double pOther)
        {
            return pThis.m_Time < pOther;
        }

        public static bool operator <=(GameTime pThis, GameTime pOther)
        {
            return pThis.m_Time <= pOther.m_Time;
        }

        public static bool operator <=(GameTime pThis, TimeSpan pOther)
        {
            return pThis.m_Time <= RawFromTimespan(pOther);
        }

        public static bool operator <=(GameTime pThis, double pOther)
        {
            return pThis.m_Time <= pOther;
        }

        public static bool operator >(GameTime pThis, GameTime pOther)
        {
            return pThis.m_Time > pOther.m_Time;
        }

        public static bool operator >(GameTime pThis, TimeSpan pOther)
        {
            return pThis.m_Time > RawFromTimespan(pOther);
        }

        public static bool operator >(GameTime pThis, double pOther)
        {
            return pThis.m_Time > pOther;
        }

        public static bool operator >=(GameTime pThis, GameTime pOther)
        {
            return pThis.m_Time >= pOther.m_Time;
        }

        public static bool operator >=(GameTime pThis, TimeSpan pOther)
        {
            return pThis.m_Time >= RawFromTimespan(pOther);
        }

        public static bool operator >=(GameTime pThis, double pOther)
        {
            return pThis.m_Time >= pOther;
        }

        public static implicit operator GameTime(double pValue)
        {
            return new GameTime(pValue);
        }

        public static GameTime operator +(GameTime pThis, GameTime pOther)
        {
            return new GameTime(pThis.m_Time + pOther.m_Time);
        }

        public static GameTime operator +(GameTime pThis, TimeSpan pOther)
        {
            return new GameTime(pThis.m_Time + RawFromTimespan(pOther));
        }

        public static GameTime operator +(GameTime pThis, double pOther)
        {
            return new GameTime(pThis.m_Time + pOther);
        }

        public static GameTime operator -(GameTime pThis, GameTime pOther)
        {
            return new GameTime(pThis.m_Time - pOther.m_Time);
        }

        public static GameTime operator -(GameTime pThis, TimeSpan pOther)
        {
            return new GameTime(pThis.m_Time - RawFromTimespan(pOther));
        }

        public static GameTime operator -(GameTime pThis, double pOther)
        {
            return new GameTime(pThis.m_Time - pOther);
        }

        public override bool Equals(object pObject)
        {
            var castedObject = pObject as GameTime;
            if (castedObject == null)
                return false;

            return Equals(castedObject);
        }

        public bool Equals(GameTime pObject)
        {
            if (pObject == null)
            {
                return false;
            }

            if (ReferenceEquals(this, pObject))
            {
                return true;
            }

            return m_Time.Equals(pObject.m_Time);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (17 * 23) + m_Time.GetHashCode();
            }
        }

        public override string ToString()
        {
            return ToString();
        }

        public string ToString(IFormatProvider pFormatProvider = null)
        {
            return ToString("T d, y H:M:S", pFormatProvider);
        }

        public string ToString(string pFormat, IFormatProvider pFormatProvider = null)
        {
            if (string.IsNullOrEmpty(pFormat))
                return ToString();

            if (pFormatProvider == null)
            {
                pFormatProvider = CultureInfo.CurrentCulture;
            }

            StringBuilder result = new StringBuilder();
            foreach (var character in pFormat)
            {
                switch (character)
                {
                    case 'y':
                        result.Append(Year.ToString("D2", pFormatProvider));
                        break;

                    case 't':
                        result.Append(Season.ToString(string.Format(pFormatProvider, "D{0}", MathTools.DigitCount((int)SEASONS_PER_YEAR)), pFormatProvider));
                        break;

                    case 'T':
                        result.Append(SeasonName);
                        break;

                    case 'd':
                        result.Append(Day.ToString(string.Format(pFormatProvider, "D{0}", MathTools.DigitCount((int)DAYS_PER_SEASON)), pFormatProvider));
                        break;

                    case 'H':
                        result.Append(Hour.ToString(string.Format(pFormatProvider, "D{0}", MathTools.DigitCount((int)HOURS_PER_DAY)), pFormatProvider));
                        break;

                    case 'M':
                        result.Append(Minute.ToString(string.Format(pFormatProvider, "D{0}", MathTools.DigitCount((int)MINUTES_PER_HOUR)), pFormatProvider));
                        break;

                    case 'S':
                        result.Append(Second.ToString(string.Format(pFormatProvider, "D{0}", MathTools.DigitCount((int)SECONDS_PER_MINUTE)), pFormatProvider));
                        break;

                    default:
                        result.Append(character);
                        break;
                }
            }

            return result.ToString();
        }

        public static GameTime FromTimespan(TimeSpan pTime)
        {
            return new GameTime(pTime.TotalSeconds * TIMESPAN_RATIO);
        }

        public static double RawFromTimespan(TimeSpan pTime)
        {
            return pTime.TotalSeconds * TIMESPAN_RATIO;
        }

        public static TimeSpan ToTimespan(GameTime pTime)
        {
            return TimeSpan.FromSeconds(pTime.m_Time / TIMESPAN_RATIO);
        }

        public static TimeSpan ToTimespan(double pTime)
        {
            return TimeSpan.FromSeconds(pTime / TIMESPAN_RATIO);
        }

        public GameTime Clone()
        {
            return new GameTime(this);
        }

        #region Serialization
        public byte[] GetBytes()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(memoryStream))
            {
                writer.Write(Time);
                return memoryStream.ToArray();
            }
        }

        public void Deserialize(byte[] pData)
        {
            using (MemoryStream memoryStream = new MemoryStream(pData))
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                Time = reader.ReadDouble();
            }
        }
        #endregion

        public GameTime(int pYear, int pSeason, int pDay, int pHour, int pMinute, int pSecond)
        {
            m_Time += (MathTools.ClampMin(pYear - 1, 0) * SECONDS_PER_YEAR);
            m_Time += (MathTools.Clamp(pSeason - 1, 0, 3) * SECONDS_PER_SEASON);
            m_Time += (MathTools.Clamp(pDay - 1, 0, 24) * SECONDS_PER_DAY);

            m_Time += (MathTools.Clamp(pHour, 0, 23) * SECONDS_PER_HOUR);
            m_Time += (MathTools.Clamp(pMinute, 0, 59) * SECONDS_PER_MINUTE);
            m_Time += MathTools.Clamp(pSecond, 0, 59);
        }

        public GameTime(int pYear, int pSeason, int pDay)
        {
            m_Time += (pYear - 1) * SECONDS_PER_YEAR;
            m_Time += (MathTools.Clamp(pSeason - 1, 0, 3) * SECONDS_PER_SEASON);
            m_Time += (Mathf.Clamp(pDay - 1, 0, 24) * SECONDS_PER_DAY);
        }

        public GameTime(int pYear, int pDaysInYear)
        {
            m_Time += (pYear - 1) * SECONDS_PER_YEAR;
            m_Time += (Mathf.Clamp(pDaysInYear - 1, 0, 99) * SECONDS_PER_DAY);
        }

        public GameTime(GameTime pCopy)
        {
            m_Time = pCopy.m_Time;
        }

        public GameTime(TimeSpan pValue)
        {
            m_Time = RawFromTimespan(pValue);
        }

        public GameTime(double pValue)
        {
            m_Time = pValue;
        }

        public GameTime()
        {
        }

        static GameTime()
        {

            SECONDS_PER_MINUTE = m_Data.SecondsPerMinute;
            SECONDS_PER_HOUR = SECONDS_PER_MINUTE * m_Data.MinutesPerHour;
            SECONDS_PER_DAY = SECONDS_PER_HOUR * m_Data.HoursPerDay;
            SECONDS_PER_SEASON = SECONDS_PER_DAY * m_Data.DaysPerSeason;
            SECONDS_PER_YEAR = SECONDS_PER_SEASON * m_Data.SeasonsPerYear;

            SEASONS_PER_YEAR = SECONDS_PER_YEAR / SECONDS_PER_SEASON;
            DAYS_PER_SEASON = SECONDS_PER_SEASON / SECONDS_PER_DAY;
            HOURS_PER_DAY = SECONDS_PER_DAY / SECONDS_PER_HOUR;
            MINUTES_PER_HOUR = SECONDS_PER_HOUR / SECONDS_PER_MINUTE;

            TIMESPAN_RATIO = SECONDS_PER_DAY / TimeSpan.FromDays(1d).TotalSeconds;
        }
    }
}

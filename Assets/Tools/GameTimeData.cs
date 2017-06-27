using System;
using System.Xml.Serialization;
using Assets.Scripts.Misc;


namespace Assets.Scripts.InGameTime
{
    [Serializable, XmlType("GameTimeData")]
    public class GameTimeData
    {
        private double m_SecondsPerMinute = 60d;
        private double m_MinutesPerHour = 60d;
        private double m_HoursPerDay = 24d;
        private double m_DaysPerSeason = 50d;
        private double m_SeasonsPerYear = 1d;

        [XmlAttribute("SecondsPerMinute")]
        public double SecondsPerMinute
        {
            get { return m_SecondsPerMinute; }
            set { m_SecondsPerMinute = value; }
        }

        [XmlAttribute("MinutesPerHour")]
        public double MinutesPerHour
        {
            get { return m_MinutesPerHour; }
            set { m_MinutesPerHour = value; }
        }

        [XmlAttribute("HoursPerDay")]
        public double HoursPerDay
        {
            get { return m_HoursPerDay; }
            set { m_HoursPerDay = value; }
        }

        [XmlAttribute("DaysPerSeason")]
        public double DaysPerSeason
        {
            get { return m_DaysPerSeason; }
            set { m_DaysPerSeason = value; }
        }

        [XmlAttribute("SeasonsPerYear")]
        public double SeasonsPerYear
        {
            get { return m_SeasonsPerYear; }
            set { m_SeasonsPerYear = value; }
        }

        public static GameTimeData Load(string pFilename)
        {
            return XMLParser.Load<GameTimeData>(pFilename);
        }

        public static void Save(string pFilename, GameTimeData pData)
        {
            XMLParser.Save(pFilename, pData);
        }

        public static void WriteXMLTemplate(string pFilename)
        {
            XMLParser.Save(pFilename, new GameTimeData());
        }

        public GameTimeData()
        {
        }
    }
}


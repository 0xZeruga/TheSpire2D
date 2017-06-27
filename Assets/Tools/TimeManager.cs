using System;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.InGameTime;



namespace Assets
{
    public class TimeManager : MonoBehaviour
    {
        [Serializable]
        public class TimeManagerEvent : UnityEvent<GameTime> { }

        private GameTime m_Time;
        private GameTime m_LastTime;

        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float m_TimeScale = 1.0f;

        [SerializeField]
        [Range(0.0f, 3600.0f)]
        private float m_TimeStep = 1.0f;

        [Header("Events")]
        public TimeManagerEvent OnPauseEvent = new TimeManagerEvent();
        public TimeManagerEvent OnUnpauseEvent = new TimeManagerEvent();
        public TimeManagerEvent OnTickEvent = new TimeManagerEvent();
        public TimeManagerEvent OnSecondChangedEvent = new TimeManagerEvent();
        public TimeManagerEvent OnMinuteChangedEvent = new TimeManagerEvent();
        public TimeManagerEvent OnHourChangedEvent = new TimeManagerEvent();
        public TimeManagerEvent OnDayChangedEvent = new TimeManagerEvent();
        public TimeManagerEvent OnSeasonChangedEvent = new TimeManagerEvent();
        public TimeManagerEvent OnYearChangedEvent = new TimeManagerEvent();

        public GameTime Now
        {
            get { return m_Time; }
            set { m_Time = value; }
        }

        public float TimeScale
        {
            get { return m_TimeScale; }
            set
            {
                if (value < 0.0f)
                {
                    UnityEngine.Time.timeScale = m_TimeScale = 0.0f;
                }
                else
                {
                    UnityEngine.Time.timeScale = m_TimeScale = value;
                }
            }
        }

        public float TimeStep
        {
            get { return m_TimeStep; }
            set { m_TimeStep = value; }
        }

        public float DeltaTime
        {
            get { return UnityEngine.Time.deltaTime * m_TimeStep; }
        }

        public float FixedDeltaTime
        {
            get { return UnityEngine.Time.fixedDeltaTime * m_TimeStep; }
        }

        public bool Paused
        {
            get { return (UnityEngine.Time.timeScale <= 0.0f); }
            set
            {
                if (value)
                {
                    UnityEngine.Time.timeScale = 0.0f;

                    if (OnPauseEvent != null)
                    {
                        OnPauseEvent.Invoke(m_Time);
                    }
                }
                else
                {
                    UnityEngine.Time.timeScale = m_TimeScale;

                    if (OnUnpauseEvent != null)
                    {
                        OnUnpauseEvent.Invoke(m_Time);
                    }
                }
            }
        }

        public void Awake()
        {
            Paused = true;

            m_Time = new GameTime(0d);
            m_LastTime = m_Time.Clone();
        }

        public void Update()
        {
            if (Paused)
                return;

            m_Time.AttachSeconds(DeltaTime);
            if (OnTickEvent != null)
            {
                OnTickEvent.Invoke(m_Time);
            }

            TriggerTimedEvents();
            m_LastTime = m_Time.Clone();
        }

        public void TriggerTimedEvents()
        {
            /*PartOfDay partOfDay;
            if((partOfDay = m_Time.GetPartOfDay()) != m_LastTime.GetPartOfDay()) {
                switch(partOfDay) {
                    case PartOfDay.DAYTIME:
                        if(m_OnDaytimeEvent != null) {
                            m_OnDaytimeEvent.Invoke(m_Time);
                        }

                        break;
                    case PartOfDay.AFTERNOON:
                        if(m_OnAfternoonEvent != null) {
                            m_OnAfternoonEvent.Invoke(m_Time);
                        }

                        break;
                    case PartOfDay.NIGHTTIME:
                        if(m_OnNighttimeEvent != null) {
                            m_OnNighttimeEvent.Invoke(m_Time);
                        }

                        break;
                }
            }*/

            if (OnSecondChangedEvent != null && m_Time.CompareSecond(m_LastTime) > 0)
            {
                OnSecondChangedEvent.Invoke(m_Time);
            }

            if (OnMinuteChangedEvent != null && m_Time.CompareMinute(m_LastTime) > 0)
            {
                OnMinuteChangedEvent.Invoke(m_Time);
            }

            if (OnHourChangedEvent != null && m_Time.CompareHour(m_LastTime) > 0)
            {
                OnHourChangedEvent.Invoke(m_Time);
            }

            if (OnDayChangedEvent != null && m_Time.CompareDay(m_LastTime) > 0)
            {
                OnDayChangedEvent.Invoke(m_Time);
            }

            if (OnSeasonChangedEvent != null && m_Time.CompareSeason(m_LastTime) > 0)
            {
                OnSeasonChangedEvent.Invoke(m_Time);
            }

            if (OnYearChangedEvent != null && m_Time.CompareYear(m_LastTime) > 0)
            {
                OnYearChangedEvent.Invoke(m_Time);
            }
        }

        public void Jump(TimeSpan pTimeSpan)
        {
            TimeSpan day = new TimeSpan(1, 0, 0, 0);

            while (pTimeSpan.Days > 0)
            {
                m_Time += day;
                TriggerTimedEvents();

                m_LastTime = m_Time;
                pTimeSpan -= day;
            }

            m_Time.Attach(day);
            TriggerTimedEvents();

            m_LastTime = m_Time;
        }

        /* SetPauseState(bool)
         * Call this to pause/unpause TimeManager to bypass OnPause/OnUnpause events, otherwise call Paused property
         */
        public void SetPauseState(bool pPaused)
        {
            UnityEngine.Time.timeScale = (pPaused ? 0.0f : m_TimeScale);
        }
    }
}

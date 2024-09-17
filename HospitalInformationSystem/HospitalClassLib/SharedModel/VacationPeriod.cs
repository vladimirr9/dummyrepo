﻿using System;

namespace HospitalClassLib.SharedModel
{
    public class VacationPeriod
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public VacationPeriod()
        {

        }

        public VacationPeriod(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}

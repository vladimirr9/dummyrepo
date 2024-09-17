﻿
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.SharedModel
{
    public class Receipt
    {
        

        public String MedicineName { get; set; }
        public String Amount { get; set; }
        public String Diagnosis { get; set; }
        public String RecieptID { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }

        public Receipt()
        {
            RecieptID = DateTime.Now.ToString("yyMMddhhmmss");
        }

        public Receipt(Doctor doctor, Patient patient, String medicineName, String amount, String diagnosis)
        {
            Doctor = doctor;
            Patient = patient;
            MedicineName = medicineName;
            Amount = amount;
            Diagnosis = diagnosis;

            RecieptID = DateTime.Now.ToString("yyMMddhhmmss");
            Date = DateTime.Today;

        }   

        public String GetDoctorName() 
        { 
            return Doctor.FullName; 
        }

        public String GetPatientName() 
        { 
            return Patient.FullName;
        }

        public String GetRecieptDateString() 
        { 
            return Date.ToString("dd.MM.yyyy.");
        }

        public String NameAndQuantity { get { return (MedicineName + " " + Amount); } }

        

    }
}

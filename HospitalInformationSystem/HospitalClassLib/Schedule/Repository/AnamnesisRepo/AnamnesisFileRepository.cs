﻿
using HospitalClassLib.HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace HospitalClassLib.Schedule.Repository.AnamnesisRepository
{
    public class AnamnesisFileRepository : GenericFileRepository<string, Anamnesis, AnamnesisFileRepository>,IAnamnesisRepository
    {
        protected override string getKey(Anamnesis entity)
        {
            return entity.AnamnesisID;
        }

        protected override string getPath()
        {
            return @".\..\..\..\Data\anamneze.json";
        }

        protected override void RemoveReferences(string key)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> ReadByPatient(Patient patient)
        {
            List<Anamnesis> retVal = new List<Anamnesis>();

            foreach (Anamnesis a in this.GetAll())
            {
                

                if (a.AnamnesisAppointment.Patient.Jmbg == patient.Jmbg)
                    retVal.Add(a);
            }

            return retVal;
        }

        protected override void ShouldSerialize(Anamnesis entity)
        {
            
        }
    }
}

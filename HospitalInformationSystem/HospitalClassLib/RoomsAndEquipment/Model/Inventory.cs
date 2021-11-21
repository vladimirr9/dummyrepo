﻿using System;
using System.Collections.Generic;
using System.Text;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;


namespace HospitalClassLib.RoomsAndEquipment.Model
{
    public class Inventory
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public InventoryType Type { get; set; }
        public string RoomNumber { get; set; } //neophodno za bindovanje

        public Inventory()
        {
            Name = "";
            ID = "";
            Type = InventoryType.statička;
        }

        public Inventory(string naziv, string id, InventoryType TipOpreme)
        {
            this.Name = naziv;
            this.ID = id;
            this.Type = TipOpreme;
        }

        

        public string TypeToString
        {
            get
            {
                return Conversion.InventoryTypeToString(Type);
            }
        }

    }
}

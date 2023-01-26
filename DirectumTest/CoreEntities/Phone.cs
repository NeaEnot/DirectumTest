using DirectumTest.Abstracts;
using System;
using System.Collections.Generic;

namespace DirectumTest.CoreEntities
{
    internal class Phone
    {
        public readonly ulong IMEI;

        public ulong? Sim { get; set; }
        private Dictionary<string, ulong> contacts;

        private BaseStation baseStation;
        private NetworkMediator network;

        public Phone(ulong imei, NetworkMediator network)
        {
            contacts = new Dictionary<string, ulong>();

            IMEI = imei;
            this.network = network;
        }

        public void ConnectToBaseStation()
        {
            if (Sim.HasValue)
            {
                if (baseStation != null)
                    baseStation.UnegisterPhone(this);

                baseStation = network.FindBaseStation(this);
                baseStation.RegisterPhone(this);
            }
        }

        public void Call(ulong number)
        {
            if (Sim.HasValue)
                baseStation.Call(Sim.Value, number);
        }

        public void Call(string contact)
        {
            Call(contacts[contact]);
        }
    }
}

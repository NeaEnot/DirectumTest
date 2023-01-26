using DirectumTest.Abstracts;
using System.Collections.Generic;

namespace DirectumTest.CoreEntities
{
    internal class BaseStation
    {
        private Dictionary<ulong, Phone> phones;
        private NetworkMediator network;

        public BaseStation(NetworkMediator network)
        {
            phones = new Dictionary<ulong, Phone>();
            this.network = network;

            network.RegisterBaseStation(this);
        }

        public virtual void RegisterPhone(Phone phone)
        {
            if (!phones.ContainsKey(phone.Sim.Value))
                phones.Add(phone.Sim.Value, phone);
        }

        public virtual void UnegisterPhone(Phone phone)
        {
            if (phones.ContainsKey(phone.Sim.Value))
                phones.Remove(phone.Sim.Value);
        }

        public virtual bool IsPhoneRegistred(ulong phoneNumber)
            => phones.ContainsKey(phoneNumber);

        public void Call(ulong outgoingPhoneNumber, ulong incomingPhoneNumber)
        {
            if (IsPhoneRegistred(incomingPhoneNumber))
            {
                // Какая-то логика, возможно возврат объекта звонка.
            }
            else
            {
                BaseStation incomingBaseStation = network.FindBaseStationForPhone(incomingPhoneNumber);
                incomingBaseStation.Call(outgoingPhoneNumber, incomingPhoneNumber);
            }
        }
    }
}

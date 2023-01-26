using DirectumTest.Abstracts;
using System.Collections.Generic;

namespace DirectumTest.CoreEntities
{
    internal class BaseStation3g : BaseStation
    {
        private Dictionary<ulong, Phone3g> phones3g;

        public BaseStation3g(NetworkMediator network) : base(network)
        {
            phones3g = new Dictionary<ulong, Phone3g>();
        }

        public override void RegisterPhone(Phone phone)
        {
            if (phone is Phone3g)
                if (!phones3g.ContainsKey(phone.Sim.Value))
                    phones3g.Add(phone.Sim.Value, phone as Phone3g);
            else
                base.RegisterPhone(phone);
        }

        public override void UnegisterPhone(Phone phone)
        {
            if (phones3g.ContainsKey(phone.Sim.Value))
                phones3g.Remove(phone.Sim.Value);
            else
                base.UnegisterPhone(phone);
        }

        public override bool IsPhoneRegistred(ulong phoneNumber)
        {
            bool isRegistred = phones3g.ContainsKey(phoneNumber);

            if (!isRegistred)
                isRegistred = base.IsPhoneRegistred(phoneNumber);

            return isRegistred;
        }
    }
}

using DirectumTest.CoreEntities;
using System;
using System.Collections.Generic;

namespace DirectumTest.Abstracts
{
    internal class NetworkMediator
    {
        private static Random random = new Random();

        private List<BaseStation> baseStations;

        public NetworkMediator()
        {
            baseStations = new List<BaseStation>();
        }

        public void RegisterBaseStation(BaseStation baseStation)
        {
            if (!baseStations.Contains(baseStation))
                baseStations.Add(baseStation);
        }

        public BaseStation FindBaseStation(Phone phone)
        {
            // Допустим тут хитрый алгоритм, может даже подбирает 3g станцию для 3g телефона
            BaseStation baseStation = baseStations[random.Next(0, baseStations.Count)];
            return baseStation;
        }

        public BaseStation FindBaseStationForPhone(ulong phoneNumber)
        {
            foreach (BaseStation baseStation in baseStations)
                if (baseStation.IsPhoneRegistred(phoneNumber))
                    return baseStation;

            throw new KeyNotFoundException();
        }
    }
}

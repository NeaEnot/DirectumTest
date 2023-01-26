using DirectumTest.Abstracts;

namespace DirectumTest.CoreEntities
{
    internal class Phone3g : Phone
    {
        public Phone3g(ulong imei, NetworkMediator network) : base(imei, network)
        { }
    }
}

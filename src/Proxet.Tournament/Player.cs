using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxet.Tournament
{
    internal class Player
    {
        public string Name { get; }
        public int WaitTimeSec { get; }
        public int VehicleType { get; }
        public Player(string name, int waitTimeSec, int vehicleType)
        {
            Name = name;
            WaitTimeSec = waitTimeSec;
            VehicleType = vehicleType;
        }
    }
}

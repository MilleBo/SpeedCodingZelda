//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using LetsCreateZelda.UWP.Components;

namespace LetsCreateZelda.UWP.Factories
{
    public static class FactoryStats
    {
        private static List<Stats> _stats;  

        public static void Initialize()
        {
            _stats = new List<Stats>();
            XMLSerialization.LoadXML(out _stats, "Content/stats.xml"); 
        }

        public static Stats GetStats(string statsId)
        {
            if(_stats == null)
                return new Stats("",0,0,0,0);
            return (Stats) _stats.FirstOrDefault(s => s.StatsId.Equals(statsId)).Clone();
        }
    }
}




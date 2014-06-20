//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - https://www.youtube.com/user/Maloooon
//------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components;

namespace LetsCreateZelda.Factories
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
                return new Stats("",0,0,0);
            return (Stats) _stats.FirstOrDefault(s => s.StatsId.Equals(statsId)).Clone();
        }
    }
}




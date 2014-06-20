using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LetsCreateZelda.Editor.Common
{
    public static class DirectoryUtility
    {
        public static void EnsureDirectory(string directoryName)
        {
            var path = string.Format("{0}/Content/Maps/{1}", Directory.GetCurrentDirectory(), directoryName);
            if (!string.IsNullOrEmpty(directoryName) &&
                !Directory.Exists(path))
            {
                Directory.CreateDirectory(path); 
            }
        }
    }
}


//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------



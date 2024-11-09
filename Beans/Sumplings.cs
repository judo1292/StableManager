using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace StableManager.Beans
{
    class Sumplings
    {
        private string[] _sumpling;
        private List<string> _sumplingList;
        public Sumplings()
        {
            SumplingList = new List<string>();
            _sumpling = new string[] {
            "Euler a",
            "Euler",
            "LMS",
            "Heun",
            "DPM2",
            "DPM2 a",
            "DPM++ 2S a",
            "DPM++ 2M",
            "DPM++ SDE",
            "DPM fast",
            "DPM adaptive",
            "LMS Karras",
            "DPM2 Karras",
            "DPM2 a Karras",
            "DPM++ 2S a Karras",
            "DPM++ 2M Karras",
            "DPM++ SDE Karras",
            "DDIM",
            "PLMS",
            "UniPC"
            };
            foreach(string sumple in _sumpling)
            {
                _sumplingList.Add(sumple);
            }
        }

        public string[] Sumpling { get => _sumpling; set => _sumpling = value; }
        public List<string> SumplingList { get => _sumplingList; set => _sumplingList = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
    [System.Serializable]
    public class Endings
    {
        public bool[] _achieved;
        public Endings() => _achieved = new bool[0];
        
    }
}
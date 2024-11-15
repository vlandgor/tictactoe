using System;
using UnityEngine;

namespace Runtime.Marks
{
    [Serializable]
    public class MarkSet
    {
        [SerializeField] private Mark _xMark;
        public Mark XMark => _xMark;
        
        [SerializeField] private Mark _oMark;
        public Mark OMark => _oMark;
    }
}
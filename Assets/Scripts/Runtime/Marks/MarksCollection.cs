using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Marks
{
    [CreateAssetMenu(fileName = "TokenStorage", menuName = "Playcbo/Storages/Token Storage", order = 0)]
    public class MarksCollection : ScriptableObject
    {
        public List<MarkSet> marks = new();
        
        public MarkSet GetRandomMarkSet()
        {
            return marks[Random.Range(0, marks.Count)];
        }
    }
}
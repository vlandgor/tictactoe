using UnityEngine;

namespace Runtime.Marks
{
    public class MarksProvider : MonoBehaviour, IMarksProvider
    {
        [SerializeField] private MarksCollection marksCollection;
        
        public MarkSet GetRandomMarkSet()
        {
            return marksCollection.GetRandomMarkSet();
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.GamePieces
{
    [CreateAssetMenu(fileName = "PiecesStorage", menuName = "Playcbo/Storages/Pieces Storage", order = 0)]
    public class PiecesStorage : ScriptableObject
    {
        [SerializeField] private List<PieceSet> pieceSets = new();
        
        public PieceSet GetSet(int index)
        {
            return pieceSets[index];
        }

        public PieceSet GetRandomSet()
        {
            return pieceSets[Random.Range(0, pieceSets.Count)];
        }
    }
}
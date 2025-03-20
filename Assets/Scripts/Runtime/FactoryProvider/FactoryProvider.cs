using Runtime.BoardManager;
using Runtime.GamePieces;
using Runtime.UI;
using UnityEngine;

namespace Runtime.FactoryProvider
{
    public class FactoryProvider : MonoBehaviour
    {
        [SerializeField] private PiecesFactory _piecesFactory;
        public PiecesFactory PiecesFactory => _piecesFactory;
        
        [SerializeField] private TilesFactory _tilesFactory;
        public TilesFactory TilesFactory => _tilesFactory;
        
        [SerializeField] private ViewsFactory _viewsFactory;
        public ViewsFactory ViewsFactory => _viewsFactory;
    }
}
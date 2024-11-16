using System;
using Runtime.GameBoard;

namespace Runtime.InputService
{
    public interface IInputService
    {
        public event Action<Crd> OnTileClicked;
        
        public bool IsInputEnabled { get; }
        
        public void SetInputEnabled(bool enable);
    }
}
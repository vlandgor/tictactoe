using System;
using Runtime.GameBoard;

namespace Runtime.InputService
{
    public interface IInputService
    {
        public event Action<Crd> OnTileClicked;
        
        public void SetInputEnabled(bool enable);
    }
}
using System;

namespace Runtime.InputService
{
    public interface IInputService
    {
        public event Action<int, int> OnTileClicked;
    }
}
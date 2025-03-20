using Runtime.BoardManager.Local;
using Unity.Netcode;

namespace Runtime.BoardManager
{
    public struct NetworkBoardPosition : INetworkSerializable
    {
        public BoardPosition Position;

        // Constructor
        public NetworkBoardPosition(BoardPosition position)
        {
            Position = position;
        }

        // Implicit conversion for convenience
        public static implicit operator BoardPosition(NetworkBoardPosition networkPosition)
            => networkPosition.Position;

        public static implicit operator NetworkBoardPosition(BoardPosition position)
            => new NetworkBoardPosition(position);

        // Required by INetworkSerializable to serialize across network
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Position.x);
            serializer.SerializeValue(ref Position.y);
        }

        // Convenience methods/properties (optional)
        public override string ToString() => Position.ToString();
    }
}
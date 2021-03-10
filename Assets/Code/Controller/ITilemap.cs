using UnityEngine;


namespace JevLogin
{
    public interface ITilemap
    {
        int Count { get; }
        int Height { get; }
        int Width { get; }
        ICell GetCell(Vector2Int position);
    } 
}
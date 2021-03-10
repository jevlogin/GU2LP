using UnityEngine;
using System.Linq;


namespace JevLogin
{
    public sealed class HeightMapBasedTilemap : ITilemap
    {
        private int[] _heights;

        public int Count => _heights.Sum();

        public int Height => _heights.Max();

        public int Width => _heights.Length;

        private ICell _cell;

        public HeightMapBasedTilemap(int width, ICell cell)
        {
            _heights = new int[width];
            _cell = cell;
        }

        public void SetHeight(int x, int value)
        {
            if (x < 0 && x >= _heights.Length)
            {
                throw new System.ArgumentOutOfRangeException($"x");
            }
            _heights[x] = value;
        }

        public ICell GetCell(Vector2Int position)
        {
            if (position.x < 0 && position.x >= _heights.Length)
            {
                throw new System.ArgumentOutOfRangeException($"x");
            }
            if (position.y > _heights[position.x])
            {
                return null;
            }
            else
            {
                return _cell;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;


namespace JevLogin
{
    public sealed class GenerateLevelView : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _tileMapGround;

        [SerializeField]
        private Tile _tileGround;

        [SerializeField]
        private int _widthMap;

        [SerializeField]
        private int _heightMap;

        [SerializeField]
        private int factorSmooth;

        [SerializeField, Range(0, 100)]
        private int _randomFillPercent;

        public Tilemap TileMapGround => _tileMapGround;
        public Tile TileGround { get => _tileGround; }
        public int WidthMap { get => _widthMap; }
        public int HeightMap { get => _heightMap; }
        public int FactorSmooth { get => factorSmooth; }
        public int RandomFillPercent { get => _randomFillPercent; }
    }
}
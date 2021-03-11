using UnityEngine;


namespace JevLogin
{
    public sealed class TerrainGenerator : MonoBehaviour
    {
        [SerializeField] private int _height;
        [SerializeField] private int _width;
        [SerializeField] private int _widthMinimalPlatform;
        [SerializeField] private GroundTile _groundTile;
        [SerializeField] private bool _isGenerateOnStart = false;
        private TilemapRender _tilemapRender;

        private void Start()
        {
            if (_isGenerateOnStart)
            {
                GenerateAndRenderer(); 
            }
        }

        public void GenerateAndRenderer()
        {
            var tileMap = Cenerate();
            _tilemapRender = GetComponent<TilemapRender>();
            _tilemapRender.Render(tileMap);
            //gameObject.GetOrAddComponent<PolygonCollider2D>().points = tileMap.GetClosedMesh();
        }

        public void Clear()
        {
            _tilemapRender.Clear();
        }

        private ITilemap Cenerate()
        {
            int groundHeight = _height;

            var tilemap = new HeightMapBasedTilemap(_width, _groundTile);

            for (int x = 0; x < _width; x++)
            {
                if (x % _widthMinimalPlatform == 0)
                {
                    groundHeight += Random.Range(-1, 2);
                }

                tilemap.SetHeight(x, groundHeight);
            }

            return tilemap;
        }
    }
}

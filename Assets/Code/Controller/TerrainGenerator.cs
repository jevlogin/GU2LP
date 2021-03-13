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

        [SerializeField] private VariantCollider _variantCollider;

        private PolygonCollider2D _polygonCollider2D;
        private Rigidbody2D _rigidbody2D;
        private CompositeCollider2D _compositeCollider2D;
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

            if (_variantCollider == VariantCollider.CompositeCollider2D)
            {
                _tilemapRender.Render(tileMap, _variantCollider);
                _compositeCollider2D = gameObject.GetOrAddComponent<CompositeCollider2D>();
                _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
                _rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
            else if (_variantCollider == VariantCollider.PolygonCollider2D)
            {
                _tilemapRender.Render(tileMap, _variantCollider);
                _polygonCollider2D = gameObject.GetOrAddComponent<PolygonCollider2D>();
                _polygonCollider2D.points = tileMap.GetClosedMesh();
            }
            else if (_variantCollider == VariantCollider.None)
            {
                _tilemapRender.Render(tileMap, _variantCollider);
            }
        }

        public void Clear()
        {
            if (_polygonCollider2D != null)
            {
#if UNITY_EDITOR
                DestroyImmediate(_polygonCollider2D);
#else
                Destroy(_polygonCollider2D);
#endif
            }
            if (_compositeCollider2D != null)
            {
#if UNITY_EDITOR
                DestroyImmediate(_compositeCollider2D);
#else
                Destroy(_compositeCollider2D);
#endif
            }
            if (_rigidbody2D != null)
            {
#if UNITY_EDITOR
                DestroyImmediate(_rigidbody2D);
#else
                Destroy(_rigidbody2D);
#endif
            }

            _tilemapRender.Clear();
        }

        private ITilemap Cenerate()
        {
            Clear();

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

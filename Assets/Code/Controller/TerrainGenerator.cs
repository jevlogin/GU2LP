using UnityEngine;


namespace JevLogin
{
    public sealed class TerrainGenerator : MonoBehaviour
    {
        [SerializeField] private int _height;
        [SerializeField] private int _width;
        [SerializeField] private int _widthMinimalPlatform;
        [SerializeField] private GroundTile _groundTile;

        private void Start()
        {
           var tileMap =  Cenerate();
            GetComponent<TilemapRender>().Render(tileMap);
        }


        public ITilemap Cenerate()
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

                //for (int y = groundHeight; y > 0; y--)
                //{
                //    var cell = Instantiate(Cell, Zero);
                //    cell.transform.localPosition = new Vector3(x, y, 0.0f);
                //}
            }

            return tilemap;
        }
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;


namespace JevLogin
{
    public sealed class MarchingSquaresGeneratorLevel
    {
        private SquareGrid _squareGrid;
        private Tilemap _tilemapMapGround;
        private Tile _tileGround;

        public void GenerateGrid(int[,] map, float squareSize)
        {
            _squareGrid = new SquareGrid(map, squareSize);
        }

        public void DrawTilesOnMap(Tilemap tilemapGround, Tile tileGround)
        {
            if (_squareGrid == null)
            {
                return;
            }

            _tilemapMapGround = tilemapGround;
            _tileGround = tileGround;

            for (var x = 0; x < _squareGrid.Squares.GetLength(0); x++)
            {
                for (var y = 0; y < _squareGrid.Squares.GetLength(1); y++)
                {
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopLeft.Active, _squareGrid.Squares[x, y].TopLeft.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopRight.Active, _squareGrid.Squares[x, y].TopRight.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomLeft.Active, _squareGrid.Squares[x, y].BottomLeft.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomRight.Active, _squareGrid.Squares[x, y].BottomRight.Position);
                }
            }
        }

        private void DrawTileInControlNode(bool active, Vector3 position)
        {
            if (active)
            {
                var positionTile = new Vector3Int((int)position.x, (int)position.y, 0);
                _tilemapMapGround.SetTile(positionTile, _tileGround);
            }
        }
    }
}
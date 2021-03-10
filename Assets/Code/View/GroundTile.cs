using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(menuName = "Data/GroundTile", fileName = "GroundTile", order = 51)]
    public sealed class GroundTile : ScriptableObject, ICell
    {
        [Header("Базовый спрайт одна ячейка")]
        public Sprite Grass;

        [Header("Базовый спрайт"), Space(20)]
        public Sprite Left;
        public Sprite Middle;
        public Sprite Right;

        [Header("Базовый спрайт снизу"), Space(20)]
        public Sprite Dirt;
        public Sprite DirtDown;

        [Header("Левая часть земля"), Space(20)]
        public Sprite DirtLeft;
        public Sprite DirtLeftCorner;

        [Header("Правая часть земля"), Space(20)]
        public Sprite DirtRight;
        public Sprite DirtRightCorner;

        [Header("Левая часть трава + земля"), Space(20)]
        public Sprite GrassHillLeft;
        public Sprite GrassHillLeft2;
        public Sprite GrassHillLeft2_DownShadow;

        [Header("Правая часть трава + земля"), Space(20)]
        public Sprite GrassHillRight;
        public Sprite GrassHillRight2;
        public Sprite GrassHillRight2_DownShadow;


        public void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject)
        {
            var render = gameObject.GetComponent<SpriteRenderer>();
            render.sprite = Dirt;

            if (Exist(position + Vector2Int.right, tilemap) &&
                Exist(position + Vector2Int.left, tilemap) &&
                !Exist(position + Vector2Int.up, tilemap))
            {
                render.sprite = Middle;
                gameObject.GetOrAddComponent<BoxCollider2D>();
            }
            else if (Exist(position + Vector2Int.right, tilemap) &&
                !Exist(position + Vector2Int.left, tilemap) &&
                !Exist(position + Vector2Int.up, tilemap))
            {
                render.sprite = Left;
                gameObject.GetOrAddComponent<BoxCollider2D>();
            }
            else if (!Exist(position + Vector2Int.right, tilemap) &&
               Exist(position + Vector2Int.left, tilemap) &&
               !Exist(position + Vector2Int.up, tilemap))
            {
                render.sprite = Right;
                gameObject.GetOrAddComponent<BoxCollider2D>();
            }
        }

        private bool Exist(Vector2Int position, ITilemap tilemap)
        {
            if (position.x < 0 || position.x >= tilemap.Width)
            {
                return false;
            }

            var tile = tilemap.GetCell(position);

            return tile != null;
        }
    }
}
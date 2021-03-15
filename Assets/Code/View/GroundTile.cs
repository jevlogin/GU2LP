using System.Collections.Generic;
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

        [SerializeField, Header("Материал для склона - скольжение"), Space(5)] private PhysicsMaterial2D _physicsMaterial2D;

        [SerializeField, Header("префабы окружения, трава, деревья, кустики"), Space(5)]
        private List<EnvironmentView> _environmentsView = new List<EnvironmentView>();


        public void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject, VariantCollider variantCollider)
        {
            var render = gameObject.GetComponent<SpriteRenderer>();
            render.sprite = Dirt;

            if (Exist(position + Vector2Int.right, tilemap) &&
                Exist(position + Vector2Int.left, tilemap) &&
                !Exist(position + Vector2Int.up, tilemap))
            {
                render.sprite = Middle;
                if (variantCollider == VariantCollider.CompositeCollider2D || variantCollider == VariantCollider.None)
                {
                    AddBoxCollider(gameObject, variantCollider);
                }

                if (Exist(position + Vector2Int.right * 2, tilemap) &&
                    Exist(position + Vector2Int.left * 2, tilemap) &&
                    !Exist(position + Vector2Int.up + Vector2Int.left, tilemap) &&
                    !Exist(position + Vector2Int.up + Vector2Int.right, tilemap))
                {
                    var random = Random.Range(0, _environmentsView.Count);
                    var environments = Instantiate(_environmentsView[random], render.transform);
                    environments.transform.position = render.transform.position.Change(y: render.transform.position.y + environments.Offset);
                }
            }
            else if (Exist(position + Vector2Int.right, tilemap) &&
                !Exist(position + Vector2Int.left, tilemap) &&
                !Exist(position + Vector2Int.up, tilemap))
            {
                render.sprite = GrassHillLeft;

                if (variantCollider == VariantCollider.CompositeCollider2D || variantCollider == VariantCollider.None)
                {
                    AddPoliginCollider(gameObject, variantCollider);
                }
            }
            else if (Exist(position + Vector2Int.right, tilemap) &&
                Exist(position + Vector2Int.left, tilemap) &&
                !Exist(position + Vector2Int.up + Vector2Int.left, tilemap))
            {
                render.sprite = GrassHillLeft2;
            }
            else if (!Exist(position + Vector2Int.right, tilemap) &&
               Exist(position + Vector2Int.left, tilemap) &&
               !Exist(position + Vector2Int.up, tilemap))
            {
                render.sprite = GrassHillRight;

                if (variantCollider == VariantCollider.CompositeCollider2D || variantCollider == VariantCollider.None)
                {
                    AddPoliginCollider(gameObject, variantCollider);
                }
            }
            else if (Exist(position + Vector2Int.right, tilemap) &&
               Exist(position + Vector2Int.left, tilemap) &&
               !Exist(position + Vector2Int.up + Vector2Int.right, tilemap))
            {
                render.sprite = GrassHillRight2;
            }
        }

        private void AddPoliginCollider(GameObject gameObject, VariantCollider variantCollider)
        {
            var polygonCollider = gameObject.GetOrAddComponent<PolygonCollider2D>();
            polygonCollider.sharedMaterial = _physicsMaterial2D;
            if (variantCollider == VariantCollider.CompositeCollider2D)
            {
                polygonCollider.usedByComposite = true;
            }
        }

        private static void AddBoxCollider(GameObject gameObject, VariantCollider variantCollider)
        {
            var collider = gameObject.GetOrAddComponent<BoxCollider2D>();
            if (variantCollider == VariantCollider.CompositeCollider2D)
            {
                collider.usedByComposite = true;
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
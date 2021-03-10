using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class TilemapRender : MonoBehaviour
    {
        public void Render(ITilemap tilemap)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int x = 0; x < tilemap.Width; x++)
            {
                for (int y = 0; y < tilemap.Height; y++)
                {
                    var cell = tilemap.GetCell(new Vector2Int(x, y));

                    if (cell != null)
                    {
                        GameObject cellGo = CreateEmpty(new Vector2Int(x, y));

                        cell.Refresh(new Vector2Int(x, y), tilemap, cellGo);
                    }
                }
            }
        }

        public GameObject CreateEmpty(Vector2Int position)
        {
            var result = new GameObject(position.ToString());
            var transform = result.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();
            transform.localPosition = new Vector3(position.x, position.y, 0.0f);

            result.GetOrAddComponent<SpriteRenderer>().sortingOrder = 1;

            return result;
        }
    }
}
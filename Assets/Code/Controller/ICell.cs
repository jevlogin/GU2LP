using UnityEngine;


namespace JevLogin
{
    public interface ICell
    {
        void Refresh(Vector2Int vector2Int, ITilemap tilemap, GameObject gameObject, VariantCollider _variantCollider);
    } 
}

using UnityEngine;


namespace JevLogin
{
    public static class Extentions
    {
        #region Vector

        public static Vector3 Change(this Vector3 vector3, object x = null, object y = null, object z = null)
        {
            return new Vector3(x == null ? vector3.x : (float)x, y == null ? vector3.y : (float)y, z == null ? vector3.z : (float)z);
        }

        public static Vector2 Change(this Vector2 vector2, object x = null, object y = null)
        {
            return new Vector2(x == null ? vector2.x : (float)x, y == null ? vector2.y : (float)y);
        }

        #endregion


        #region GameObject

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        public static GameObject AddCircleCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<CircleCollider2D>();
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<Rigidbody2D>();
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }

        #endregion
    }
}

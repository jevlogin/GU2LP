using UnityEngine;
using UnityEditor;


namespace JevLogin
{
    [CustomEditor(typeof(TerrainGenerator))]
    public sealed class TerrainGeneratorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            TerrainGenerator target = base.target as TerrainGenerator;

            base.OnInspectorGUI();

            if (GUILayout.Button("Generate"))
            {
                target.GenerateAndRenderer();
            }
            if (GUILayout.Button("Clear"))
            {
                target.Clear();
            }
        }
    }
}
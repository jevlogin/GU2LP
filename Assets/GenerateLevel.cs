using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Tilemaps;


namespace JevLogin
{
    public sealed class GenerateLevel : MonoBehaviour
    {
        [SerializeField] private GenerateLevelView _generateLevelView;

        private GeneratorLevelController _generatorLevelController;


        private void Start()
        {
            _generatorLevelController = new GeneratorLevelController(_generateLevelView);
            _generatorLevelController.Awake();
        }
    }
}
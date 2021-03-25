using UnityEngine;


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
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Factory
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] CubeFactory _cubeFactory;
        [SerializeField] Button _jumpButton, _rotateButton;

        private int spawnIndex = 0;

        void Start()
        {
            _jumpButton.onClick.AddListener(() =>
            {
                GameObject cube = _cubeFactory.CreateJumpingCube();
                cube.transform.position = new Vector3(spawnIndex++, 0.5f, 0);
            });
            _rotateButton.onClick.AddListener(() =>
            {
                GameObject cube = _cubeFactory.CreateRotatingCube();
                cube.transform.position = new Vector3(spawnIndex++, 0.5f, 0);
            });
        }
    }
}

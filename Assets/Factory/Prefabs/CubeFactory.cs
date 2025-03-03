using UnityEngine;

namespace DesignPatterns.Factory
{
    public class CubeFactory : MonoBehaviour
    {
        [SerializeField] GameObject _cubePrefab;

        public GameObject CreateJumpingCube()
        {
            GameObject cube = Instantiate(_cubePrefab);

            var controller = cube.transform.GetComponent<CubeController>();

            ICubeBehavior behavior = cube.AddComponent<JumpBehavior>();

            controller.CubeBehavior = behavior;

            if (cube.transform.TryGetComponent<Renderer>(out var rend))
            {
                rend.material.color = Color.green;
            }

            return cube;
        }

        public GameObject CreateRotatingCube()
        {
            GameObject cube = Instantiate(_cubePrefab);

            var controller = cube.transform.GetComponent<CubeController>();

            ICubeBehavior behavior = cube.AddComponent<RotateBehavior>();

            controller.CubeBehavior = behavior;

            if (cube.transform.TryGetComponent<Renderer>(out var rend))
            {
                rend.material.color = Color.blue;
            }

            return cube;
        }

    }
}

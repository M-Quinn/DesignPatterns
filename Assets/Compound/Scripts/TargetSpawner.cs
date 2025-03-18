using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [Header("Functional Settings")]
        [SerializeField] float _delayBeforeNewTarget = 1f;
    [Header("Scene References")] 
        [SerializeField] Transform _spawnGroundTransform;
        [SerializeField] MeshRenderer _spawnGroundRenderer;
        [Header("External References")]
        [SerializeField] GameObject _targetPrefab;

        GameObject _targetObject;
        Target _target;
        Vector3 minPosition, maxPosition;

        private void Awake()
        {
            Bounds bounds = _spawnGroundRenderer.bounds;
            minPosition = bounds.min;
            maxPosition = bounds.max;

            _targetObject = Instantiate(_targetPrefab, GetRandomPosition(), Quaternion.identity);
            _target = _targetObject.GetComponent<Target>();
            _target.Die += OnTargetReached;
        }

        void OnTargetReached()
        {
            _targetObject.SetActive(false);
            StartCoroutine(SpawnNewTarget());
        }

        Vector3 GetRandomPosition()
        {
            return new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                _spawnGroundTransform.position.y, 
                Random.Range(minPosition.z, maxPosition.z)
            );
        }

        IEnumerator SpawnNewTarget()
        {
            yield return new WaitForSeconds(_delayBeforeNewTarget);
            _targetObject.transform.position = GetRandomPosition();
            _targetObject.SetActive(true);
        }
}

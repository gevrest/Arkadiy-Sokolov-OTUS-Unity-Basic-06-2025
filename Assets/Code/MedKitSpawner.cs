using UnityEngine;

namespace Game
{
    public class MedKitSpawner : MonoBehaviour
    {
        [SerializeField] Vector3[] _positions;
        [SerializeField] Transform _spawner;
        [SerializeField] GameObject _medKit;

        private void Start()
        {
            foreach (var position in _positions)
            {
                var MedKit = Instantiate(_medKit, position, Quaternion.identity, _spawner);
                _medKit.name = "MedKit";
            }
        }
    }
}
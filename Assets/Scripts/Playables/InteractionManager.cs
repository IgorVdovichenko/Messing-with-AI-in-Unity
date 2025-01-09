using UnityEngine;
using Random = UnityEngine.Random;

namespace Playables
{
    public class InteractionManager : MonoBehaviour
    {
        private Location[] _locations;

        private int _index;

        private void Awake() => _locations = GetComponentsInChildren<Location>();
        
        public Location RandomLocation => _locations[Random.Range(0, _locations.Length)];

        public Location NextLocation => _locations[_index++ % _locations.Length];
    }
}
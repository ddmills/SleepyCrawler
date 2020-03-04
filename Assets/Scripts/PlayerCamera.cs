namespace Sleepy
{
    using UnityEngine;
    using Bolt;

    public class PlayerCamera : BoltSingletonPrefab<PlayerCamera>
    {
        private Transform _target;
        [SerializeField]
        private Transform _camera;

        void Awake ()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _camera.parent = _target;
            _camera.localPosition = new Vector3(0, 0, -10);
        }
    }
}

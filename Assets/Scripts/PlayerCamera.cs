namespace Sleepy
{
    using UnityEngine;
    using Bolt;

    public class PlayerCamera : BoltSingletonPrefab<PlayerCamera>
    {
        private Transform _target;
        [SerializeField]
        private Transform _camera;
        private Vector3 offset = new Vector3(0, 0, -10);

        void Awake ()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _camera.position = _target.position + offset;
        }

        public void Update()
        {
            _camera.position = Vector3.Lerp(_camera.position, _target.position + offset, Time.deltaTime);
        }
    }
}

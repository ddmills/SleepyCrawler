namespace Sleepy.Art
{
    using UnityEngine;

    public class DestroyTimer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Duration in seconds before destroying")]
        private float duration = 5;

        public void Start()
        {
            Destroy(gameObject, duration);
        }
    }
}

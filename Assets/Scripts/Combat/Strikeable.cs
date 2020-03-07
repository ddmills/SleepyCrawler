namespace Sleepy.Combat
{
    using UnityEngine;

    public class Strikeable : MonoBehaviour
    {
        [SerializeField]
        private UnityStrikeDataEvent OnStrikeEvent;

        public void Strike(StrikeData data)
        {
            OnStrikeEvent.Invoke(data);
        }
    }
}

using UnityEngine;

namespace Game.Scripts.Player.Animators
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayRunAnimation(bool isRun)
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsRunning, isRun);
        }
    }
}
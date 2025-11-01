using UnityEngine;

namespace Game.Scripts.Player.Animators
{
    public static class PlayerAnimatorData
    {
        public static class Params
        {
            public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        }
    }
}
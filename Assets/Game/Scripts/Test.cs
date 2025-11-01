using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Transform[] _path;

        private void Start()
        {
            _mover.SetPath(_path);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                _mover.StartMove();
        }
    }
}
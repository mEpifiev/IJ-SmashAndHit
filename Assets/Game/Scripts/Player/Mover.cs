using System;
using Game.Scripts.Player.Animators;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Mover : MonoBehaviour
    {
        private const float MinDirectionMagnitude = 0.0001f;
        private const float TargetPointThreshold = 0.1f;
        
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _rotateSpeed = 2f;
        
        private bool _isEnabled;
        
        private Transform[] _currentPath;
        private Vector3 _currentTargetPoint;
        
        private int _currentTargetPointIndex;

        private void FixedUpdate()
        {
            if (_isEnabled == false) 
                return;
            
            Vector3 direction = _currentTargetPoint - transform.position;
            direction.y = 0;
            
            transform.position += direction.normalized * _moveSpeed * Time.deltaTime;
            
            if (direction.sqrMagnitude > MinDirectionMagnitude)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), _rotateSpeed * Time.deltaTime);

            if (direction.sqrMagnitude < TargetPointThreshold * TargetPointThreshold)
                AssignNextTargetPoint();
        }

        public void SetPath(Transform[] path)
        {
            _currentPath = path ?? throw new NullReferenceException(nameof(path));
            
            _currentTargetPointIndex = 0;
        }

        public void StartMove()
        {
            if (_currentPath == null || _currentPath.Length == 0)
                return;
            
            _currentTargetPoint = _currentPath[_currentTargetPointIndex].position;
            
            SetState(true);
        }

        private void AssignNextTargetPoint()
        {
            if (_currentPath == null || _currentPath.Length == 0)
                return;
            
            SetState(false);
            
            if (_currentTargetPointIndex < _currentPath.Length - 1)
            {
                _currentTargetPointIndex++;
                _currentTargetPoint = _currentPath[_currentTargetPointIndex].position;
            }
            else
            {
                // конец пути
            }
        }

        private void SetState(bool state)
        {
            _isEnabled = state;

            _animator.PlayRunAnimation(state);
        }
    }
}
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private Transform[] _directionTransforms;
        private bool _isTop;
        private bool _isLeft;
        private bool _isRight;
        private float torque = 1.3f;

        private Vector3 _velocity;
        private Vector3 _angularVelocity;

        public void Configure(Transform[] directionTransforms, bool isTop, bool isLeft, bool isRight)
        {
            _directionTransforms = directionTransforms;
            _isTop = isTop;
            _isLeft = isLeft;
            _isRight = isRight;
        }


        public void Move()
        {
            ResetRigidbody();
            if (_isTop)
            {
                ApplyForceAndRotation(4);
                return;
            }
            if (_isRight)
            {
                ApplyForceAndRotation(10);
                return;
            }
            if (_isLeft)
            {
                ApplyForceAndRotation(10);
                return;
            }
            else
            {
                ApplyForceAndRotation(16);
            }
        }

        public void ResetRigidbody()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        private void ApplyForceAndRotation(int multiplier)
        {
            _rigidbody.AddForce(RandomDirection() * multiplier, ForceMode.Impulse);
            _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        }

        public void IsKinematicAndAssignVariables()
        {
            if(_rigidbody != null)
            {
                _rigidbody.isKinematic = true;
                _velocity = _rigidbody.velocity;
                _angularVelocity = _rigidbody.angularVelocity;
                _collider.enabled = false;
            }
        }
        
        public void IsNotKinematicAndReassignVariables()
        {
            if(_rigidbody != null)
            {
                _rigidbody.isKinematic = false;
                _rigidbody.velocity = _velocity;
                _rigidbody.angularVelocity = _angularVelocity;
                _collider.enabled = true;
            }
        }


        public Vector3 RandomDirection()
        {
            var randomTransform = _directionTransforms[Random.Range(0, _directionTransforms.Length)];
            var direction = (randomTransform.position - transform.position).normalized;
            return direction;
        }

        public float RandomTorque()
        {
            return Random.Range(-torque, torque);
        }

    }
}
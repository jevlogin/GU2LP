using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

namespace JevLogin
{
    public sealed class EnemyAI : MonoBehaviour
    {
        [Header("Pathfinding")]
        public Transform Target;
        public float ActiavateDistance = 50.0f;
        public float PathUpdateSeconds = 0.0f;

        [Header("Physics")]
        public float Speed = 200.0f;
        public float NextWaypointDistance = 3.0f;
        public float JumpNodeHeightRequirement = 0.8f;
        public float JumpModifier = 0.3f;
        public float JumpCheckOffset = 0.1f;

        [Header("Custom Behaviour")]
        public bool FollowEnabled = true;
        public bool JumpEnabled = true;
        public bool DirectionLookEnabled = true;

        private Path _path;
        private int _currentWaypoint = 0;
        private bool _isGrounded = false;
        private Seeker _seeker;
        private Rigidbody2D _rigidbody2D;
        private float _sqrActiveDistance;

        private void Start()
        {
            Target = GameObject.Find(ManagerPath.PLAYER).transform;
            _seeker = GetComponent<Seeker>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _sqrActiveDistance = ActiavateDistance * ActiavateDistance;

            InvokeRepeating(nameof(UpdatePath), 0.0f, PathUpdateSeconds);
        }

        private void FixedUpdate()
        {
            if (TargetInDistance() && FollowEnabled)
            {
                PathFollow();
            }
        }

        private bool TargetInDistance()
        {
            return (Target.position - transform.position).sqrMagnitude < _sqrActiveDistance;
            //return Vector2.Distance(transform.position, Target.position) < ActiavateDistance;
        }

        private void PathFollow()
        {
            if (_path == null)
            {
                return;
            }
            if (_currentWaypoint >= _path.vectorPath.Count)
            {
                return;
            }
            _isGrounded = IsGrounded();

            Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rigidbody2D.position).normalized;
            Vector2 force = direction * Speed * Time.deltaTime;

            if (JumpEnabled && _isGrounded)
            {
                if (direction.y > JumpNodeHeightRequirement)
                {
                    _rigidbody2D.AddForce(Vector2.up * Speed * JumpModifier);
                }
            }

            _rigidbody2D.AddForce(force);

            float distance = Vector2.Distance(_rigidbody2D.position, _path.vectorPath[_currentWaypoint]);
            if (distance <  NextWaypointDistance)
            {
                _currentWaypoint++;
            }

            if (DirectionLookEnabled)
            {
                if (_rigidbody2D.velocity.x > 0.05f)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else if (_rigidbody2D.velocity.x < 0.05f)
                {
                    transform.localScale = new Vector3(-1.0f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }

        private bool IsGrounded()
        {
            var startOffset = transform.position - new Vector3(0.0f, GetComponent<Collider2D>().bounds.extents.y + JumpCheckOffset);
            return Physics2D.Raycast(startOffset, Vector3.down, 0.1f);
        }

        private void UpdatePath()
        {
            if (FollowEnabled && TargetInDistance() && _seeker.IsDone())
            {
                _seeker.StartPath(_rigidbody2D.position, Target.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (!p.error)
            {
                _path = p;
                _currentWaypoint = 0;
            }
        }
    }
}
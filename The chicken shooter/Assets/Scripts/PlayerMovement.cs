using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.Inputs
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody playerRigidbody;

        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        public void JumpCharacter(float force)
        {
            playerRigidbody.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
        }

        public void MoveCharacter(Vector3 movement)
        {
            playerRigidbody.velocity = new Vector3(movement.x * _speed, playerRigidbody.velocity.y, movement.z * _speed);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs
{
    public class ButtonInput : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onJump;
        [SerializeField]
        private UnityEvent onRight;
        [SerializeField]
        private UnityEvent onLeft;

        private void Update()
        {
            if (Input.GetButtonDown("Jump")) { onJump.Invoke(); }
            if (Input.GetButtonDown("Right")) { onRight.Invoke(); }
            if (Input.GetButtonDown("Left")) { onLeft.Invoke(); }
        }
    }
}
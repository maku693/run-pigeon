using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs
{
    public class SwipeInput : MonoBehaviour
    {
        private static float cm2Inch = 0.3937008F;
        [SerializeField]
        private float minSwipeDistance;
        private float minSwipeDistancePixel => minSwipeDistance * cm2Inch * Screen.dpi;

        [SerializeField]
        private float maxSwipeAngleSlip;
        private float maxSwipeAngleSlipTurn => maxSwipeAngleSlip / 360F;

        [SerializeField]
        private UnityEvent onJump;
        [SerializeField]
        private UnityEvent onRight;
        [SerializeField]
        private UnityEvent onLeft;

        private Vector2 touchStart;

        private void Update()
        {
            if (Input.touchCount == 0) { return; }

            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
            }
            if (touch.phase != TouchPhase.Ended) { return; }

            var swipe = touch.position - touchStart;
            if (swipe.magnitude < minSwipeDistancePixel) { return; }

            Tuple<Vector2, UnityEvent>[] callbackForAngles = {
                Tuple.Create(Vector2.up, onJump),
                Tuple.Create(Vector2.right, onRight),
                Tuple.Create(Vector2.left, onLeft),
            };
            foreach (var x in callbackForAngles)
            {
                var angleSlip = 1 - Vector2.Dot(x.Item1, swipe.normalized);
                if (angleSlip < maxSwipeAngleSlipTurn) { x.Item2.Invoke(); }
            }
        }
    }
}
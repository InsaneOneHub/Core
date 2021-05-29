﻿using UnityEngine;

namespace InsaneSystems.Core.UI
{
    public class FloatingPanel : MonoBehaviour
    {
        public Transform CanvasTransform;
        public RectTransform RectTransform;
        public Transform FollowTarget;
        public float VerticalOffset;

        Camera mainCamera;

        void Awake() => mainCamera = Camera.main;

        void Start()
        {
            RectTransform.anchorMin = Vector3.zero;
            RectTransform.anchorMax = Vector3.zero;
        }

        void Update()
        {
            if (!FollowTarget)
                return;

            var worldTargetPos = FollowTarget.transform.position;
            var screenPos = mainCamera.WorldToScreenPoint(worldTargetPos + Vector3.up * VerticalOffset);

            RectTransform.anchoredPosition = screenPos * CanvasTransform.localScale.x;
        }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
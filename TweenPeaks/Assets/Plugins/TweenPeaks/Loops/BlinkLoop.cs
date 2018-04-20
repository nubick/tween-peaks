using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TweenPeaks.Loops
{
    public class BlinkLoop : MonoBehaviour
    {
        private Action _hideRootAction;
        private Action _showRootAction;

        private Graphic _graphic;
        private Renderer _renderer;

        public float BlinkDelay;

        public void Awake()
        {
            CacheElements();
        }

        private void CacheElements()
        {
            _graphic = GetComponent<Graphic>();
            if (_graphic != null)
            {
                _hideRootAction = () => _graphic.enabled = false;
                _showRootAction = () => _graphic.enabled = true;
                return;
            }

            _renderer = GetComponent<Renderer>();
            if(_renderer != null)
            {
                _hideRootAction = () => _renderer.enabled = false;
                _showRootAction = () => _renderer.enabled = true;
                return;
            }

            Debug.Log("BlinkLoop. Can't find any visual element to blink.");
        }

        public void OnEnable()
        {
            StopAllCoroutines();
            if (_showRootAction != null)
                StartCoroutine(BlinkCoroutine());
        }

        private IEnumerator BlinkCoroutine()
        {
            for (;;)
            {
                Show();
                yield return new WaitForSeconds(BlinkDelay);
                Hide();
                yield return new WaitForSeconds(BlinkDelay);
            }
        }

        private void Show()
        {
            _showRootAction();
            UpdateChildrenVisibility(true);
        }

        private void Hide()
        {
            _hideRootAction();
            UpdateChildrenVisibility(false);
        }

        private void UpdateChildrenVisibility(bool isVisible)
        {
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(isVisible);
        }
    }
}

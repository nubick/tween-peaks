using System;
using System.Collections.Generic;
using TweenPeaks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Demo
{
    public class EaseSelector : MonoBehaviour
    {
        private readonly List<Toggle> _easeToggles = new List<Toggle>();

        public RectTransform EaseTogglesRoot;
        public RectTransform EaseTogglePrefab;
        public Ease SelectedEase;

        public void Awake()
        {
            CreateEaseToggles();
        }

        private void CreateEaseToggles()
        {
            Toggle.ToggleEvent toggleEvent = new Toggle.ToggleEvent();
            toggleEvent.AddListener(OnValueChanged);

            ToggleGroup toggleGroup = EaseTogglesRoot.GetComponent<ToggleGroup>();
            foreach (string easeName in Enum.GetNames(typeof(Ease)))
            {
                RectTransform easeToggle = Instantiate(EaseTogglePrefab);
                easeToggle.SetParent(EaseTogglesRoot);
                easeToggle.name = easeName;
                easeToggle.localScale = Vector3.one;
                easeToggle.GetComponentInChildren<Text>().text = easeName;
                Toggle toggle = easeToggle.GetComponent<Toggle>();
                toggle.group = toggleGroup;
                toggle.onValueChanged = toggleEvent;
                _easeToggles.Add(toggle);
            }
            toggleGroup.SetAllTogglesOff();
            _easeToggles[0].isOn = true;
        }

        private void OnValueChanged(bool isOn)
        {
            foreach (Toggle toggle in _easeToggles)
                if (toggle.isOn)
                    SelectedEase = (Ease)Enum.Parse(typeof(Ease), toggle.name);
        }


    }
}

using System;
using Models;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class SettingUIView : UIView
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Toggle audioToggle;
        [SerializeField] private AudioSource exit;
        private void Start()
        {
            audioToggle.isOn = true;
        }

        private void Awake()
        {
            var sm = GameContext.Instance.SaveService.Load<SettingModel>();

            volumeSlider.value = sm.volume;
            volumeSlider.minValue = 0;
            volumeSlider.maxValue = 1;
            audioToggle.isOn = sm.mute;
            exitButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(MainMenuUIView));
                exit.Play();
            });
            volumeSlider.onValueChanged.AddListener(v =>
            {
                GameContext.Instance.AudioService.Volume = v;
                var settingsModel = GameContext.Instance.SaveService.Load<SettingModel>();
                settingsModel.volume = v;
                GameContext.Instance.SaveService.Write(settingsModel);
                
            });
            audioToggle.onValueChanged.AddListener(v =>
            {
                GameContext.Instance.AudioService.Mute = v;
                var settingsModel = GameContext.Instance.SaveService.Load<SettingModel>();
                settingsModel.mute = v;
                GameContext.Instance.SaveService.Write(settingsModel);
            });
        }

        public override string ViewName => nameof(SettingUIView);
    }
}
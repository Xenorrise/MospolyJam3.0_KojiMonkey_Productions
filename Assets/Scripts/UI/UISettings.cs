using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UISettings : UIElement
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundFXSlider;
    [Space]
    [SerializeField] private RectTransform _buttonBack;

    void Start()
    {
        SetMasterVolume();
        SetSoundFXVolume();
        SetMusicVolume();
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        ShowAnimation(_buttonBack);
    }
    public override void Hide()
    {
        if (gameObject.activeSelf == false)
            return;

        HideAnimation(_buttonBack)
            .AppendCallback(() => gameObject.SetActive(false));
    }
    public Sequence ShowAnimation(params Transform[] transforms)
    {
        foreach (var item in transforms)
        {
            item.DOScale(0, 0);
        }
        DOTween.Kill(gameObject);
        var sequence = DOTween.Sequence(gameObject);
        foreach (var item in transforms)
        {
            sequence.Append(item.DOScale(1, 0.3f).SetEase(Ease.OutBack));
        }
        return sequence;
    }
    public Sequence HideAnimation(params Transform[] transforms)
    {
        foreach (var item in transforms)
        {
            item.DOScale(1, 0);
        }
        DOTween.Kill(gameObject);
        var sequence = DOTween.Sequence(gameObject);
        foreach (var item in transforms)
        {
            sequence.Join(item.DOScale(0, 0.1f).SetEase(Ease.OutBack));
        }
        return sequence;
    }
    public void SetMasterVolume()
    {
        float volume = _masterSlider.value;
        if(volume > 0)
            _audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        else
            _audioMixer.SetFloat("master", -80);
    }
    public void SetSoundFXVolume()
    {
        float volume = _soundFXSlider.value;
        if(volume > 0)
            _audioMixer.SetFloat("soundFX", Mathf.Log10(volume) * 20);
        else
            _audioMixer.SetFloat("soundFX", -80);
    }
    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        if(volume > 0)
            _audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        else
            _audioMixer.SetFloat("music", -80);
    }
    
}

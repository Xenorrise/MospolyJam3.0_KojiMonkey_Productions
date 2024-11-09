using DG.Tweening;
using UnityEngine;

public class UIMenu : UIElement
{
    [SerializeField] private RectTransform _gameTitle, _buttonStart, _buttonSettings, _buttonExit;
    public override void Show()
    {
        gameObject.SetActive(true);
        
        ShowAnimation(
            _gameTitle,
            _buttonStart,
            _buttonSettings,
            _buttonExit
            );
    }
    public override void Hide()
    {
        if (gameObject.activeSelf == false)
            return;


        HideAnimation(
            _gameTitle,
            _buttonStart,
            _buttonSettings,
            _buttonExit
            )
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
}

using DG.Tweening;
using UnityEngine;

public class RoadMap : MonoBehaviour
{
    [SerializeField] private RectTransform _stage1, _stage2, _stage3, _stage4, _stage5, _stage6;
    [SerializeField] private RectTransform _pointer;

    private RectTransform[] _stages;
    private RectTransform _currentStage;
    private int _currentStageIndex;

    private void Start()
    {
        _stages = new RectTransform[] { _stage1, _stage2, _stage3, _stage4, _stage5, _stage6 };
        _currentStageIndex = 0; 
        _currentStage = _stages[_currentStageIndex];

        AnimateStage(_currentStage);
    }
    private void AnimateStage(RectTransform stage)
    {
        Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);

        stage.DOScale(targetScale, 0.5f) // ����������� ������
            .SetLoops(-1, LoopType.Yoyo)  // ��������� �������� ���������� � �������� "���������" (����������-����������)
            .SetEase(Ease.InOutSine); // ������� ��������� ��������
    }
    public void NextStage()
    {
        DOTween.Kill(_currentStage);
        _currentStage.DOScale(new Vector3 (1, 1, 1), 1);


        // ������� � ��������� ������, ���� ���� ���� ����
        if (_currentStageIndex < _stages.Length - 1)
        {
            _currentStageIndex++;  // ����������� ������ ��� ��������� ������
            _currentStage = _stages[_currentStageIndex]; // ��������� ������� ������
            _pointer.DOMove(_currentStage.transform.position, 0.5f);
            AnimateStage(_currentStage);
        }
        else
        {
            Debug.Log("��� ���������� ��������� ������!");
        }
    }
}
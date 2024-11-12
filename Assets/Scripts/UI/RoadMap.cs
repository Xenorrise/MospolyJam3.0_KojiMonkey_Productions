using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoadMap : MonoBehaviour
{
    [SerializeField] private RectTransform _stage1, _stage2, _stage3, _stage4, _stage5, _stage6, _stage7;
    [SerializeField] private RectTransform _pointer;
    [SerializeField] private Transform cameraTR, enemyEmpty;
    [SerializeField] private float cameraNextStageMoveTime;
    [SerializeField] private AudioClip alarmSound;
    [SerializeField] private Object enemy;
    AudioSource mainSource;
    CurEnemy curEnemy;
    PlayerController playerController;
    Slider curEnemySlider;

    private RectTransform[] _stages;
    private RectTransform _currentStage;
    private int _currentStageIndex;

    private void Start()
    {
        _stages = new RectTransform[] { _stage1, _stage2, _stage3, _stage4, _stage5, _stage6, _stage7};
        _currentStageIndex = 0; 
        _currentStage = _stages[_currentStageIndex];
        cameraTR = FindAnyObjectByType<Camera>().transform;
        mainSource = FindAnyObjectByType<AudioSource>();
        curEnemy = FindAnyObjectByType<CurEnemy>();
        curEnemySlider = curEnemy.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        playerController = FindAnyObjectByType<PlayerController>();
        AnimateStage(_currentStage);
        NextStage();
    }
    private void AnimateStage(RectTransform stage)
    {
        Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);

        stage.DOScale(targetScale, 0.5f) // Увеличиваем размер
            .SetLoops(-1, LoopType.Yoyo)  // Повторяем анимацию бесконечно с эффектом "пульсации" (увеличение-уменьшение)
            .SetEase(Ease.InOutSine); // Плавное изменение масштаба
    }
    public void NextStage()
    {
        DOTween.Kill(_currentStage);
        _currentStage.DOScale(new Vector3 (1, 1, 1), 1);
        StartCoroutine(ChangeStage());
    }

    public IEnumerator ChangeStage()
    {
        float currentMovementTime = 0f;
        float newXPosition = cameraTR.position.x - 1080f;
        while (cameraTR.position.x > newXPosition)
        {
            currentMovementTime += Time.deltaTime;
            cameraTR.position = new(Mathf.MoveTowards(cameraTR.position.x, newXPosition, currentMovementTime / cameraNextStageMoveTime), cameraTR.position.y, cameraTR.position.z);
            yield return null;
        }
        if (_currentStageIndex < _stages.Length - 1)
        {
            _currentStageIndex++;  // Увеличиваем индекс для следующей стадии
            _currentStage = _stages[_currentStageIndex]; // Обновляем текущую стадию
            GameObject newEnemy = Instantiate(enemy).GameObject();
            newEnemy.transform.position = enemyEmpty.position;
            newEnemy.transform.SetParent(transform, true);
            newEnemy.transform.localScale = Vector3.one;
            curEnemy.curEnemy = newEnemy.GetComponent<Enemy>();
            curEnemySlider.maxValue = newEnemy.GetComponent<Enemy>().HP;
            curEnemySlider.value = newEnemy.GetComponent<Enemy>().HP;
            foreach (MilitaryBuilding militaryBuilding in FindObjectsByType<MilitaryBuilding>(FindObjectsSortMode.None))
            {
                if (militaryBuilding.isActive)
                    militaryBuilding.isDoing = true;
            }
            _pointer.DOMove(_currentStage.transform.position, 0.5f);
            AnimateStage(_currentStage);
            mainSource.PlayOneShot(alarmSound);
        }
        else
        {
            playerController.Vitory();
            Debug.Log("Уже достигнута последняя стадия!");
        }
    }
}
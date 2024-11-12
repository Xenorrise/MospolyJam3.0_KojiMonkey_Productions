using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    /// <summary>
    /// Position of the central background sprite
    /// </summary>
    private float _horizontalPosition;

    /// <summary>
    /// Sprite width
    /// </summary>
    private float _width;

    /// <summary>
    /// Camera game object reference
    /// </summary>
    [SerializeField] private GameObject _cameraObject;

    /// <summary>
    /// Speed at wich background layers move. 
    /// (0 - moves with _cameraObject;  0.5 = half the speed; 1 = won't move)
    /// </summary>
    [SerializeField] private float _parallaxEffectValue;

    public void Start()
    {
        // initializing transform parameters
        _horizontalPosition = transform.position.x;
        _width = GetComponent<Image>().sprite.texture.width;
    }

    public void Update()
    {
        float distance = _cameraObject.transform.position.x * _parallaxEffectValue;
        float movement = _cameraObject.transform.position.x * (1 - _parallaxEffectValue);

        transform.position = new Vector3(_horizontalPosition + distance, transform.position.y, transform.position.z);

        // background wraping
        if (movement > _horizontalPosition + _width) // right wrapping
            _horizontalPosition += _width;
        else if (movement < _horizontalPosition - _width) // left wrapping
            _horizontalPosition -= _width;
    }
}

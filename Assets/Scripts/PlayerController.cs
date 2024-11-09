using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject curSelectedBuilding;
    public Sprite baseTemplate;

    void Update()
    {
        if (Input.GetMouseButtonDown(2) && curSelectedBuilding != null)
            CancelSelecting();
    }

    public void CancelSelecting()
    {
        Destroy(curSelectedBuilding);
        curSelectedBuilding = null;
    }
}

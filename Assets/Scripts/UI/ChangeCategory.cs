using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCategory : MonoBehaviour
{
    public GameObject[] categories;
    public GameObject curCategory;
    public ScrollView scrollView;
    public void CategoryChange()
    {
        foreach (GameObject category in categories)
        {
            if (category != curCategory)
                category.SetActive(false);
            else
            {
                category.SetActive(true);
            }
        }
    }
}

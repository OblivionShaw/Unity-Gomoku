using UnityEngine;
using UnityEngine.UI;

public class GomokuButtonController : MonoBehaviour
{
    // 這個方法將被添加到按鈕的OnClick事件中
    public void OnButtonClick(Button button)
    {
        // 獲取按鈕的gameobject Name
        string buttonName = button.name;
        // 打印按鈕的gameobject Name
        Debug.Log(buttonName);
    }
}
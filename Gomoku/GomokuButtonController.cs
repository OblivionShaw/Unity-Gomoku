using UnityEngine;
using UnityEngine.UI;

public class GomokuButtonController : MonoBehaviour
{
    // �o�Ӥ�k�N�Q�K�[����s��OnClick�ƥ�
    public void OnButtonClick(Button button)
    {
        // ������s��gameobject Name
        string buttonName = button.name;
        // ���L���s��gameobject Name
        Debug.Log(buttonName);
    }
}
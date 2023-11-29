using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuNewBehaviourScript1 : MonoBehaviour
{
    [SerializeField] [Tooltip("")] Color[] PlayerColor;
    // Start is called before the first frame update
    void Start()
    {
        PlayerColor = new Color[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

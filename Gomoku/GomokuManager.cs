using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GomokuManager : MonoBehaviour
{
    private const int BOARD_SIZE = 15; // 棋盤大小

    [SerializeField] [Tooltip("")] Color[] PlayerColor = new Color[3];
    [SerializeField] [Tooltip("")] GameObject DogFather;
    [SerializeField] [Tooltip("")] GameObject DogObject;
    [SerializeField] [Tooltip("")]  Image[] Dog = new Image[169];
    [SerializeField] [Tooltip("")] int[] Result = new int[169];
    [SerializeField] [Tooltip("")] int Player = 1;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 80; i++)
        //{
        //    Instantiate(DogObject, DogObject.transform.position, DogObject.transform.rotation, DogFather.transform);
        //}

        int Count = 0;
        foreach (Transform Item in DogFather.transform)
        {
            Dog[Count] = Item.GetComponent<Image>();
            Item.gameObject.name = Count.ToString();
            Dog[Count].color = PlayerColor[0];
            Count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetDog(Button button)
    //{
    //    if (button.interactable)
    //    {
    //        string buttonName = button.name;
    //        int buttonNameNumber = int.Parse(button.name);
    //        Debug.Log(buttonName);

    //        Result[buttonNameNumber] = Player;
    //        Dog[buttonNameNumber].color = PlayerColor[Player];

    //        button.interactable = !button.interactable;

    //        if (Player == 1)
    //        {
    //            Player = 2;
    //        }
    //        else
    //            Player = 1;
    //    }



    //}


    public void SetDog(Button button)
    {
        if (button.interactable)
        {
            string buttonName = button.name;
            int buttonNameNumber = int.Parse(button.name);
            Debug.Log(buttonName);

            Result[buttonNameNumber] = Player;
            Dog[buttonNameNumber].color = PlayerColor[Player];

            button.interactable = !button.interactable;

            // 判斷是否獲勝
            if (CheckWin(Player, buttonNameNumber))
            {
                Debug.Log((Player == 1 ? "白棋" : "黑棋") + "獲勝！");
                for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
                {
                    Dog[i].GetComponent<Button>().interactable = false;
                }
                // 這裡可以添加一些獲勝後的處理，比如顯示提示、停止遊戲等
            }
            else
            {
                // 換另一位玩家下棋
                Player = Player == 1 ? 2 : 1;
            }
        }
    }

    // 檢查一個玩家是否在一個位置獲勝
    private bool CheckWin(int player, int position)
    {
        // 檢查四個方向是否有連續五個相同顏色的棋子
        return CheckLine(player, position, 1, 0) || // 水平方向
               CheckLine(player, position, 0, 1) || // 垂直方向
               CheckLine(player, position, 1, 1) || // 正斜方向
               CheckLine(player, position, 1, -1);   // 反斜方向
    }

    // 檢查一個方向上是否有連續五子
    private bool CheckLine(int player, int position, int dx, int dy)
    {
        // 從position出發，沿著(dx,dy)的方向，計算連續相同顏色的棋子數量
        int count = 1; // 起始點已經有一個棋子
        int i = position + dx + dy * BOARD_SIZE; // 下一個檢查點的索引
        while (i >= 0 && i < BOARD_SIZE * BOARD_SIZE && Result[i] == player)
        {
            // 如果下一個檢查點仍在棋盤範圍內，且顏色和當前玩家相同，則計數加一
            count++;
            i += dx + dy * BOARD_SIZE; // 繼續沿著方向移動
        }
        i = position - dx - dy * BOARD_SIZE; // 反方向的下一個檢查點的索引
        while (i >= 0 && i < BOARD_SIZE * BOARD_SIZE && Result[i] == player)
        {
            // 如果反方向的下一個檢查點仍在棋盤範圍內，且顏色和當前玩家相同，則計數加一
            count++;
            i -= dx + dy * BOARD_SIZE; // 繼續沿著反方向移動
        }
        return count >= 5; // 如果連續棋子數量大於等於5，則返回真，否則返回假
    }



    public void ResetBoard()
    {
        // 將所有的棋子顏色和結果陣列都恢復為初始狀態
        for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
        {
            Dog[i].color = PlayerColor[0];
            Result[i] = 0;
            Dog[i].GetComponent<Button>().interactable = true;
        }
        // 將當前玩家設為白棋
        Player = 1;
    }

    [ContextMenu("TEST")]
    public void TEST()
    {
        int[] Result = new int[81];
    }


}

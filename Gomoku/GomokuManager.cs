using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GomokuManager : MonoBehaviour
{
    private const int BOARD_SIZE = 15; // �ѽL�j�p

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

            // �P�_�O�_���
            if (CheckWin(Player, buttonNameNumber))
            {
                Debug.Log((Player == 1 ? "�մ�" : "�´�") + "��ӡI");
                for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
                {
                    Dog[i].GetComponent<Button>().interactable = false;
                }
                // �o�̥i�H�K�[�@����ӫ᪺�B�z�A��p��ܴ��ܡB����C����
            }
            else
            {
                // ���t�@�쪱�a�U��
                Player = Player == 1 ? 2 : 1;
            }
        }
    }

    // �ˬd�@�Ӫ��a�O�_�b�@�Ӧ�m���
    private bool CheckWin(int player, int position)
    {
        // �ˬd�|�Ӥ�V�O�_���s�򤭭ӬۦP�C�⪺�Ѥl
        return CheckLine(player, position, 1, 0) || // ������V
               CheckLine(player, position, 0, 1) || // ������V
               CheckLine(player, position, 1, 1) || // ���פ�V
               CheckLine(player, position, 1, -1);   // �ϱפ�V
    }

    // �ˬd�@�Ӥ�V�W�O�_���s�򤭤l
    private bool CheckLine(int player, int position, int dx, int dy)
    {
        // �qposition�X�o�A�u��(dx,dy)����V�A�p��s��ۦP�C�⪺�Ѥl�ƶq
        int count = 1; // �_�l�I�w�g���@�ӴѤl
        int i = position + dx + dy * BOARD_SIZE; // �U�@���ˬd�I������
        while (i >= 0 && i < BOARD_SIZE * BOARD_SIZE && Result[i] == player)
        {
            // �p�G�U�@���ˬd�I���b�ѽL�d�򤺡A�B�C��M��e���a�ۦP�A�h�p�ƥ[�@
            count++;
            i += dx + dy * BOARD_SIZE; // �~��u�ۤ�V����
        }
        i = position - dx - dy * BOARD_SIZE; // �Ϥ�V���U�@���ˬd�I������
        while (i >= 0 && i < BOARD_SIZE * BOARD_SIZE && Result[i] == player)
        {
            // �p�G�Ϥ�V���U�@���ˬd�I���b�ѽL�d�򤺡A�B�C��M��e���a�ۦP�A�h�p�ƥ[�@
            count++;
            i -= dx + dy * BOARD_SIZE; // �~��u�ۤϤ�V����
        }
        return count >= 5; // �p�G�s��Ѥl�ƶq�j�󵥩�5�A�h��^�u�A�_�h��^��
    }



    public void ResetBoard()
    {
        // �N�Ҧ����Ѥl�C��M���G�}�C����_����l���A
        for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
        {
            Dog[i].color = PlayerColor[0];
            Result[i] = 0;
            Dog[i].GetComponent<Button>().interactable = true;
        }
        // �N��e���a�]���մ�
        Player = 1;
    }

    [ContextMenu("TEST")]
    public void TEST()
    {
        int[] Result = new int[81];
    }


}

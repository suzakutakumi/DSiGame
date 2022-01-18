using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ActionManager : MonoBehaviour
{
    public GameManager gameManager;
    private IwasiCore fromIwasi;
    private IwasiCore toIwasi;

    [SerializeField] private GenerateIwasi generate = new GenerateIwasi();

    // Start is called before the first frame update
    void Start()
    {
        //�z�񑫂�Ȃ����p
        //generate.Generate(0, 0, 10,10);
    }

    public void getID(int fromId, int toId)
    {
        fromIwasi = gameManager.nowPlayerGroup[fromId].GetComponent<IwasiCore>();
        toIwasi= gameManager.nowOpponentGroup[toId].GetComponent<IwasiCore>();
    }

    public void Attack()
    {
        toIwasi.Damaged(fromIwasi);
    }

    public void Exchange(int val)
    {
        fromIwasi.GiveOrTake(-val);
        toIwasi.GiveOrTake(val);
    }

    public void Create(int val)
    {
        generate.Generate(gameManager.myId,fromIwasi.type, fromIwasi.x, fromIwasi.y);
        fromIwasi.GiveOrTake(-val);
    }

    public void Evolution()
    {
        generate.Generate(gameManager.myId,fromIwasi.type + 1, fromIwasi.x, fromIwasi.y);
        fromIwasi.GiveOrTake(fromIwasi.sizeOfGroup / 2);
    }

    public void NoAction()
    {

    }
}

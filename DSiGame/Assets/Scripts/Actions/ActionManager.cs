using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ActionManager : MonoBehaviour
{
    public List<GameObject> nowPlayerGroup = new List<GameObject>();
    private IwasiCore fromIwasi;
    private IwasiCore toIwasi;

    private GenerateIwasi generate = new GenerateIwasi();

    // Start is called before the first frame update
    void Start()
    {
        //”z—ñ‘«‚è‚È‚¢Žž—p
        generate.Generate(0, 1, 1);
    }

    public void getID(int fromId, int toId)
    {
        fromIwasi = nowPlayerGroup[fromId].GetComponent<IwasiCore>();
        toIwasi= nowPlayerGroup[toId].GetComponent<IwasiCore>();
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
        generate.Generate(fromIwasi.type, fromIwasi.x, fromIwasi.y);
        fromIwasi.GiveOrTake(-val);
    }

    public void Evolution()
    {

    }

    public void NoAction()
    {

    }
}

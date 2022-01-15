using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IwasiClass : MonoBehaviour
{
    private int nextId = 0;

    [SerializeField] List<IwasiCore> IwasiList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("pushD");
            //IwasiList.Add(new IwasiCore(nextId++, 0));
        }
    }

}
[System.Serializable]
class IwasiCore
{
    public int id;
    public string name;
    public int type;
    public int attack;
    public int guard;
    public int x, y;
    public GameObject prefab;

    public IwasiCore(int _id, int _type = 0)
    {
        switch (_type)
        {
            case 0:
                name = "Shirasu";
                attack = 1;
                guard = 0;
                break;
        }
        x = y = 0;
    }
}

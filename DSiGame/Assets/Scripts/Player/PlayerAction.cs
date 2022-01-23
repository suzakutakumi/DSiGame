using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private ActionManager actionManager;

    public void Attack()
    {
        actionManager.Attack();
    }

    public void Exchange(string valstr)
    {
        int val = int.Parse(valstr);
        actionManager.Exchange(val);
    }

    public void Create(string valstr)
    {
        int val = int.Parse(valstr);
        actionManager.Create(val);
    }

    public void Evolution()
    {
        actionManager.Evolution();
    }
}

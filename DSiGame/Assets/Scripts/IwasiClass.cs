using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwasiClass : MonoBehaviour
{
    [SerializeField] List<IwasiCore> IwasiCore;
}
[System.Serializable]
class IwasiCore
{
    public string name;
    public int type;
    public int attack;
    public int guard;
    public int x, y;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnityThon : MonoBehaviour
{
    [SerializeField] List<string> list;
    void Start()
    {
        list = list.OrderBy( a => Guid.NewGuid () ).ToList ();

        foreach ( var item in list )
        {
            
            Debug.Log( item );
        }
    }
}

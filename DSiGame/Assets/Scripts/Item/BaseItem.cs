using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [Serializable]
    public abstract class BaseItem : MonoBehaviour
    {
        protected ItemType type;
    }
}

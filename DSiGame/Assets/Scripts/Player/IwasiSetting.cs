using System.Collections.Generic;
using UnityEngine;
using static Player.IwasiSettingTemp;

namespace Player
{
    public class IwasiSetting : MonoBehaviour
    {
        [SerializeField] private List<IwasiSettingTemp> iwasiList = new List<IwasiSettingTemp>();

        public IwasiSettingTemp GetIwasiSetting(int type)
        {
            return iwasiList[type];
        }
    }
}

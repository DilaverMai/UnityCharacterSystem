using System;
using Sirenix.OdinInspector;
using UnityEngine.Events;

namespace UpgradeSystem
{
    [Serializable]
    public class UpgradeEffect
    {
        [HideLabel]
        public UnityEvent OnUpgrade;
    }
}
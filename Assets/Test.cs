using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UpgradeSystem;

public class Test : MonoBehaviour
{
   public GameObject go;
   public string targetUpdate;
   public ItemsItemNames item;
   public void TestMethod()
   {
      go.SetActive(true);
   }
   
   [Button]
   public void TestMethod2()
   {
      FindObjectOfType<UpgradeManager>().AddItem(targetUpdate,item);
   }
}

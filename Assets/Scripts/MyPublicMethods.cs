using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPublicMethods : MonoBehaviour
{
    //Metodo para obtener un objeto mediante su tag, recorriendo todos los gameobjects desde el parent y los añade a su lista correspondiente
    public void GetChildObject(Transform parent, string _tag, List<GameObject> _list)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                _list.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                GetChildObject(child, _tag, _list);
            }
        }
    }
}

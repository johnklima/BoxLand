using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnableDisable : MonoBehaviour
{
    public GameObject[] toEnable;
    public GameObject[] toDisable;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in toEnable)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in toDisable)
        {
            obj.SetActive(false);
        }

    }

}

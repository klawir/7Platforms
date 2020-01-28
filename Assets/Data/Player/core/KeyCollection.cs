using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollection : MonoBehaviour
{
    public GameObject key;
    public Text amount;

    private void Awake()
    {
        amount.text = transform.childCount.ToString();
    }

    public void TakeKey()
    {
        Instantiate(key, transform);
        amount.text = transform.childCount.ToString();
    }

    public bool HasKeys
    {
        get { return transform.childCount >= 5; }
    }
    public int KeyNumber
    {
        get { return transform.childCount; }
    }
}

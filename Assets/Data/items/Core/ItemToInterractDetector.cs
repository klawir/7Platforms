using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public abstract class ItemToInterractDetector : DetectorController
{
    public Text interractKeyInfo;
    public string GUITextInterract;

    public abstract void BasicGUIText();

    public void DisableInterractKeyInfo()
    {
        interractKeyInfo.gameObject.SetActive(false);
    }
    public void EnableInterractKeyInfo()
    {
        interractKeyInfo.gameObject.SetActive(true);
    }
}

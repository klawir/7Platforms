using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilityUnlocker : MonoBehaviour
{
    public Image doubleJump;
    public Image sprint;

    public Text infoSprintPref;
    public Text infoDoubleJumpPref;
    public Transform thePlace;

    public Abilities abilities;

    private void UnlockDoubleJumpGUI()
    {
        doubleJump.enabled = true;
        Instantiate(infoDoubleJumpPref, thePlace);
    }
    private void UnlockSprintGUI()
    {
        sprint.enabled = true;
        Instantiate(infoSprintPref, thePlace);
    }
    public void UnlockDoubleJump()
    {
        abilities.jump.Unlock();
        UnlockDoubleJumpGUI();
    }
    public void UnlockSprint()
    {
        abilities.sprint.Unlock();
        UnlockSprintGUI();
    }
}

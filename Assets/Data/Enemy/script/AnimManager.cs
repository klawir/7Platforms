using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animation animation;

    public AnimationClip idle;
    public AnimationClip go;
    public AnimationClip attack;
    public AnimationClip die;

    public bool IsEndOfDeadAnim
    {
        get { return animation[die.name].time > animation[die.name].length - (animation[die.name].length / 100) * 5; }
    }
    public bool IsHitMomment(float hitMommentInPercent)
    {
        return animation[attack.name].time > (animation[die.name].length / 100) * hitMommentInPercent;
    }
    public bool IsBeginningOfAttack
    {
        get { return animation[attack.name].time > 0 && animation[attack.name].time <= (animation[attack.name].length / 100) * 10; }
    }
    public void Attack()
    {
        animation.Play(attack.name);
    }
    public void Die()
    {
        animation.Play(die.name);
    }
    public void Go()
    {
        animation.Play(go.name);
    }
    public void Idle()
    {
        animation.Play(idle.name);
    }

}

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
    public List<float> weaponsSpeedAttack;

    public float resetOfAttackForHitMommentInPercent;
    public float hitMommentInPercent;
    public float theEndOfDeadDetectInPercent;

    enum weaponsList { fastShootingWeapon, raycastWeapon, bazooke }

    public bool IsEndOfDeadAnim
    {
        get { return animation[die.name].time > animation[die.name].length - OnePercentOfDie * theEndOfDeadDetectInPercent; }
    }
    public bool IsHitMomment
    {
        get { return animation[attack.name].time > OnePercentOfAttack * hitMommentInPercent; }
    }
    public bool IsBeginningOfAttack
    {
        get { return animation[attack.name].time > 0 && animation[attack.name].time <= OnePercentOfAttack * resetOfAttackForHitMommentInPercent; }
    }
    private float OnePercentOfAttack
    {
        get { return (animation[attack.name].length / 100); }
    }
    private float OnePercentOfDie
    {
        get { return (animation[die.name].length / 100); }
    }
    public bool IsAttacking
    {
        get { return animation.IsPlaying(attack.name); }
    }
    public void SwitchToFastShootingWeapon()
    {
        animation[attack.name].speed = weaponsSpeedAttack[(int)weaponsList.fastShootingWeapon];
    }
    public void SwitchToRaycastWeapon()
    {
        animation[attack.name].speed = weaponsSpeedAttack[(int)weaponsList.raycastWeapon];
    }
    public void SwitchToBazooke()
    {
        animation[attack.name].speed = weaponsSpeedAttack[(int)weaponsList.bazooke];
    }
    public void ResetAttack()
    {
        animation[attack.name].time = 0;
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

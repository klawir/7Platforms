using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float range;
    public int dmg;

    public Health health;
    public PlatformTerrain platformTerrain;
    public Reward reward;
    public AnimManager animManager;
    public AudioSource attack;
    public Collider collider;
    public Transform model;
    public GameObject navigation;

    private Health detectedPlayer;
    private bool wasHit;

    void Update()
    {
        if (IsDead)
            Die();
        else
        {
            if (platformTerrain.IsPlayerDetected)
            {
                if (PlayerHasBeenSpotted)
                    TakePlayer();
                if (IsPlayerInRange)
                {
                    model.LookAt(detectedPlayer.transform);
                    animManager.Attack();
                    if (animManager.IsHitMomment && !wasHit)
                    {
                        attack.Play();
                        Hit();
                        wasHit = true;
                    }
                    if (animManager.IsBeginningOfAttack)
                        wasHit = false;
                }
            }
        }
        if (animManager.IsEndOfDeadAnim)
            Destroy(transform.parent.gameObject);
    }
    private bool PlayerHasBeenSpotted
    {
        get { return detectedPlayer == null; }
    }
    private void TakePlayer()
    {
        detectedPlayer = platformTerrain.DetectedPlayer;
    }
    public bool IsDead
    {
        get { return health.IsDead; }
    }
    public bool IsPlayerInRange
    {
        get { return Vector3.Distance(transform.position, detectedPlayer.transform.position) < range; }
    }
    public void Hit()
    {
        detectedPlayer.Remove(dmg);
    }
    private void Die()
    {
        Destroy(collider);
        Destroy(navigation);
        animManager.Die();
    }
    private void OnDestroy()
    {
        GameObject.FindObjectOfType<Player.Score>().Add(reward);
    }
}
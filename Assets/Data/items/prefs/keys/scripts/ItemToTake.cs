using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToTake : ItemToTakeControler
{
    public Reward reward;
    public Combat player;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        player.score.Add(reward);
        if(root.name=="key")
            player.GetComponent<Model>().TakeKey();
    }
}

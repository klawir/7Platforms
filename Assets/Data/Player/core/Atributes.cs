using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Atributes : MonoBehaviour
    {
        public int speed;

        public void UpdatePos()
        {
            transform.Translate(Move.movementVector);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : Command
    {
        private Atributes atributes;
        private Model model;
        private float xAxis;
        private float zAxis;
        private Transform root;

        public Movement(Transform root, Model model)
        {
            this.atributes = model.GetComponent<Atributes>();
            this.model = model;
            this.root = root;
        }
        public override void Execute()
        {
            xAxis = Input.GetAxis("Horizontal") * atributes.speed * Time.deltaTime;
            zAxis = Input.GetAxis("Vertical") * atributes.speed * Time.deltaTime;
            Move.movementVector = new Vector3(xAxis, 0, zAxis);
            root.Translate(Move.movementVector);
            model.UpdateRotation();
        }
    }
}
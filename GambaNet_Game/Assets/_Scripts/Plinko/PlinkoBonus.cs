using GambaNet.Wrapper;
using System.Collections;
using UnityEngine;

namespace GambaNet.Plinko
{
    public class PlinkoBonus : MonoBehaviour
    {
        private float value;
        private Rigidbody2D rb2D;

        private Vector3 lastKnownPosition = Vector3.zero;
        private Vector3 currectPosition = Vector3.zero;
        private int stuckCounter = 0;

        private void CheckStuck()
        {
            if (stuckCounter > 3)
            {
                if (rb2D == null)
                {
                    rb2D = GetComponent<Rigidbody2D>();
                }

                switch(Random.Range(0,2))
                {
                    case 0:
                        rb2D.AddForce(transform.right * -10, ForceMode2D.Impulse);
                        break;
                    case 1:
                        rb2D.AddForce(transform.right * 10, ForceMode2D.Impulse);
                        break;
                }

                return;
            }

            lastKnownPosition = currectPosition;

            if (lastKnownPosition == currectPosition)
            {
                stuckCounter++;
            }
            else
            {
                stuckCounter = 0;
            }
        }

        private void OnEnable()
        {
            InvokeRepeating("CheckStuck", 1, 1);
        }

        private void FixedUpdate()
        {
            currectPosition = transform.position;
        }

        public void Rig(float value)
        {
            this.value = value;
        }

        public float GetValue()
        {
            return value;
        }
    }
}
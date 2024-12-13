using GambaNet.Generic;
using GambaNet.Wrapper;
using UnityEngine;

namespace GambaNet.Plinko
{
    public class PlinkoColliderConstructor : MonoBehaviour
    {
        /* -- Demo test
        public Constructor colliderConstructor;
        public Constructor squareConstructor;
        */

        private float selectedValue = 0;
        public Constructor plinkoPlayerBallConstructor;

        public void SetValue(float val)
        {
            selectedValue = val;
        }

        public void Play()
        {
            CreditManager.Instance.UpdateBalance(-selectedValue);
            plinkoPlayerBallConstructor.Construct<PlinkoBonus>(1, (go, bonus) =>
            {
                go.transform.localPosition = new Vector3(Random.Range(-0.35f, 0.35f), 0, 0);
                go.GetComponent<PlinkoBonus>().Rig(selectedValue);
            });
        }

        /* -- Demo test
        public void Play()
        {
            colliderConstructor.Construct<PlinkoCollider>(Random.Range(50, 150), (go, collider) =>
            {
                go.transform.localPosition = new Vector3(Random.Range(-5.85f, 5.85f), Random.Range(-2.271f, 3f), 0);
            });

            squareConstructor.Construct<GameObject>(10, (go, collider) =>
            {
                go.transform.position = new Vector3(Random.Range(-5.4f, 5.4f), 3.5f, 0);
            });
        }
        */ 
    }
}

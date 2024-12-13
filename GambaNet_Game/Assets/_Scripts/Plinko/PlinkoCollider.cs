using System.Collections.Generic;
using UnityEngine;

namespace GambaNet.Plinko
{
    public class PlinkoCollider : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Rigidbody2D rb2D;
        public List<Sprite> availableSprites = new();
        public List<PhysicsMaterial2D> randomMaterials = new();

        private void Start()
        {
            spriteRenderer.sprite = availableSprites[Random.Range(0, availableSprites.Count)];
            TriggerNewRandomRotation();
            SetNewMaterial();
        }

        private void TriggerNewRandomRotation()
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-360, 360));
        }

        private void SetNewMaterial()
        {
            rb2D.sharedMaterial = randomMaterials[Random.Range(0, randomMaterials.Count)];
            TriggerNewRandomRotation();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 8)
            {
                SetNewMaterial();
            }
        }
    }
}
using UnityEngine;

namespace VB
{
    public class Wiggle : MonoBehaviour
    {
        // Token: 0x0400009C RID: 156
        [Header("Settings")]
        [SerializeField]
        private float wiggleSpeed = 5f;

        // Token: 0x0400009D RID: 157
        [SerializeField]
        private float wiggleRange = 0.5f;

        // Token: 0x0400009E RID: 158
        [SerializeField]
        private Transform wiggler;

        // Token: 0x0400009F RID: 159
        private Vector3 wigglePosition;

        private void Start()
        {
            wigglePosition = wiggler.position;
        }

        private void Update()
        {
            wiggler.localPosition = Vector3.MoveTowards(wiggler.localPosition, wigglePosition, wiggleSpeed * Time.deltaTime);
            if (Vector3.Distance(wiggler.localPosition, wigglePosition) < 0.1f)
            {
                wigglePosition = new Vector3(Random.Range(-wiggleRange, wiggleRange), Random.Range(-wiggleRange, wiggleRange), Random.Range(-wiggleRange, wiggleRange));
            }
        }
    }
}

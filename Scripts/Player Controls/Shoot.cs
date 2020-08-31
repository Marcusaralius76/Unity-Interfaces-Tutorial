using UnityEngine;
public class Shoot : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private Transform gunPoint = null;
    [SerializeField] private Transform hitSpotVisualizer = null;
    [SerializeField] private float gunForce = 0f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunShot();
        }
    }
    private void GunShot()
    {
        if (Physics.Raycast(gunPoint.position + gunPoint.forward, gunPoint.forward, out hit, Mathf.Infinity))
        {
            hitSpotVisualizer.position = hit.point;
            Transform hitTrans = hit.transform;
            ICanGetShot getShotController = hitTrans.GetComponent<ICanGetShot>();
            if(getShotController != null)
            {
                getShotController.GetShot();
            }
            else
            {
                Rigidbody rb = hitTrans.GetComponent<Rigidbody>();
                if (rb != null) rb.AddForce(transform.forward * gunForce, ForceMode.Impulse);
            }
        }
    }
}
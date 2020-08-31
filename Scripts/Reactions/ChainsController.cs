using UnityEngine;
public class ChainsController : MonoBehaviour, ICanGetShot
{
    [SerializeField] private Rigidbody hostageRB = null;
    [SerializeField] private StateStorage hostageState = null;
    [SerializeField] private ParticleSystem spark = null;
    public void GetShot()
    {
        spark.Play();
        hostageRB.constraints = RigidbodyConstraints.None;
        hostageState.BlowChains();
    }
}
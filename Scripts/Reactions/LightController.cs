using UnityEngine;
public class LightController : MonoBehaviour, ICanGetShot
{
    [SerializeField] private GameObject pointLight = null;
    [SerializeField] private Rigidbody lightHolder = null;
    [SerializeField] private ParticleSystem particles = null;
    private bool isShot = false;
    private Light lightCont;
    private Rigidbody lightRB;
    private float timer = 0f;
    private void Awake()
    {
        lightCont = pointLight.GetComponent<Light>();
        lightRB = lightHolder.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!isShot) return;
        lightCont.intensity = timer * 40f + 1f;
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            pointLight.SetActive(false);
            lightRB.constraints = RigidbodyConstraints.None;
            particles.Play();
            isShot = false;
        }
    }
    public void GetShot()
    {
        isShot = true;
    }
}
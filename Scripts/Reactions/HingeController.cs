using UnityEngine;
public class HingeController : MonoBehaviour, ICanGetShot
{
    [SerializeField] private GameObject door = null;
    private DoorController controller;
    private void Awake()
    {
        controller = door.GetComponent<DoorController>();
    }
    public void GetShot()
    {
        controller.hinges.Remove(transform);
        controller.CheckHinges();
        gameObject.SetActive(false);
    }
}
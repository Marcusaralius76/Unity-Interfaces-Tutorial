using UnityEngine;
public class BadGuyController : MonoBehaviour, ICanGetShot
{
    public void GetShot()
    {
        gameObject.SetActive(false);
    }
}
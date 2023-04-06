using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float deactivationTime;

    public void DeativationCountDown()
    {
        Invoke(nameof(Deactivation), deactivationTime);
    }

    private void Deactivation()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}

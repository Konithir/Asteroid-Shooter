using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GameBounds : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _boxCollider;

    private PlayerShipController player;

    private void OnTriggerExit(Collider other)
    {
        HandleWrappedScreenTeleport(other);
    }

    private void HandleWrappedScreenTeleport(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = GameManager.Singleton.PlayerShipController;

            if (other.transform.position.y > _boxCollider.size.y)
            {
                player.TeleportShipToPoint(new Vector3(player.transform.localPosition.x, -_boxCollider.size.y / 2, player.transform.localPosition.z));
            }
            else if (other.transform.position.y < _boxCollider.bounds.min.y)
            {
                player.TeleportShipToPoint(new Vector3(player.transform.localPosition.x, _boxCollider.size.y/2, player.transform.localPosition.z));
            }


            if (other.transform.position.x > _boxCollider.size.x)
            {
                player.TeleportShipToPoint(new Vector3(-_boxCollider.size.x / 2, player.transform.localPosition.y, player.transform.localPosition.z));
            }
            else if (other.transform.position.x < _boxCollider.bounds.min.x)
            {
                player.TeleportShipToPoint(new Vector3(_boxCollider.size.x / 2, player.transform.localPosition.y, player.transform.localPosition.z));
            }
        }
    }
}

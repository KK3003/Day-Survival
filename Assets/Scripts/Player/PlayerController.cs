using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField]
    bool isGrounded;
    public Rigidbody rb;
    public Transform bulletspawnPos;
    public Interactable focus;
    int firedBUllets = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        InputManager.OnMoveForward += MoveForward;
        InputManager.OnMoveBackward += MoveBackward;
        InputManager.OnRotateLeft += RotateLeft;
        InputManager.OnRotateRight += RotateRight;
        InputManager.OnShootBullet += ShootBullet;
        InputManager.OnJump += Jump;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        StartCoroutine(DestroyEnimies());
    }

    private void MoveForward()
    {
        transform.position += transform.forward *10f * Time.deltaTime;    
    }

    private void MoveBackward()
    {
        transform.position += transform.forward *-10f * Time.deltaTime;
        
    }

    private void RotateLeft()
    {
        transform.Rotate(Vector3.up, -90f * Time.deltaTime);
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime);
    }

    private void ShootBullet()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (PlayerManager.instance.canShoot == true)
        {
            BulletService.Instance.CreateNewBullet(bulletspawnPos);
            firedBUllets += 1;
            BulletService.Instance?.bulletFiredbyPlayer(firedBUllets);
        } 
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * 6f, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    public Transform PlayerPosition() { return this.transform; }

    private void OnDisable()
    {
        InputManager.OnMoveForward -= MoveForward;
        InputManager.OnMoveForward -= MoveBackward;
        InputManager.OnRotateLeft -= RotateLeft;
        InputManager.OnRotateRight -= RotateRight;
        InputManager.OnJump -= Jump;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    IEnumerator DestroyEnimies()
    {
        if (PlayerManager.instance.currentHealth <= 0)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
            yield return new WaitForSeconds(1f);
           
        }
    } 
}

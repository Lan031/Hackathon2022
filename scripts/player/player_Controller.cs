using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(Player_Inventory))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class player_Controller : MonoBehaviour
{
    /// <summary>
    /// this is universal for all 3 player characters
    /// so things like weapons will be set individualy as serialized fields and animation things
    /// </summary>

    public GameObject ShotPoint;

    public Animator animator;
    public PlayerInput input;
    private Player_Inventory inv;

    private Vector2 movementVec;
    [SerializeField] private float speed;

    private Vector2 shootingVec;
    
    private Rigidbody2D rb;
    private Collider2D cl;
    private CinemachineVirtualCamera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<CapsuleCollider2D>();
        cam = GameObject.FindGameObjectWithTag("Cinemachine cam").GetComponent<CinemachineVirtualCamera>();
        inv = GetComponent<Player_Inventory>();
    }
    private void Start()
    {
        cam.Follow = this.transform;
    }

    private void FixedUpdate()
    {
        Move();
        attack();
        AnimatorHandle();
    }

    private void AnimatorHandle()
    {
        float HorMovVal = Mathf.Clamp(movementVec.x + (shootingVec.x * 2), -1, 1);
        float VerMovVal = Mathf.Clamp(movementVec.y + (shootingVec.y * 2), -1, 1);
        animator.SetFloat("horizontal", HorMovVal);
        animator.SetFloat("vertical", VerMovVal);

    }

    private void Move()
    {
        //figure out acceleration if time
        rb.MovePosition(rb.position + movementVec * Time.deltaTime * speed);
        animator.SetFloat("speed", (movementVec * Time.deltaTime * speed).sqrMagnitude);
    }

    void attack()
    {

        Vector2 ShotPos = shootingVec;
        ShotPoint.transform.localPosition = new Vector3(ShotPos.x, ShotPos.y, 0);
        //fire/attack
        //instantiate object that attacks(bullet for shotgun empty for melee)
        //melee just instantiates an object with a box/circle collider and checks from there
    }

    #region input functions
    public void Onsearch(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            //search
            Collider2D[] interactables = Physics2D.OverlapCircleAll(transform.position, 1.55f);
            if(interactables != null)
            {
                foreach (Collider2D collider in interactables)
                {
                    GameObject obj = collider.gameObject;
                    switch (obj.tag)
                    {
                        case "key_card":
                            inv.cards.Add(obj.GetComponent<KeyCard>());
                            obj.SetActive(false);
                            break;
                        case "fuse box":
                            obj.GetComponent<FuseBox>().Interact();
                            break;
                        case "generator":
                            if(gameObject.name == "Engineer(Clone)")
                            {
                                obj.GetComponent<Generator>().Interact();
                            }
                            break;
                        case "broken fuse":
                            obj.GetComponent<Broken_Fuse>().Interact(gameObject.name);
                            break;
                        case "singularity":
                            if (gameObject.name == "scientist(Clone)")
                            {
                                obj.GetComponent<Singularity>().Interact();
                            }
                            break;
                        case "EscapePoint":
                            //escape menu thing
                            Destroy(obj);
                            Destroy(gameObject);
                            break;
                    }
                }
            }
        }
    }
    public void OnMove(InputAction.CallbackContext value)
    {
        //move
        movementVec = value.ReadValue<Vector2>();
        Debug.Log(movementVec);

    }
    public void Onshoot(InputAction.CallbackContext value)
    {
        shootingVec = value.ReadValue<Vector2>();
        Debug.Log(shootingVec);
    }
    #endregion
}

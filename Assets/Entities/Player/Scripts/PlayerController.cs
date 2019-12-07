using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody2D rb;
    private Animator anim;
    private Transform groundCheck;

    private GameObject sword;
    public GameObject spear;
    public float spearForce;

    public Joystick joystick;

    private float direction;

    public float velocity;
    public float jumpForce;
    public float cooldown;

    private float timer;

    private bool onGround;

    private float yAnterior;

    private bool atk1 = false;
    private Vector2 atk2 = Vector2.zero;

    private bool pulo = false;

    void Start(){

        sword = GameObject.FindGameObjectWithTag("Sword");
        sword.SetActive(false);

        timer = 0;
        groundCheck = gameObject.transform.Find("GroundCheck");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update(){

        timer += Time.deltaTime;

        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


        //Controle horizontal do personagem

        if(joystick.Horizontal == 0){
            direction = Input.GetAxis("Horizontal");
        } else{
            if(joystick.Horizontal>0.2f){
                if(joystick.Horizontal>0.6f){
                    direction = 1;
                } else{
                    direction = 0.5f;
                }
            }else if(joystick.Horizontal<-0.2f){
                if(joystick.Horizontal<-0.6f){
                    direction = -1;
                } else{
                    direction = -0.5f;
                }
                
            } else{
                direction = 0;
            }

        }
        

        if (direction != 0) {
            if (onGround) {
                anim.SetBool("running", true);
            }

            if(direction > 0) {
                transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            } else if(direction < 0) {
                transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            }
            transform.position = new Vector2(transform.position.x + (direction*velocity/10), transform.position.y);
        } else {
            anim.SetBool("running", false);
        }

        //Controle de ataque do personagem

       if (Input.GetAxis("Attack1") > 0 || atk1) {
            sword.SetActive(true);
            anim.SetBool("atk1", true);
            timer = 0;
            atk1 = false;
                
       } else if (Input.GetAxis("Attack2") > 0 || atk2 != Vector2.zero) {
           anim.SetBool("atk2", true);
           InstantiateSpear(atk2);
           atk2 = Vector2.zero;
           //Fazer mecanica de ataque
       } else {
           if(timer >= cooldown) {
                sword.SetActive(false);
                timer = 0;
                
            }
            anim.SetBool("atk1", false);
            anim.SetBool("atk2", false);
           
       }

        //Controle vertical do personagem

        if (!onGround) {
            if(transform.position.y <= yAnterior) {
                anim.SetBool("Jump", false);
                anim.SetBool("Down", true);
                anim.SetBool("Up", false);
            } else {
                anim.SetBool("Up", true);
                anim.SetBool("Down", false);
            }
            pulo = false;
        } else {
            anim.SetBool("Jump", false);
            anim.SetBool("Down", false);
            anim.SetBool("Up", false);
            if((Input.GetAxis("Jump") > 0 || joystick.Vertical > 0.3f) && !pulo){
                rb.AddForce(new Vector2(0, jumpForce));
                anim.SetBool("Jump", true);
                pulo = true;
            } else{
                pulo = false;
            }
        }

        yAnterior = transform.position.y;

        
    }

    public void ControleAtk(Vector2 direcao){
        if(direcao.x >0.3f || direcao.y >0.3f ||direcao.x <-0.3f || direcao.y <-0.3f){
            atk2 = direcao;
        } else{
            atk1 = true;
        }
        
    }

    public void InstantiateSpear(Vector2 direcao){
       GameObject nSpear = GameObject.Instantiate(spear);
       Vector3 dir = new Vector3(nSpear.transform.position.x+direcao.x, nSpear.transform.position.y+direcao.y, 1f);
       nSpear.transform.right = direcao;
       nSpear.transform.position = transform.Find("bone_006").Find("Body").position;
       nSpear.GetComponent<Rigidbody2D>().AddForce(direcao*spearForce);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    public string scene;
    float shreshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        {   //�����Ѵ�
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            this.animator.SetTrigger("jump");

        }

        //�¿��̵�
        int key = 0;
        if (Input.acceleration.x > this.shreshold) key = 1;
        if (Input.acceleration.x < -this.shreshold) key = -1;

        

        //�÷��̾� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
            
           
        }
        //�����̴� ���⿡ ���� �����Ѵ�.
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("����~!");
        SceneManager.LoadScene(scene);
    }
}

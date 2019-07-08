using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public LayerMask blockLayer;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip audioClip;
    AudioSource audioSource;

    private Rigidbody2D rbody;      //プレイヤー制御用Rigidbody2D
    private Animator animator;

    [SerializeField]private float jumpPower;  //ジャンプの力
    private bool goJump = false;    //ジャンプしたか否か
    private bool isGround = false;   //ブロックに接地しているか否か


    // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

   
    private void Update()
    {

        //isGround =
        //  Physics2D.Linecast((transform.position - transform.up * 1.0f), (transform.position - transform.up * 2f), blockLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            PushJumpButton();
        }
        else
        {
            goJump = false;
        }

            //ジャンプ処理
            if (goJump)
        {
            audioSource.PlayOneShot(sound1);
            rbody.AddForce(Vector2.up * jumpPower);
            goJump = false;
        }
    }

    //ジャンプボタンを押した
    public void PushJumpButton()
    {
        if (isGround)
        {
            goJump = true;
            animator.SetBool("jumping", true);
            Debug.Log("pushed");
            isGround = false;
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shougaibutu")
        {
            isGround = false;
            audioSource.Stop();
            audioSource.PlayOneShot(sound2);
            StartCoroutine("Wait");
            Time.timeScale = 0;
            GameObject.Find("GameObject").GetComponent<SceneControl>().score = (int)GameObject.Find("Text").GetComponent<Score>().distance;


         }
        else
        {
            audioSource.Play();
            Debug.Log(isGround);
            isGround = true;
            animator.SetBool("jumping", false);
        }
    }

    IEnumerator Wait()
    {
        for (int i = 0; i < 120; i++)
        {
            yield return null;
        }
        SceneManager.LoadScene("ResultScene");
    }
}

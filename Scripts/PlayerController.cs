using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;//hraði
    public GameObject player;
    public Text countText;//fyrir textan uppi í horninu sem telur krónurnar
    public Text winText;//Fyrir texta
    public bool grounded = true;//til að sjá hvort spilari sé á jörðinni

    private Rigidbody rb;//rb er ridgid body
    private int count;//fyrir teljarann

    public void Grounded()//til þess að gá hvort spilari sé á jörðinni
    {
        grounded = true;//þú ert á jörðinni
        Debug.Log("Grounded");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();//nær í ridgid body
        count = 3;//teljarinn er 0
        SetCountText();
        winText.text = "";//setur textan að engu
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//Þetta er til þess að hreyf sig áframm 
        float moveVertical = Input.GetAxis("Vertical");//og til hliðar 

        Vector3 targetDirection = new Vector3(moveHorizontal, 0f, moveVertical);//til þess að þú munir alltaf hreyfa þig áfram frá sjónarhorni spilarans
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);//Sjá fyrir ofan
        targetDirection.y = 0.0f;//þú ferð aldrei upp með wasd eða örvunum


        rb.AddForce(targetDirection * speed);//Fyrir hoppið
        if (Input.GetKey(KeyCode.Space) && grounded == true)//Ef þú ert á jörðinni
        {
            grounded = false;//þú ert að hoppa svo þú ert ekki á jörðinni
            rb.AddForce(0, 500 * Time.deltaTime, 0, ForceMode.Impulse);//lætur þig hreyfa þig upp í smá tíma
        }
    }

    void OnTriggerEnter(Collider other)//fyrir krónurnar
    {
        if (other.gameObject.CompareTag("Pick Up"))//ef þetta er af gerðinni pick upp
        {
            other.gameObject.SetActive(false);//lætur hlutinn hverfa
            count = count + 1;//bætir einum við á stigatöfluna
            SetCountText();//breytir stigunum á skjáinum

        }
        if (other.gameObject.CompareTag("Endgame"))//ef þetta er af gerðinni Endgame
        {
            other.gameObject.SetActive(false);//lætur hlutinn hverfa
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Leikurinn breytir um borð

        }

        if (other.gameObject.CompareTag("Enemy"))//ef þetta er af gerðinni Enemy
        {
            if (count != 1)
            {
                count = count - 1;//tekur einn af á lífinu
                SetCountText();//breytir stigunum á skjáinum
                player.transform.position =  new Vector3(0, 3, 0);
            }
            else if (count == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);//Leikurinn breytir um borð
            }
        }
    }
    void SetCountText()
    {
        countText.text = "Health: " + count.ToString();
    }
}
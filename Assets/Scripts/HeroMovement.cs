using UnityEngine;
using UnityEngine.UI;
using static DayNight;


public class HeroMovement : MonoBehaviour
{
    private int needToCollect = 7;
    public static int spheresCollected, HP = 3;
    private Animator anim;
    public GameObject nextLevel, restartLevel, menu;
    public static int score, bestScore;
   

    private AudioSource arc;
    [SerializeField] public AudioClip damaged;
    [SerializeField] public AudioClip collect;
    [SerializeField] public AudioClip move;

    private void Start()
    { 
        anim = GetComponent<Animator>(); 
        arc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x != -12 && DAY == false)
        {
            transform.position += new Vector3(-2, 0, 0);
            arc.PlayOneShot(move);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y != 6 && DAY == false)
        {
            transform.position += new Vector3(0, 2, 0);
            arc.PlayOneShot(move);
        }
        
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x != 12f && DAY == false)
        {
            transform.position += new Vector3(2, 0, 0);
            arc.PlayOneShot(move);
        }
        
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y != -6f && DAY == false)
        {
            transform.position += new Vector3(0, -2, 0);
            arc.PlayOneShot(move);
        }


        if(HP == 0)
        {
            if (score >= bestScore)
                bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            timerIsRunningN = false;
            menu.SetActive(true);
            restartLevel.SetActive(true);
            Destroy(gameObject, 0.2f);
        }
        
        if(spheresCollected == needToCollect)
        {
            timerIsRunningN = false;
            gameObject.transform.position = new Vector3(0, 0, 0);
            nextLevel.SetActive(true);
        }
        else nextLevel.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dark"))
        {
            arc.PlayOneShot(damaged);
            HP--;
            anim.SetTrigger("hurt");
        }

        if (collision.gameObject.CompareTag("Light"))
        {
            arc.PlayOneShot(collect);
            spheresCollected++;
            score++;
        }
    }
}

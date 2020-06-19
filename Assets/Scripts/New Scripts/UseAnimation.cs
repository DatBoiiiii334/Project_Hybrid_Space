using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UseAnimation : MonoBehaviour
{
    public static UseAnimation Anim_instance = null;


    public float animDuration;
    public string animBoolName;
    public AudioClip Soundeffect;

    public Animator myAnimator;
    public GameObject myObject ;

    [Header("Variabelen animatie")]
    public Text TitleAnim;
    public Text DescAnim;
    public Sprite ImageAnim;
    public Image PlaceholderImage;

    public int[] IdList;

    public GameObject Brood;
    public GameObject SpawnCube;

    private void Awake()
    {


        //Singleton of the UseAnimation
        if (Anim_instance == null)
            Anim_instance = this;
        else if (Anim_instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {

        if(myAnimator == null) {
            //Debug.LogError("Animator is missing!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Achievement("Hello", "Friend", ImageAnim);
        }
    }


    public void Achievement(string myTitle, string myDesc, Sprite myImage)
    {
        //if()

        TitleAnim.text = myTitle;
        DescAnim.text = myDesc;
        PlaceholderImage.sprite = myImage;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = myImage;
        StartCoroutine(PlayAnimation());
        //Debug.Log("Won Animation");
    }

    public IEnumerator PlayAnimation()
    {
        SoundManager.instance.PlaySoundEffect(this.Soundeffect, 3f, this.transform.position);
        myObject.SetActive(true);
        myAnimator.SetBool(animBoolName, true);
        yield return new WaitForSeconds(animDuration);
        myAnimator.SetBool(animBoolName, false);
        myObject.SetActive(false);
        StopCoroutine(PlayAnimation());
    }

    public IEnumerator BlinkBread()
    {
        Brood.SetActive(false);
        yield return new WaitForSeconds(1f);
        Brood.transform.position = SpawnCube.transform.position;
        Brood.SetActive(true);
        Debug.Log("Bread has been teleported");
        StopCoroutine(BlinkBread());


    }
}

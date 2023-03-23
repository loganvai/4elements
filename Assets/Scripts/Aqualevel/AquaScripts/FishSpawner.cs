using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FishSpawner : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] public GameObject Fish;
    public TextMeshProUGUI message;
    public TextMeshProUGUI message1;
    FishForce fishForce;

    float bigtimestart = 23f;

    public float minDistance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

        fishForce = Fish.GetComponent<FishForce>();
      
        message1.text = bigtimestart.ToString();


    

        Invoke("Top", 3f);
        Invoke("Right", 8f);
        Invoke("Left", 13f);
        Invoke("Bot", 18f);
        

    }


    // Update is called once per frame
    void Update()
    {

        
        if(Mathf.Round(bigtimestart) == 0)
        {
            bigtimestart = 0;
            canvas.SetActive(true);
        }
        else
        {
            bigtimestart -= Time.deltaTime;
            message1.text = Mathf.Round(bigtimestart).ToString();
        }


    }
    void SpawnFish(float positionx1, float positionx2, float positiony1, float positiony2, int rotation, float speedx, float speedy)
    {
        for (int i = 0; i < 4f; i++)
        {
            bool foundsPosition = false;
            Vector2 spawnPosition = Vector2.zero;
            while (!foundsPosition)
            {
                spawnPosition = new Vector2(Random.Range(positionx1, positionx2), Random.Range(positiony1, positiony2));

                Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, minDistance);
                foundsPosition = true;
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.tag == "Player")
                    {
                        foundsPosition = false;
                        break;
                    }
                }
            }

            Instantiate(Fish, spawnPosition, Quaternion.Euler(0, 0, rotation));  
            fishForce.speedx = speedx;
            fishForce.speedy = speedy;
        }

    }

    void Top()
    {
        message.text = "From Top";
        Vector3 localscale = Fish.transform.localScale;
        if (localscale.x < 0)
        {
            localscale.x *= -1f;
        }
        Fish.transform.localScale = localscale;
        SpawnFish(2.648f, 7.61f, 2.2f, 2.2f, 90, 0, -3f);

    }
    void Right()
    {
        message.text = "From Right ";
        Vector3 localscale = Fish.transform.localScale;
        if (localscale.x < 0)
        {
            localscale.x *= -1f;
        }
        Fish.transform.localScale = localscale;
        SpawnFish(9.273f, 9.273f, 1.18f, -3.801f, 0, -3f, 0);
     
    }
    void Left()
    {
        message.text = "From Left ";
        Vector3 localscale = Fish.transform.localScale;
        if (localscale.x > 0)
        {
            localscale.x *= -1f;
        }
        Fish.transform.localScale = localscale;
        SpawnFish(1.206f, 1.206f, 1.18f, -3.801f, 0, 3f, 0);
  
    }
    void Bot()
    {
        message.text = "From Botttom";
        Vector3 localscale = Fish.transform.localScale;
        if (localscale.x < 0)
        {
            localscale.x *= -1f;
        }
        Fish.transform.localScale = localscale;
        SpawnFish(2.87f, 7.839f, -5.27f, -5.27f, -90, 0, 3f); ;
   
    }

        //}
        //if(localscale.x >0)
        //    {
        //        localscale.x *= -1f;
        //    }
        //Fish.transform.localScale = localscale;

    
}

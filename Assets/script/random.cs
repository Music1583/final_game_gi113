using UnityEngine;

public class RandomSprite : MonoBehaviour
{


    public GameObject[] water;
    public GameObject[] snack;
    public SpriteRenderer spriteRenderer; 
    public Sprite[] spriteList;           
    public void ChangeRandomSprite()
    {
        if (spriteList.Length > 0)
        {
            int randomIndex = Random.Range(0, spriteList.Length);
            spriteRenderer.sprite = spriteList[randomIndex];
        }
    }
    int item;
    void Start()
    {
        item = Random.Range(1, 4);
        ChangeRandomSprite();
        SetPointRandomSprite();
    }
    public void SetPointRandomSprite()
    {
        if (item == 1)
        {
            water[0].SetActive(true);
            water[1].SetActive(false);
            water[2].SetActive(false);
            water[3].SetActive(true);
            snack[0].SetActive(false);
            snack[1].SetActive(true);
            snack[2].SetActive(true);
            snack[3].SetActive(false);
        }
        else if (item == 2)
        {
            water[0].SetActive(false);
            water[1].SetActive(true);
            water[2].SetActive(true);
            water[3].SetActive(false);
            snack[0].SetActive(true);
            snack[1].SetActive(false);
            snack[2].SetActive(false);
            snack[3].SetActive(true);
        }
        else if (item == 3)
        {
            water[0].SetActive(true);
            water[1].SetActive(false);
            water[2].SetActive(true);
            water[3].SetActive(false);
            snack[0].SetActive(true);
            snack[1].SetActive(true);
            snack[2].SetActive(false);
            snack[3].SetActive(false);
        }
        else
        {
            return;
        }
    }
}
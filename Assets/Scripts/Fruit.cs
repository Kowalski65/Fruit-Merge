using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int fruitLevel; // 0 = maþiausias vaisius, didëja su sinteze
    public GameObject nextFruitPrefab; // Prefabas didesniam vaisiui

    private bool isMerging = false; // Apsauga nuo keliø sintezës veiksmø

    void OnCollisionEnter2D(Collision2D collision)
    {
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit != null && otherFruit.fruitLevel == fruitLevel && !isMerging)
        {
            isMerging = true;
            otherFruit.isMerging = true;

            Vector3 mergePosition = (transform.position + otherFruit.transform.position) / 2;
            GameObject newFruit = Instantiate(nextFruitPrefab, mergePosition, Quaternion.identity);

            ScoreManager.Instance.AddScore((fruitLevel + 1) * 10);

            Destroy(otherFruit.gameObject);
            Destroy(gameObject);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Yamacard : MonoBehaviour
{
    [SerializeField] Transform YamaPosi;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] int cardNum;

    // 山札
    private List<GameObject> deck = new List<GameObject>();

    void Start()
    {
        CreateDeck();
        ShuffleDeck();
    }

    // 山札作成
    void CreateDeck()
    {
        for (int i = 0; i < cardNum; i++)
        {
            GameObject card = Instantiate(cardPrefab, YamaPosi, false);
            deck.Add(card);
        }
    }

    // シャッフル
    void ShuffleDeck()
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            GameObject temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
    public GameObject DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.Log("山札がありません");
            return null;
        }

        GameObject card = deck[0];
        deck.RemoveAt(0);

        return card;
    }
}

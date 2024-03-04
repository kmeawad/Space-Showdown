using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public int numberOfCards;
    public List<GameObject> deck;
    public Vector3 offset; // Offset between cards

    private List<GameObject> instantiatedCards = new List<GameObject>();
    private int currentIndex; // Index to keep track of next card to pull out of the deck

    // Start is called before the first frame update
    void Start()
    {
        ListShuffler.Shuffle(deck);

        // Instantiate cards
        for (int i = 0; i < numberOfCards; i++)
        {
            Vector3 position = gameObject.transform.position + i * offset;
            GameObject newCard = Instantiate(deck[i], position, deck[i].transform.rotation);
            instantiatedCards.Add(newCard);
        }

        currentIndex = instantiatedCards.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to replace a destroyed card
    public void ReplaceDestroyedCard(GameObject destroyedCard)
    {
        // Find the index of the destroyed card
        int index = instantiatedCards.IndexOf(destroyedCard);
        if (index != -1)
        {
            //Increase current index by 1 or reset to 0 if reached last card in deck
            currentIndex = currentIndex >= deck.Count - 1 ? 0 : currentIndex + 1;

            // Instantiate a new card in the same position
            Vector3 position = destroyedCard.transform.position;
            GameObject newCard = Instantiate(deck[currentIndex], position, deck[currentIndex].transform.rotation);

            // Replace the destroyed card with the new card
            instantiatedCards[index] = newCard;

            // "Destroy" card
            // Loop through each child of the card and make deactivate it so that it disappears
            for (int i = 0; i < destroyedCard.transform.childCount; i++)
            {
                // Get the child GameObject at index i and disable it
                destroyedCard.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Destroyed card not found in the instantiated cards list.");
        }
    }

}

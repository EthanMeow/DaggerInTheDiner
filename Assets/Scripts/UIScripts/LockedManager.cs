using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // Dictionary to store references to UI objects and their unlock states
    private Dictionary<GameObject, bool> itemUnlockStates;

    public static UnlockManager Instance { get; private set; }  // Singleton instance

    private void Awake()
    {
        // Ensure that there is only one instance of UnlockManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        itemUnlockStates = new Dictionary<GameObject, bool>();  // Initialize the dictionary
    }

    // Method to unlock an item
    public void UnlockItem(GameObject item)
    {
        if (!itemUnlockStates.ContainsKey(item))
        {
            itemUnlockStates[item] = true;  // Unlock the item if it's not already in the dictionary
        }
        else
        {
            itemUnlockStates[item] = true;  // Update the state to unlocked
        }

        Debug.Log(item.name + " is now unlocked!");
    }

    // Method to check if an item is unlocked
    public bool IsItemUnlocked(GameObject item)
    {
        if (itemUnlockStates.ContainsKey(item))
        {
            return itemUnlockStates[item];
        }

        return false;  // Default is locked if the item is not in the dictionary
    }

    // Optionally: Reset all items (for example, for testing purposes)
    public void ResetUnlocks()
    {
        itemUnlockStates.Clear();
    }
}

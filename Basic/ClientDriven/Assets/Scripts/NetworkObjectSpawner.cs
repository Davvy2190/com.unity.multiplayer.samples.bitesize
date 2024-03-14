using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;

public class NetworkObjectSpawner : NetworkBehaviour
{
    [SerializeField] NetworkObject prefabReference;

    public void Start()
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStartedIngredientSpawn;
    }

    void OnServerStartedIngredientSpawn()
    {
        Random randomGenerator = new Random();
        var instantiatedNetworkObject = Instantiate(prefabReference, transform.position, transform.rotation, null);
        var ingredient = instantiatedNetworkObject.GetComponent<ServerIngredient>();
        ingredient.NetworkObject.Spawn();
        ingredient.currentIngredientType.Value = (IngredientType)randomGenerator.Next((int)IngredientType.MAX);
    }
}
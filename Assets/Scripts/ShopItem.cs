using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShopItem : MonoBehaviour
{
    enum ItemType { background, decoration, food }

    [Header("Presets")]
    [SerializeField] ItemType itemType;
    [SerializeField] List<GameObject> reference = new List<GameObject>();
    [SerializeField] List<Button> buttons = new List<Button>();
    
    List<GameObject> backgrounds = new List<GameObject>();

    string itemName;
    int cost;
    float happiness;

    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(ShopItem))] 
    public class ShopItemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ShopItem shopItem = (ShopItem)target;

            DrawDetails(shopItem);

            List<GameObject> list = shopItem.backgrounds;
            int size = Mathf.Max(0, EditorGUILayout.IntField("Size", list.Count));

            while (size > list.Count)
            {
                list.Add(null);
            }
            while (size < list.Count)
            {
                list.RemoveAt(list.Count - 1);
            }
            for(int i=0; i<list.Count; i++)
            {
                list[i] = EditorGUILayout.ObjectField("Element " + i, list[i], typeof(GameObject), true) as GameObject;
            }
        }

        static void DrawDetails(ShopItem shopItem)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Details");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("itemName", GUILayout.MaxWidth(50));
            shopItem.itemName = EditorGUILayout.TextField(shopItem.itemName);
            EditorGUILayout.LabelField("cost", GUILayout.MaxWidth(50));
            shopItem.cost = EditorGUILayout.IntField(shopItem.cost);
            EditorGUILayout.LabelField("happiness", GUILayout.MaxWidth(75));
            shopItem.happiness = EditorGUILayout.FloatField(shopItem.happiness);
            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion


}


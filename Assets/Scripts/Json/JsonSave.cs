using UnityEngine;

public class JsonSave : MonoBehaviour
{
    int save = 0;
    public static JsonSave json;
    public ItemData item;
    private void Awake()
    {
        json = this;
    }
    #region StartSave
    public void StartSave()
    {
        if (PlayerPrefs.GetInt("Save") == 0)
        {
            SaveManager.Save(item);
            save++;
            PlayerPrefs.SetInt("Save", save);
        }
        item = SaveManager.Load();
    }
    #endregion
}

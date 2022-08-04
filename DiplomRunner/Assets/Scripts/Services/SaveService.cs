using DefaultNamespace.Interfaces;
using UnityEngine;

namespace Services
{
    public class SaveService: ISaveService
    {
        public void Write(object obj, string name)
        {
            var json = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(name, json);
        }

        public T Load<T>(string name)
        {
            if (PlayerPrefs.HasKey(name))
            {
                var json = PlayerPrefs.GetString(name);
                if (json == null) return default;
                return JsonUtility.FromJson<T>(json);
            }

            return default;
        }

        public void Save()
        {
            PlayerPrefs.Save();
        }
    }

    public static class SaveServiceExt
    {
        public static T Load<T>(this ISaveService self)
        {
            return self.Load<T>(nameof(T));
        }

        public static void Write <T>(this ISaveService self, T obj)
        {
            self.Write(obj, nameof(T));
        }
    } 
}
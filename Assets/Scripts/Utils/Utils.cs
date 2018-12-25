using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
    public static Transform FindChildTransform(GameObject obj, string objName)
    {
        if (obj != null)
        {
            string[] name_path = objName.Split('/');
            return FindChildTransform(obj.transform, name_path);
        }
        return null;
    }

    private static Transform FindChildTransform(Transform obj, string[] name_path)
    {
        string lastName = name_path[name_path.Length - 1];

        int count = obj.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform tf = obj.GetChild(i);
            if (tf.gameObject.name == lastName)//初步判定ok
            {
                bool isCmpOK = true;
                Transform parentTransform = tf.gameObject.transform.parent;
                for (int p = name_path.Length - 2; p >= 0; p--)
                {
                    if (parentTransform == null) { isCmpOK = false; break; }

                    if (parentTransform.gameObject.name != name_path[p]) { isCmpOK = false; break; }

                    parentTransform = parentTransform.parent;
                }

                if (isCmpOK) return tf;
            }

            tf = FindChildTransform(tf, name_path);
            if (tf != null) return tf;
        }
        return null;
    }

    public static GameObject FindChild(GameObject self, string objName)
    {
        string[] name_path = objName.Split('/');
        Transform tf = FindChildTransform(self.transform, name_path);

        GameObject reGameObject = (tf == null) ? null : tf.gameObject;
        return reGameObject;
    }
}

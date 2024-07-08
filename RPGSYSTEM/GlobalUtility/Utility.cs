using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;



public class Utility : MonoBehaviour
{
    public static List<GameObject> FindChildrenWithTag(GameObject parent, string tag)
    {
        List<GameObject> taggedChildren = new List<GameObject>();

        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag))
            {
                taggedChildren.Add(child.gameObject);
            }

            // Recursively search in the child's children
            taggedChildren.AddRange(FindChildrenWithTag(child.gameObject, tag));
        }
        return taggedChildren;
    }

    public static List<string> EnumToStringList<T>() where T : Enum
    {
        // Convert the array returned by Enum.GetNames to a list
        List<string> enumList = new List<string>(Enum.GetNames(typeof(T)));
        return enumList;
    }

    public static List<T> FindAllComponentsInChildren<T>(Transform parent) where T : class
    {
        List<T> components = new List<T>();

        // ???? ?????? ???????? ??????????.
        foreach (Transform child in parent)
        {
            // ???? child???? T ?????? ?????????? ????????.
            T component = child.GetComponent<T>();

            // ?????????? ?????? ???????? ??????????.
            if (component != null)
            {
                components.Add(component);
            }

            // ?????????? ???? ?????????? ??????????.
            components.AddRange(FindAllComponentsInChildren<T>(child));
        }

        return components;
    }

    public static T FindComponentInParent<T>(Transform transform) where T : class
    {
        // ???? ???? ?????????? ?????? ??????????.
        Transform currentTransform = transform;

        while (currentTransform != null)
        {
            // ???? ???????? ?????????? ????????.
            T component = currentTransform.GetComponent<T>();
            if (component != null)
            {
                // ?????????? ???? ???? ??????????.
                return component;
            }

            // ?????? ?????? null?? ??????????.
            currentTransform = currentTransform.parent;
        }

        // ???? ?????? ?????????? ?????????? ???? ???? ???? null?? ??????????.
        return null;
    }

    public static List<string> Getfields(Type type) 
    {
        List<FieldInfo> fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                            .ToList();
        List<string> fieldnames = new List<string>();

        foreach(var fi in fields)
        {
            if (fi.FieldType == typeof(Intstat) || fi.FieldType == typeof(Floatstat))
            {
                fieldnames.Add(fi.Name);
                fieldnames.Add(fi.Name + "(equipment)");
                fieldnames.Add(fi.Name + "(All)");
            }
            else
            {
                fieldnames.Add(fi.Name);
            }
        }

        return fieldnames;
    }
}

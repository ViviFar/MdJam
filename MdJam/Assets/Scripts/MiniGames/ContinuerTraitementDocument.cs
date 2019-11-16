using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuerTraitementDocument : MonoBehaviour
{
    [SerializeField]
    protected Toggle continueTraitement, stopTraitement;
    [SerializeField]
    protected Button validate;

    private void Start()
    {
        validate.onClick.AddListener(validation);
    }

    private void OnDestroy()
    {
        validate.onClick.RemoveListener(validation);
    }

    private void validation()
    {
        if(!continueTraitement.isOn || !stopTraitement.isOn)
        {
            //TODO : lancer ligne de dialogue pour dire d'en selectionner un
            return;
        }
        if (continueTraitement.isOn)
        {
            StatManager.Instance.SaveChild();
            StateMachine.Instance.SetNewState(State.BilanFinJeu);
        }
    }
}

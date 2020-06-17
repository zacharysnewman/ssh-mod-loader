using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SshModLoader
{
    public class LoadingBar : MonoBehaviour
    {
        [Header("Values")]
        [Tooltip("Count of all items needed to finish loading.")]
        public int numOfItems = 0;
        [Tooltip("Count of all items completed.")]
        public int numOfItemsCompleted = 0;
        [Tooltip("Value between 0 and 100.")]
        public int progressPercent = 0;
        [Tooltip("Value between 0.0 and 1.0.")]
        public float progressValue = 0;


        [Header("References")]
        public Text titleTxt;
        public Image barMsk;
        public Text percentageTxt;
        public Text primaryDescTxt;
        public Text secondaryDescTxt;
        public Button doneBtn;
        public GameObject popupBlocker;

        public void NewLoader(string title, int numOfItems, string primaryDescTxt = "", string secondaryDescTxt = "")
        {
            titleTxt.text = title;
            this.numOfItems = numOfItems;
            this.numOfItemsCompleted = 0;
            this.progressPercent = 0;
            this.progressValue = 0;

            UpdateDisplayedValues(primaryDescTxt, secondaryDescTxt);

            gameObject.SetActive(true);
            popupBlocker.SetActive(true);
        }

        public void CompleteItem(string primaryDescTxt = "", string secondaryDescTxt = "")
        {
            numOfItemsCompleted++;

            progressValue = (float)numOfItemsCompleted / (float)numOfItems;
            progressPercent = (int)(progressValue * 100);

            UpdateDisplayedValues(primaryDescTxt, secondaryDescTxt);
        }

        private void UpdateDisplayedValues(string primaryDescTxt = "", string secondaryDescTxt = "")
        {
            barMsk.fillAmount = progressValue;
            percentageTxt.text = string.Format("{0}% ({1}/{2})", progressPercent, numOfItemsCompleted, numOfItems);
            this.primaryDescTxt.text = primaryDescTxt != "" ? primaryDescTxt : this.primaryDescTxt.text;
            this.secondaryDescTxt.text = secondaryDescTxt != "" ? secondaryDescTxt : this.secondaryDescTxt.text;

            if (progressValue >= 1)
            {
                doneBtn.interactable = true;
                this.primaryDescTxt.text = "Done.";
                this.secondaryDescTxt.text = "";
            }
            else
                doneBtn.interactable = false;
        }
    }

}
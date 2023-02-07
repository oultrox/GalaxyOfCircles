using TMPro;
using UnityEngine;

namespace GalaxyOfCircles.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class VersionSetter : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _text.text = "v" + Application.version;
        }
    }
}

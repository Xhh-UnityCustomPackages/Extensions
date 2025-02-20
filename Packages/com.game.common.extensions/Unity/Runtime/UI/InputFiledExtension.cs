using UnityEngine.UI;

namespace Game
{
    public static class InputFieldExtension
    {
        public static void Focus(this InputField inputField)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }
}
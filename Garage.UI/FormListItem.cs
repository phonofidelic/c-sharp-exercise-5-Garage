using System.Collections;

namespace Garage.UI
{
    public class FormListItem : IInput
    {
        public string Name { get; private set; }
        public int Option { get; private set; }
        public string InputPrompt { get; private set; }
        //public IInput Children { get; private set; }

        public FormListItem(int option, string name, string inputPrompt)
        {
            Name = name;
            Option = option;
            InputPrompt = inputPrompt;
            //Children = children;
        }
        //public FormListItem(int option, string name)
        //{
        //    Name = name;
        //    Option = option;
        //    Children = null;
        //}

        public string? Render()
        {
            return ConsoleUI.GetInputFromReadLine(InputPrompt);
        }
    }
}
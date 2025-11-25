using System.Collections;

namespace Garage.UI
{
    public class MenuListItem : IRender, IEnumerator
    {
        public string Name { get; private set; }
        public int Option { get; private set; }

        public IRender? Children { get; private set; }

        public MenuListItem Current => throw new NotImplementedException();

        object IEnumerator.Current => Current;

        public MenuListItem(int option, string name, IRender children)
        {
            Name = name;
            Option = option;
            Children = children;
        }
        public MenuListItem(int option, string name)
        {
            Name = name;
            Option = option;
            Children = null;
        }

        public void Render()
        {
            ConsoleUI.WriteLine($"{Option}.\t{Name}");
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
} 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class MenuItemDTO
    {
        public string Name { get; private set; }
        public IRender? Children { get; private set; }

        public MenuItemDTO(string name, IRender children)
        {
            Name = name;
            Children = children;
        }
        public MenuItemDTO(string name)
        {
            Name = name;
            Children = null;
        }
    }

    public class FormInputDTO
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IInput Input { get; private set; }
        public FormInputDTO(string name, string description, IInput input)
        {
            Name = name;
            Description = description;
            Input = input;
        }
    }
    public class MenuList : IEnumerable<MenuListItem>
    {
        public int Count { get; private set; } = 0;        
        private readonly List<MenuListItem> _list;


        public MenuList()
        {
            _list = [];
        }

        public MenuList(IEnumerable<MenuItemDTO> items)
        {
            _list = [];
            foreach(MenuItemDTO item in items)
            {
                Add(item);
            }
        }

        public MenuList(IEnumerable<FormInputDTO> items)
        {
            _list = [];
            foreach(FormInputDTO item in items)
            {
                Add(item);
            }
        }

        public void Add(MenuItemDTO item)
        {
            Count++;
            if (item.Children != null) 
                _list.Add(new MenuListItem(Count, item.Name, item.Children));
            else
                _list.Add(new MenuListItem(Count, item.Name));
        }

        public void Add(FormInputDTO item)
        {
            Count++;
            _list.Add(new MenuListItem(Count, item.Name, item.Description, item.Input));
        }

        public IEnumerator<MenuListItem> GetEnumerator()
        {
            foreach (MenuListItem item in _list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

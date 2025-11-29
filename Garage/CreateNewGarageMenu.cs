using Garage.Library;
using Garage.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;

namespace Garage
{



    internal class CreateNewGarageMenu 
        : Form<CreateGarageRequestDTO>
    {
        public CreateNewGarageMenu(
    //GarageNameInput garageNameInput
    //IServiceScopeFactory serviceScopeFactory
            )
        : base(
        name: "Create a new Garage",
        description: "Initialize a new Garage by giving it a name and indicating its capacity.",
        inputs: [],
            
        inputPrompt: "Select a property from the menu to configure."
        )
        {
            Add(new("Name", "Enter a name for your new garage:"));
        }
    }


    internal class GarageNameInput : IRender
    {
        private CreateNewGarageMenu? Parent { get; set; } = null;
        //public string? Value { get; private set; } = null;
        //public GarageNameInput(CreateNewGarageMenu parent)
        //{
        //    //Parent = parent;
        //}

        public GarageNameInput(IServiceScopeFactory serviceScopeFactory)
        {
            using IServiceScope scope = serviceScopeFactory.CreateScope();
            var parent = scope.ServiceProvider.GetRequiredService<CreateNewGarageMenu>();
            SetParent(parent);
        }

        public void SetParent(CreateNewGarageMenu parent)
        {
            Parent = parent;
        }
        public void Render()
        {
            string name = ConsoleUI.GetInputFromReadLine(message: "What is the name of your garage?") ?? "";
            // Set parent state with callback?

            //CreateGarageRequestDTO parentProps = Parent.Props;
            //if (Parent != null)
                //Parent.SetProps(Parent.Props with { Name = name });
            //setParentProps(parentProps => parentProps with { Name = name });
            //setParentProps(props => new();
        }

        //public void Render(RenderCallback<CreateGarageRequestDTO>  callback)
        //{
        //    string name = ConsoleUI.GetInputFromReadLine(message: "What is the name of your garage?") ?? "";
        //    // Set parent state with callback?

        //    //CreateGarageRequestDTO parentProps = Parent.Props;
        //    callback((CreateGarageRequestDTO parentProps) => parentProps with { Name = name });
        //}
    }
}
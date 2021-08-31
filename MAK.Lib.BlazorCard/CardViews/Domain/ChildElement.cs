using Interfaces;

using Microsoft.AspNetCore.Components;

namespace Domain
{
    public abstract class ChildElement<TParent> : ComponentBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if(this.Parent != null)
            {
                this.Register(this.Parent);
            }
        }

        protected new void StateHasChanged()
        {
            base.StateHasChanged();

            var cscHandler = this.Parent as IHandleChildStateChange;

            if(cscHandler != null)
            {
                cscHandler.ChildStateChanged();
            }
        }

        [CascadingParameter]
        private TParent Parent { get; set; }

        protected abstract void Register(TParent parent);
        public abstract RenderFragment RenderContent { get; }
    }
}

// BlazorCard is a Blazor RCL that uses Generics for its Type. It uses CSS Grid for the layout feature; the layout and styling can be changed by providing CSS classes to the provided Parameters.
// 
//MAK.Lib.BlazorCard
//Generic

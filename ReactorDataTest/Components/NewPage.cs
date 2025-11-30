using ReactorData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorDataTest.Components
{
    partial class NewPage : Component
    {
        [Inject] IModelContext modelContext;
        [Prop] bool isVisible;
        [Prop] Action _onAdd;
        public override VisualNode Render()
            => Button ("Clicked")
                        .OnClicked (Create)
                        .HCenter ()
                        .IsVisible (isVisible);

        void Create()
        {
            this.modelContext.Add (new Todo ()
            {
                Id = Guid.NewGuid ().ToString (),
                Name = "TEst",
                Datas = ["a", "b", "c"]
            });

            this.modelContext.Save ();
        }
    }
}

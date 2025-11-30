using ReactorData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorDataTest.Components
{
    [Model]
    public partial class Todo
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public List<string> Datas = new ();
    }

    internal class ViewPageState
    {
        public IQuery<Todo> Todos { get; set; }
    }
    partial class ViewPage : Component<ViewPageState>
    {

        [Inject] IModelContext modelContext;
        [Prop] bool isVisible;
        protected override void OnMounted()
        {
            State.Todos = modelContext.Query<Todo> ();

            base.OnMounted ();
        }
        public override VisualNode Render()
            => VStack (
                        State.Todos
                                .Select (Views)
                );

        VisualNode Views(Todo todo)
            => Grid ("auto", "*,*",
                    Label (todo.Name),
                    HStack (
                            todo.Datas
                                .Select (SubView)
                        ).GridColumn (1)
                );

        VisualNode SubView(string d)
            => Label (d);
    }
}

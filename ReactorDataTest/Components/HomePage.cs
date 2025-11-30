using ReactorData;

namespace ReactorDataTest.Components
{
    [Model]
    public partial class Todo
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public List<string> Datas = new ();
    }

    internal class HomePageState
    {
        public bool IsViewVisible { get; set; } = false;
    }

    partial class HomePage : Component<HomePageState>
    {
        public override VisualNode Render()
            => ContentPage (
                    ScrollView (
                        VStack (
                            Image ("dotnet_bot.png")
                                .HeightRequest (200)
                                .HCenter ()
                                .Set (SemanticProperties.DescriptionProperty, "Cute dot net bot waving hi to you!"),
                            new ViewPage()
                                .IsVisible(!State.IsViewVisible),
                            new NewPage()
                                .OnAdd(()=>SetState (s => s.IsViewVisible = false))
                                .IsVisible(State.IsViewVisible),
                            Button(State.IsViewVisible? "Show NewPage" : "Hide NewPage")
                                .OnClicked(_=>SetState(s=>s.IsViewVisible = true))
                    )
                    .VCenter ()
                    .Spacing (25)
                    .Padding (30, 0)
                )
            );
    }
}

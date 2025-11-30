using ReactorData;

namespace ReactorDataTest.Components
{

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
                                .IsVisible(State.IsViewVisible),
                            Button(State.IsViewVisible? "Show NewPage" : "Hide NewPage")
                                .OnClicked(_=>SetState(s=>s.IsViewVisible = !s.IsViewVisible))
                    )
                    .VCenter ()
                    .Spacing (25)
                    .Padding (30, 0)
                )
            );
    }
}

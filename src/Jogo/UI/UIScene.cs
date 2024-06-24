using System.Numerics;
using Raylib_cs;
class UIScene : IScene
{
    public Container root;
    public static UIComponent ButtonText(string Text){
        Vector2 bsize =  new (100, 30);
        return new Button(
            size: bsize,
            color: Color.Red,
            hoverColor: Color.Brown,
            component: new AlignedPositionContainer(
                size: bsize,
                horizontalAlign: HorizontalAlign.Center,
                verticalAlign: VerticalAlign.Center,
                component: new UIText(Text, Color.White, 20)
            )
        );
    }
    public UIScene()
    {
       
    }

    public void Render()
    {
        root.Render();
    }

    public void Update()
    {
        root.Update();
    }
}
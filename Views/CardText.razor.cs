namespace Views;

public partial class CardText<TEntity> : ContainerChildElement<ICardBody<TEntity>>
{
    protected override void Register(ICardBody<TEntity> parent) => parent.AddText(this);

    [Parameter]
    public string Css { get; set; }

    protected override string ContainerCssClass => this.Css;
    protected override ElementType ContainerChildElementType => ElementType.P;
}

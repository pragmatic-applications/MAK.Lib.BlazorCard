namespace Views;

public partial class CardLink<TEntity> : ChildElement<ICardBody<TEntity>>
{
    protected override void Register(ICardBody<TEntity> parent) => parent.AddLink(this);

    [Parameter]
    public EventCallback OnAction { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string LinkUrl { get; set; }

    [Parameter]
    public string Css { get; set; }

    public override RenderFragment RenderContent => (builder =>
    {
        builder.OpenElement(0, "a");

        if(!string.IsNullOrWhiteSpace(this.Css))
        {
            builder.AddAttribute(1, "class", this.Css);
        }
        else
        {
            builder.AddAttribute(1, "class", string.Empty);
        }

        if(!string.IsNullOrWhiteSpace(this.LinkUrl))
        {
            builder.AddAttribute(2, "href", this.LinkUrl);
        }
        else
        {
            builder.AddAttribute(2, "href", "#");
        }

        if(!string.IsNullOrWhiteSpace(this.LinkUrl))
        {
            builder.AddAttribute(3, "onclick", this.OnAction);
        }

        builder.AddContent(4, this.ChildContent);
        builder.CloseElement();
    });
}

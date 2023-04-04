namespace Lab01;

using HtmlDocument = HtmlAgilityPack.HtmlDocument;
    
public abstract class CurrencyAPI
{
    protected Tuple<string, string> defaultValue = Tuple.Create(Resources.DefaultValue, Resources.DefaultValue);
        
    internal static HtmlDocument? htmlDocument;
    public abstract Tuple<string, string> GetDollar();
    public abstract Tuple<string, string> GetEuro();

    protected static async void SendRequest(string url)
    {
        try
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
        }
        catch
        {
            MessageBox.Show(
                Resources.WarningMessage,
                Resources.WarningTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}
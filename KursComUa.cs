namespace Lab01;

public class KursComUa : CurrencyAPI
{
    public override Tuple<string, string> GetDollar()
    {
        var task = Task.Factory.StartNew(() => SendRequest(Constants.KursComUaUrl));
        task.Wait();
        Thread.Sleep(1500);
        
        if (htmlDocument == null) return defaultValue;

        var currencyDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("div")
            .Where(node => node.GetAttributeValue("class", "").Equals("course"))
            .ToList();

        var dollarPurchaseString = currencyDocumentListHtml[0].InnerHtml.ToString();
        var dollarPurchaseStringArray = dollarPurchaseString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var purchase = dollarPurchaseStringArray[0];
        var dollarSaleString = currencyDocumentListHtml[1].InnerHtml;
        var dollarSaleStringArray = dollarSaleString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var sale = dollarSaleStringArray[0];
        
        return Tuple.Create(purchase, sale);
    }

    public override Tuple<string, string> GetEuro()
    {
        if (htmlDocument == null) return defaultValue;
        
        var currencyDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("div")
            .Where(node => node.GetAttributeValue("class", "").Equals("course"))
            .ToList();

        var euroPurchaseString = currencyDocumentListHtml[4].InnerHtml;
        var euroPurchaseStringArray = euroPurchaseString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var purchase = euroPurchaseStringArray[0];
        var euroSaleString = currencyDocumentListHtml[5].InnerHtml;
        var euroSaleStringArray = euroSaleString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var sale = euroSaleStringArray[0];
        
        return Tuple.Create(purchase, sale);
    }
}
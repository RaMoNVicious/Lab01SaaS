namespace Lab01;

public class MinfinComUa : CurrencyAPI
{
    public override Tuple<string, string> GetDollar()
    {
        var task = Task.Factory.StartNew(() => SendRequest(Constants.MinfinComUaUrl));
        task.Wait();
        Thread.Sleep(1500);
        
        if (htmlDocument == null) return defaultValue;
        
        var currencyDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("td")
            .Where(node => node.GetAttributeValue("class", "").Equals("mfm-text-nowrap"))
            .ToList();
        
        var dollarPurchaseString = currencyDocumentListHtml[0].InnerHtml;
        var dollarPurchaseStringArray = dollarPurchaseString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var purchase = dollarPurchaseStringArray[0].Trim();
        var dollarSaleString = currencyDocumentListHtml[1].InnerHtml;
        var dollarSaleStringArrayHtml = dollarSaleString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var dollarSaleHtml = dollarSaleStringArrayHtml[6].Trim();
        var dollarSaleStringArray = dollarSaleHtml.Split(
            new[] { '>' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var sale = dollarSaleStringArray[1].Trim();
        
        return Tuple.Create(purchase, sale);
    }

    public override Tuple<string, string> GetEuro()
    {
        if (htmlDocument == null) return defaultValue;
        
        var currencyDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("td")
            .Where(node => node.GetAttributeValue("class", "").Equals("mfm-text-nowrap"))
            .ToList();
        
        var euroPurchaseString = currencyDocumentListHtml[2].InnerHtml;
        var euroPurchaseStringArray = euroPurchaseString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var purchase = euroPurchaseStringArray[0].Trim();
        var euroSaleString = currencyDocumentListHtml[3].InnerHtml;
        var euroSaleStringArrayHtml = euroSaleString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var euroSaleHtml = euroSaleStringArrayHtml[6].Trim();
        var euroSaleStringArray = euroSaleHtml.Split(
            new[] { '>' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var sale = euroSaleStringArray[1].Trim();
        
        return Tuple.Create(purchase, sale);
    }
}
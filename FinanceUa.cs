namespace Lab01;

internal class FinanceUa : CurrencyAPI
{
    public override Tuple<string, string> GetDollar()
    {
        var task = Task.Factory.StartNew(() => SendRequest(Constants.FinanceUaUrl));
        task.Wait();
        Thread.Sleep(1500);

        if (htmlDocument == null) return defaultValue;

        var dollarPurchaseDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("tr")
            .Where(node => node.GetAttributeValue("class", "").Equals("topcurs1"))
            .ToList();

        var dollarDocumentList = dollarPurchaseDocumentListHtml[0]
            .Descendants("td")
            .Where(node => node.GetAttributeValue("class", "").Equals("value"))
            .ToList();

        var purchaseString = dollarDocumentList[0].InnerHtml;
        var purchaseStringArray = purchaseString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var purchase = purchaseStringArray[0];
        var saleString = dollarDocumentList[1].InnerHtml;
        var saleStringArray = saleString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var sale = saleStringArray[0];

        return Tuple.Create(purchase, sale);
    }

    public override Tuple<string, string> GetEuro()
    {
        if (htmlDocument == null) return defaultValue;

        var euroPurchaseDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("td")
            .Where(node => node.GetAttributeValue("class", "").Equals("value"))
            .ToList();

        var euroPurchaseString = euroPurchaseDocumentListHtml[2].InnerHtml;
        var euroPurchaseStringArray =
            euroPurchaseString.Split(
                new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries
            );

        var purchase = euroPurchaseStringArray[0];
        var euroSaleDocumentListHtml = htmlDocument.DocumentNode
            .Descendants("td")
            .Where(node => node.GetAttributeValue("class", "").Equals("value down"))
            .ToList();

        var euroSaleString = euroSaleDocumentListHtml[0].InnerHtml;
        var euroSaleStringArray = euroSaleString.Split(
            new[] { '<' },
            StringSplitOptions.RemoveEmptyEntries
        );
        var sale = euroSaleStringArray[0];

        return Tuple.Create(purchase, sale);
    }
}
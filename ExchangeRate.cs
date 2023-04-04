using System.Data;

namespace Lab01
{
    public partial class ExchangeRate : Form
    {
        static string
            _dollarPurchaseMinfinUa = Resources.DefaultValue,
            _dollarSaleMinfinUa = Resources.DefaultValue,
            _euroPurchaseMinfinUa = Resources.DefaultValue,
            _euroSaleMinfinUa = Resources.DefaultValue,
            _dollarPurchaseKursUa = Resources.DefaultValue,
            _dollarSaleKursUa = Resources.DefaultValue,
            _euroPurchaseKursUa = Resources.DefaultValue,
            _euroSaleKursUa = Resources.DefaultValue,
            _dollarPurchaseFinanceUa = Resources.DefaultValue,
            _dollarSaleFinanceUa = Resources.DefaultValue,
            _euroPurchaseFinanceUa = Resources.DefaultValue,
            _euroSaleFinanceUa = Resources.DefaultValue;

        public ExchangeRate()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            LoadMinfinComUaData();
            LoadKursComUaData();
            LoadFinanceUaData();
            DataCurrencyTable.DataSource = SetData();
        }

        private static void LoadMinfinComUaData()
        {
            try
            {
                var minfinComUa = new MinfinComUa();

                var dollar = minfinComUa.GetDollar();
                _dollarPurchaseMinfinUa = dollar.Item1;
                _dollarSaleMinfinUa = dollar.Item2;

                var euro = minfinComUa.GetEuro();
                _euroPurchaseMinfinUa = euro.Item1;
                _euroSaleMinfinUa = euro.Item2;
            }
            catch
            {
                MessageBox.Show(
                    Resources.WarningMessage,
                    $@"{new MinfinComUa().GetType()}: " + Resources.WarningTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private static void LoadKursComUaData()
        {
            try
            {
                var kursComUa = new KursComUa();

                var dollar = kursComUa.GetDollar();
                _dollarPurchaseKursUa = dollar.Item1;
                _dollarSaleKursUa = dollar.Item2;

                var euro = kursComUa.GetEuro();
                _euroPurchaseKursUa = euro.Item1;
                _euroSaleKursUa = euro.Item2;
            }
            catch
            {
                MessageBox.Show(
                    Resources.WarningMessage,
                    $@"{new KursComUa().GetType()}: " + Resources.WarningTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private static void LoadFinanceUaData()
        {
            try
            {
                var financeUa = new FinanceUa();
                var dollar = financeUa.GetDollar();
                _dollarPurchaseFinanceUa = dollar.Item1;
                _dollarSaleFinanceUa = dollar.Item2;

                var euro = financeUa.GetEuro();
                _euroPurchaseFinanceUa = euro.Item1;
                _euroSaleFinanceUa = euro.Item2;
            }
            catch
            {
                MessageBox.Show(
                    Resources.WarningMessage,
                    $@"{new FinanceUa().GetType()}: " + Resources.WarningTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private static DataTable SetData()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(Resources.ResourceColumnTitle, typeof(string));
            dataTable.Columns.Add(Resources.CurrencyColumnTitle, typeof(string));
            dataTable.Columns.Add(Resources.PurchaseColumnTitle, typeof(string));
            dataTable.Columns.Add(Resources.SaleColumnTitle, typeof(string));

            dataTable.Rows.Add(
                Resources.MinfinComUaTitle,
                Resources.Dollar,
                _dollarPurchaseMinfinUa,
                _dollarSaleMinfinUa
            );
            dataTable.Rows.Add(
                Resources.MinfinComUaTitle,
                Resources.Euro,
                _euroPurchaseMinfinUa,
                _euroSaleMinfinUa
            );
            dataTable.Rows.Add(
                Resources.KursComUaTitle,
                Resources.Dollar,
                _dollarPurchaseKursUa,
                _dollarSaleKursUa
            );
            dataTable.Rows.Add(
                Resources.KursComUaTitle,
                Resources.Euro,
                _euroPurchaseKursUa,
                _euroSaleKursUa
            );
            dataTable.Rows.Add(
                Resources.FinanceUaTitle,
                Resources.Dollar,
                _dollarPurchaseFinanceUa,
                _dollarSaleFinanceUa
            );
            dataTable.Rows.Add(
                Resources.FinanceUaTitle,
                Resources.Euro,
                _euroPurchaseFinanceUa,
                _euroSaleFinanceUa
            );

            return dataTable;
        }
    }
}
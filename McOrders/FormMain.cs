namespace McOrders {
  public partial class FormMain : Form {
    Ordering ordering;

    public FormMain() {
      InitializeComponent();
      ordering = new Ordering();
      // TODO: registracija metode koja se pokreæe kada se pokrene narudžba
      ordering.OrderStarted += OrderStarted;
      ordering.OrderCompleted += OrderCompleted;
    }

    private void OrderStarted(object sender, OrderArgs e) {
            // TODO: Potrebno je pozvati metodu koja ažurira
            // aktivne narudžb
            if (InvokeRequired)
            {
                BeginInvoke(UpdateActiveOrders);
            }
            else
            {
                UpdateActiveOrders();
            }

    }

    private void OrderCompleted(object sender, OrderArgs e) {
      if (InvokeRequired) {
        BeginInvoke(UpdateCompletedOrders);
      }
    }

    private void UpdateActiveOrders() {
      lbActiveOrders.Items.Clear();
      lbActiveOrders.Items.AddRange(ordering.ActiveOrders.ToArray());
    }

    private void UpdateCompletedOrders() {
      UpdateActiveOrders();
      lbCompletedOrders.Items.Clear();
      lbCompletedOrders.Items.AddRange(ordering.CompletedOrders.ToArray());
    }

    private void btnPommes_Click(object sender, EventArgs e) {
            ordering.AddOrder(new FoodPommes());
        }

    private void btnBigMac_Click(object sender, EventArgs e) {
            ordering.AddOrder(new FoodBigMac());
        }

    private void btnDrink_Click(object sender, EventArgs e) {
      ordering.AddOrder(new FoodDrink());
    }
  }
}
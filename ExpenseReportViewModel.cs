using System;
namespace SaggezzaApp
{
    public class ExpenseReportViewModel
    {

            public DateTime SubmittedAt { get; set; }

            public DateTime ClaimDate { get; set; }

            public String ReceiptPic { get; set; }

            public string Description { get; set; }

            public string Category { get; set; }

            public string ClientName { get; set; }

            public string PaymentMethod { get; set; }

            public bool BillableToClient { get; set; }

            public string UserID { get; set; }

            public decimal Amount { get; set; }

            public string Currency { get; set; }

            public string Status { get; set; }

            public ExpenseReportViewModel(ExpenseReport report)
            {
                SubmittedAt = report.SubmittedAt;
                ClaimDate = report.ClaimDate;
                ReceiptPic = report.ReceiptPic;
                Description = report.Description;
                Category = report.Category;
                ClientName = report.ClientName;
                PaymentMethod = report.PaymentMethod;
                BillableToClient = report.BillableToClient;
                UserID = report.UserID;
                Amount = report.Amount;
                Currency = report.Currency;
                Status = report.Status;
            }

            public void Update(DateTime submittedAt, DateTime claimDate, String receiptPic, string description, string clientName, string category, string paymentMethod, bool billableToClient, string userID, decimal amount, string currency, string status)
            {
                SubmittedAt = submittedAt;
                ClaimDate = claimDate;
                ReceiptPic = receiptPic;
                Description = description;
                Category = category;
                ClientName = clientName;
                PaymentMethod = paymentMethod;
                BillableToClient = billableToClient;
                UserID = userID;
                Amount = amount;
                Currency = currency;
                Status = status;
            }
            


    }
}

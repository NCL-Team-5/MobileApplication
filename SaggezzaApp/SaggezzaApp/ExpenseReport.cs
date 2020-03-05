using System;
using Plugin.CloudFirestore.Attributes;

namespace SaggezzaApp
{
    public class ExpenseReport
    {
        // Time + date submitted
        [ServerTimestamp]
        public DateTime SubmittedAt { get; set; }

        // Date person is claiming for
        public DateTime ClaimDate { get; set; }

        // Link to pictures of receipt uploaded, Document Reference
        [MapTo("ReceiptPhoto")]
        public string ReceiptPic { get; set; }

        // Extra text included by user
        public string Description { get; set; }

        // Client Name/Saggezza
        public string ClientName { get; set; }

        // Category of expense report
        public string Category { get; set; }

        // Payment method used
        public string PaymentMethod { get; set; }

        // Billable to client (True/False)
        public bool BillableToClient { get; set; }

        // ID of user
        public string UserID { get; set; }

        // Amount claimed as decimal
        public decimal Amount { get; set; }

        // Currency used
        public string Currency { get; set; }

        // Status of submission
        public string Status { get; set; }

    }
}
